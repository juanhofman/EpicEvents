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
        private DrugDealerLocation[] m_DrugDealerLocations = new DrugDealerLocation[]
        {
            new DrugDealerLocation(new EVector3(91,-1249,29,270), new EVector3(93,-1248,29.3f,136), new EVector3(82,-1257,29.3f,82),new EVector3(92,-1251,29.3f,35),
                new EVector3(95,-1250,29.3f,75))
        };

        private int m_CurrentLocations = 0;
        private int m_BehavPath = 0;

        private Ped[] m_Peds;
        private Vehicle m_Vehicle;

        private bool m_InPursuit = false;
        private LHandle m_Pursuit;

        public override void Start()
        {
            base.Start();

            Log("Starting");

            Log("Clearing area of peds and cars");

            foreach (Vehicle v in World.GetAllVehicles())
            {
                if (v.DistanceTo(m_DrugDealerLocations[0].Car.Vector3) < 10 && v.Exists() && v != Game.LocalPlayer.LastVehicle)
                {
                    v.Delete();
                }
            }

            foreach (Ped p in World.GetAllPeds())
            {
                if (p.DistanceTo(m_DrugDealerLocations[0].Car.Vector3) < 10 && p.Exists())
                {
                    p.Delete();
                }
            }

            Log("Spawning peds");

            m_Peds = new Ped[]
            {
                ResourceManager.CreatePed(m_DrugDealerLocations[0].Criminal1.Vector3,m_DrugDealerLocations[0].Criminal1.Heading),
                ResourceManager.CreatePed(m_DrugDealerLocations[0].Criminal2.Vector3,m_DrugDealerLocations[0].Criminal2.Heading),
                ResourceManager.CreatePed(m_DrugDealerLocations[0].Buyer1.Vector3,m_DrugDealerLocations[0].Buyer1.Heading),
                ResourceManager.CreatePed(m_DrugDealerLocations[0].Buyer2.Vector3,m_DrugDealerLocations[0].Buyer2.Heading)
            };

            foreach (Ped p in m_Peds)
            {
                AnimationType anim;
                anim = Animation.GetRandomIdleAnimation();

                p.Tasks.PlayAnimation(anim.Dictionary, anim.Animation, 1, AnimationFlags.Loop);
                p.Inventory.GiveNewWeapon(WeaponHash.Pistol, 50, false);
            }

            Log("Setting ped items and personas");

            foreach (Ped p in m_Peds)
            {
                Wrapper.SetPedItems(p, SearchItems.GetRandomItemsRedPed());
            }

            Log("Spawning vehicles");

            m_Vehicle = ResourceManager.CreateVehicle("Faction3", m_DrugDealerLocations[0].Car.Vector3, m_DrugDealerLocations[0].Car.Heading);

            Log("Setting up vehicles");

            m_Vehicle.IsEngineOn = true;

            m_Vehicle.IsInteriorLightOn = true;
            NativeFunction.Natives.SET_VEHICLE_LIGHTS(m_Vehicle, 2);

            m_Vehicle.GetDoors()[0].Open(true);

            Wrapper.SetVehicleItems(m_Vehicle, SearchItems.GetRandomItemsRedVehicles(), "", SearchItems.GetRandomItemsRedVehicles());

            Log("Setting behaviour path");

            //m_BehavPath = Random.Next(0, 3);//0,1,2
            m_BehavPath = 2;

            Log("Setting behaviour specific");


            Log("Done setting up");
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

                    if (!m_InPursuit && Game.LocalPlayer.Character.DistanceTo(m_DrugDealerLocations[0].Criminal2.Vector3) < distance)
                    {
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

                        Functions.PlayScannerAudioUsingPosition("OFFICERS_REPORT CRIME_RESIST_ARREST IN_OR_ON_POSITION", Game.LocalPlayer.Character.Position);
                        Game.DisplayNotification("3dtextures", "mpgroundlogo_cops", "Dispatch", "", "Show me in purstuit of 4 individuals, possibly armed.");
                        Functions.PlayScannerAudioUsingPosition("ASSISTANCE_REQUIRED IN_OR_ON_POSITION", Game.LocalPlayer.Character.Position);
                        Game.DisplayNotification("3dtextures", "mpgroundlogo_cops", "Dispatch", "", "Copy that, sending backup!");

                        Wrapper.CallBackup(Wrapper.BackupType.pursuit);

                        m_InPursuit = true;
                    }

                    break;
                case 1://Run and shoot

                    if (!m_InPursuit && Game.LocalPlayer.Character.DistanceTo(m_DrugDealerLocations[0].Criminal2.Vector3) < distance)
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
            base.End();

            Log("Cleaning up");

            foreach (Ped p in m_Peds)
            {
                ResourceManager.RemovePed(p);
            }

            ResourceManager.RemoveVehicle(m_Vehicle);

            Log("Cleaned up correctly, ending event.");
        }
    }

    public struct DrugDealerLocation
    {
        public EVector3 Car;

        public EVector3 Criminal1;
        public EVector3 Criminal2;

        public EVector3 Buyer1;
        public EVector3 Buyer2;

        public DrugDealerLocation(EVector3 car, EVector3 criminal1, EVector3 criminal2, EVector3 buyer1, EVector3 buyer2)
        {
            Car = car;
            Criminal1 = criminal1;
            Criminal2 = criminal2;
            Buyer1 = buyer1;
            Buyer2 = buyer2;
        }
    }
}
