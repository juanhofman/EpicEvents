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
    class HomlessDisturbance : Event
    {
        private int m_Location = 0;
        private int m_BehavPath = 0;

        private Ped[] m_Peds;
        private bool m_PedsFrozen = true;

        private Vehicle[] m_Vehicles;

        private Blip m_Blip;

        private bool m_InPursuit = false;
        private LHandle m_Pursuit;
        int m_Distance = 30;

        public override bool Start()
        {
            Log("Starting");

            Log("Finding closest posistion");

            m_Location = Location.GetClosestLocationInArray(Location.HomlessLocations, Game.LocalPlayer.Character.Position);
            if (Game.LocalPlayer.Character.Position.DistanceTo(Location.HomlessLocations[m_Location][0].Posistion) < 50)
            {
                Log("Distance check failed");
                return false;
            }

            Log("Location id: " + m_Location);

            Log("Adding small blip");
            m_Blip = ResourceManager.CreatBlip(Location.HomlessLocations[m_Location][0].Posistion, 0.75f);
            m_Blip.Color = System.Drawing.Color.Yellow;

            Log("Clearing area of peds and cars");

            foreach (Vehicle v in World.GetAllVehicles())
            {
                if (v.DistanceTo(Location.HomlessLocations[m_Location][0].Posistion) < 10 && v.Exists() && v != Game.LocalPlayer.LastVehicle)
                {
                    v.Delete();
                }
            }

            foreach (Ped p in World.GetAllPeds())
            {
                if (p.DistanceTo(Location.HomlessLocations[m_Location][0].Posistion) < 10 && p.Exists())
                {
                    if (p != Game.LocalPlayer.Character)
                        p.Delete();
                }
            }

            Log("Spawning peds and animations");

            int pedamount = Location.GetPedsCountInArray(Location.HomlessLocations[m_Location]);
            LocationItem[] pedlocations = Location.GetPedsInArray(Location.HomlessLocations[m_Location]);

            m_Peds = new Ped[pedamount];

            for (int i = 0; i < pedamount; i++)
            {
                m_Peds[i] = ResourceManager.CreatePed(Models.GetRandomHomless(), pedlocations[i].Posistion,
                    pedlocations[i].Rotation.Z);

                if (pedlocations[i].AnimName != "" && pedlocations[i].AnimDict != "")
                {
                    m_Peds[i].Tasks.PlayAnimation(pedlocations[i].AnimDict, pedlocations[i].AnimName, 1, AnimationFlags.Loop);
                }
                if (pedlocations[i].Frozen == true)
                {
                    m_Peds[i].IsPositionFrozen = true;
                }
            }

            Log("Setting ped items and personas");

            foreach (Ped p in m_Peds)
            {
                Wrapper.SetPedItems(p, SearchItems.GetRandomItemsYellowPed());
            }

            Log("Spawning vehicles");

            int vehicleamount = Location.GetVehiclesCountInArray(Location.HomlessLocations[m_Location]);
            LocationItem[] vehicle = Location.GetVehiclesInArray(Location.HomlessLocations[m_Location]);

            m_Vehicles = new Vehicle[vehicleamount];

            for (int i = 0; i < vehicleamount; i++)
            {
                m_Vehicles[i] = ResourceManager.CreateVehicle(vehicle[i].Model, vehicle[i].Posistion, vehicle[i].Rotation.Z);
            }

            Log("Setting up vehicles");

            foreach (Vehicle v in m_Vehicles)
            {
                int loop = Random.Next(1, 5);// = 4// 0<4 1<4 2<4 3<4 
                for (int i = 0; i < loop; i++)
                {
                    if (Random.Next(0, 2) == 1)
                        v.Windows[i].Smash();
                }

                NativeFunction.Natives.SET_VEHICLE_ALARM(v, true);
                v.AlarmTimeLeft = TimeSpan.FromHours(1) + TimeSpan.FromMilliseconds(Random.Next(0, 500));
            }

            Log("Setting behaviour path");

            //m_BehavPath = Random.Next(0, 3);//0,1,2
            m_BehavPath = Random.Next(0, 3);

            Log("Setting behaviour specific");


            Log("Done setting up");
            return true;
        }


        public override void Update()
        {
            base.Update();

            foreach (Vehicle v in m_Vehicles)
            {
                v.AlarmTimeLeft = TimeSpan.FromHours(1) + TimeSpan.FromMilliseconds(Random.Next(0, 500));
            }

            if (Game.LocalPlayer.LastVehicle.Exists())
                m_Distance = Game.LocalPlayer.LastVehicle.IsSirenOn ? 30 : 20;

            if (m_PedsFrozen && Game.IsKeyDownRightNow(System.Windows.Forms.Keys.E)
                && Game.LocalPlayer.Character.DistanceTo(Location.HomlessLocations[m_Location][0].Posistion) < 10)
            {
                m_PedsFrozen = false;
                foreach (Ped p in m_Peds)
                {
                    p.IsPositionFrozen = false;
                    p.Tasks.ClearImmediately();
                }
            }

            if (Game.LocalPlayer.Character.Position.DistanceTo(Location.HomlessLocations[m_Location][0].Posistion) > 100)
                End();

            switch (m_BehavPath)
            {
                default://Run

                    if (!m_InPursuit && Game.LocalPlayer.Character.DistanceTo(Location.HomlessLocations[m_Location][0].Posistion) < m_Distance)
                    {
                        m_InPursuit = true;
                        m_Pursuit = Functions.CreatePursuit();
                        m_Peds[2].IsPositionFrozen = false;

                        foreach (Ped p in m_Peds)
                        {
                            Functions.AddPedToPursuit(m_Pursuit, p);
                            PedPursuitAttributes attri = Functions.GetPedPursuitAttributes(p);
                            attri.HandlingAbility = (float)Random.NextDouble() + 0.5f;
                            attri.CanUseCars = false;
                        }

                        Functions.SetPursuitCopsCanJoin(m_Pursuit, true);
                        Functions.SetPursuitTacticsEnabled(m_Pursuit, true);
                        Functions.SetPursuitIsActiveForPlayer(m_Pursuit, true);
                    }

                    break;

                case 1://Stay



                    break;

                case 2://Some will run

                    if (!m_InPursuit && Game.LocalPlayer.Character.DistanceTo(Location.HomlessLocations[m_Location][0].Posistion) < m_Distance)
                    {
                        m_InPursuit = true;
                        m_Pursuit = Functions.CreatePursuit();

                        foreach (Ped p in m_Peds)
                        {
                            if (Random.Next(0, 4) == 2)
                            {
                                Functions.AddPedToPursuit(m_Pursuit, p);
                                PedPursuitAttributes attri = Functions.GetPedPursuitAttributes(p);
                                attri.HandlingAbility = (float)Random.NextDouble() + 0.5f;
                                attri.CanUseCars = false;
                            }
                        }

                        Functions.SetPursuitCopsCanJoin(m_Pursuit, true);
                        Functions.SetPursuitTacticsEnabled(m_Pursuit, true);
                        Functions.SetPursuitIsActiveForPlayer(m_Pursuit, true);
                    }

                    break;
            }
        }

        public override void End()
        {
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

            base.End();
        }
    }
}
