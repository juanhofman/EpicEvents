using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using Rage.Native;
using LSPD_First_Response.Mod.API;
using LSPD_First_Response.Mod.Callouts;
using LSPD_First_Response.Engine.Scripting.Entities;

namespace EpicEvents.Events
{
    public class DrugDealer : Event
    {
        private int m_Location = 0;
        private int m_BehavPath = 0;

        private Ped[] m_Peds;
        private Vehicle[] m_Vehicles;
        private Blip m_Blip;

        private bool m_InPursuit = false;
        private LHandle m_Pursuit;

        public override bool Start()
        {
            Log("Starting");

            m_Location = Location.GetClosestLocationInArray(Location.DrugDealerLocation, Game.LocalPlayer.Character.Position);
            if (Game.LocalPlayer.Character.Position.DistanceTo(Location.DrugDealerLocation[m_Location][0].Posistion) < 50)
            {
                Log("Distance check failed");
                return false;
            }

            Log("Location id: " + m_Location);

            Log("Adding small blip");
            m_Blip = ResourceManager.CreatBlip(Location.HomlessLocations[m_Location][0].Posistion, 20f);
            m_Blip.Color = System.Drawing.Color.Yellow;

            Log("Clearing area of peds and cars");

            foreach (Vehicle v in World.GetAllVehicles())
            {
                if (v.DistanceTo(Location.DrugDealerLocation[m_Location][0].Posistion) < 10 && v.Exists() && v != Game.LocalPlayer.LastVehicle)
                {
                    v.Delete();
                }
            }

            foreach (Ped p in World.GetAllPeds())
            {
                if (p.DistanceTo(Location.DrugDealerLocation[m_Location][0].Posistion) < 10 && p.Exists())
                {
                    p.Delete();
                }
            }

            Log("Spawning peds");

            LocationItem[] peditems = Location.GetPedsInArray(Location.DrugDealerLocation[m_Location]);

            m_Peds = new Ped[peditems.Length];

            for (int i = 0; i < peditems.Length; i++)
            {
                m_Peds[i] = ResourceManager.CreatePed(Models.GetRandomHomless(), peditems[i].Posistion,
                    peditems[i].Rotation.Z);

                if (peditems[i].AnimName != "" && peditems[i].AnimDict != "")
                {
                    m_Peds[i].Tasks.PlayAnimation(peditems[i].AnimDict, peditems[i].AnimName, 1, AnimationFlags.Loop);
                }
                if (peditems[i].Frozen == true)
                {
                    m_Peds[i].IsPositionFrozen = true;
                }

                m_Peds[i].Inventory.GiveNewWeapon(WeaponHash.Pistol, 50, false);
                Wrapper.SetPedItems(m_Peds[i], SearchItems.GetRandomItemsRedPed());
            }

            Log("Spawning vehicles");

            LocationItem[] vehicle = Location.GetVehiclesInArray(Location.DrugDealerLocation[m_Location]);

            m_Vehicles = new Vehicle[vehicle.Length];

            for (int i = 0; i < vehicle.Length; i++)
            {
                m_Vehicles[i] = ResourceManager.CreateVehicle(vehicle[i].Model, vehicle[i].Posistion, vehicle[i].Rotation.Z);
                m_Vehicles[i].IsEngineOn = true;
                m_Vehicles[i].IsInteriorLightOn = true;
                NativeFunction.Natives.SET_VEHICLE_LIGHTS(m_Vehicles[i], 2);
                m_Vehicles[i].GetDoors()[0].Open(true);
                Wrapper.SetVehicleItems(m_Vehicles[i], SearchItems.GetRandomItemsRedVehicles(), "", SearchItems.GetRandomItemsRedVehicles());
            }

            Log("Setting behaviour path");

            m_BehavPath = Random.Next(0, 3);

            Log("Setting behaviour specific");


            Log("Done setting up");
            return true;
        }

        public override void Update()
        {
            base.Update();

            int distance = 30;

            if (Game.LocalPlayer.LastVehicle.Exists())
                distance = Game.LocalPlayer.LastVehicle.IsSirenOn ? 30 : 20;

            switch (m_BehavPath)
            {
                //TODO: Change distance on light on.


                default://Run on too close

                    if (!m_InPursuit && Game.LocalPlayer.Character.DistanceTo(Location.DrugDealerLocation[m_Location][0].Posistion) < distance)
                    {
                        m_InPursuit = true;
                        m_Pursuit = Functions.CreatePursuit();

                        foreach (Ped p in m_Peds)
                        {
                            Functions.AddPedToPursuit(m_Pursuit, p);
                            PedPursuitAttributes attri = Functions.GetPedPursuitAttributes(p);
                            attri.HandlingAbility = (float)Random.NextDouble() + 0.5f;
                        }

                        Functions.SetPursuitCopsCanJoin(m_Pursuit, true);
                        Functions.SetPursuitTacticsEnabled(m_Pursuit, true);
                        Functions.SetPursuitIsActiveForPlayer(m_Pursuit, true);
                    }

                    break;
                case 1://Run and shoot

                    if (!m_InPursuit && Game.LocalPlayer.Character.DistanceTo(Location.DrugDealerLocation[m_Location][0].Posistion) < distance)
                    {
                        m_Pursuit = Functions.CreatePursuit();

                        for (int i = 0; i < 2; i++)
                        {
                            Functions.AddPedToPursuit(m_Pursuit, m_Peds[i]);
                            PedPursuitAttributes attri = Functions.GetPedPursuitAttributes(m_Peds[i]);
                            attri.HandlingAbility = (float)Random.NextDouble() + 0.5f;
                        }

                        Functions.SetPursuitCopsCanJoin(m_Pursuit, true);
                        Functions.SetPursuitTacticsEnabled(m_Pursuit, true);
                        Functions.SetPursuitIsActiveForPlayer(m_Pursuit, true);

                        Functions.PlayScannerAudioUsingPosition("OFFICERS_REPORT CRIME_RESIST_ARREST IN_OR_ON_POSITION", Game.LocalPlayer.Character.Position);
                        Game.DisplayNotification("3dtextures", "mpgroundlogo_cops", "Dispatch", "", "Show me in purstuit of 4 individuals, possibly armed.");
                        Functions.PlayScannerAudioUsingPosition("ASSISTANCE_REQUIRED IN_OR_ON_POSITION", Game.LocalPlayer.Character.Position);
                        Game.DisplayNotification("3dtextures", "mpgroundlogo_cops", "Dispatch", "", "Copy that, sending backup!");

                        for (int i = 2; i < 4; i++)
                        {
                            m_Peds[i].DropsCurrentWeaponOnDeath = true;
                            m_Peds[i].Inventory.GiveNewWeapon(WeaponHash.Pistol, 50, true);
                            m_Peds[i].Tasks.FireWeaponAt(Game.LocalPlayer.Character, int.MaxValue, FiringPattern.BurstFirePistol);
                        }

                        m_InPursuit = true;
                    }

                    break;
                case 2:

                    //Dont do anything

                    break;
            }
        }

        public override void End()
        {
            Log("Cleaning up");

            foreach (Ped p in m_Peds)
            {
                ResourceManager.RemovePed(p);
            }

            m_Peds = null;

            foreach (Vehicle v in m_Vehicles)
            {
                ResourceManager.RemoveVehicle(v);
            }

            m_Vehicles = null;

            ResourceManager.RemoveBlip(m_Blip);
            m_Blip = null;

            Log("Cleaned up correctly, ending event.");
            base.End();
        }
    }
}