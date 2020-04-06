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
        private HomlessDisturbanceLocations[] m_Locations = new HomlessDisturbanceLocations[]
        {
            new HomlessDisturbanceLocations(
                new EVector3(new Vector3(-787.0f,-198.8f,37.0f), 115.2f),
                new EVector3(new Vector3(-790.8f,-190.6f,37.2f),79.5f),
                new List<EVector3>()
                {
                    new EVector3(new Vector3(-797.2f, -197.0f, 37.3f), 19.1f),
                    new EVector3(new Vector3(-793.7f, -199.4f, 37.2f), -21.2f),
                    new EVector3(new Vector3(-786.1f, -198.3f, 38.8f), -67.1f),
                    new EVector3(new Vector3(-789.1f, -192.7f, 37.3f), 125.3f),
                    new EVector3(new Vector3(-790.0f, -194.0f, 37.3f), 45.5f)
                },
                new List<EVector3>
                {
                    new EVector3(new Vector3(-791.3f, -193.1f, 36.4f), -25.2f),
                    new EVector3(new Vector3(-791.2f, -192.2f, 36.4f), -31.5f),
                    new EVector3(new Vector3(-787.4f, -196.9f, 36.4f), -112.9f),
                    new EVector3(new Vector3(-785.9f, -197.8f, 38.2f), -156.2f),
                    new EVector3(new Vector3(-792.0f, -199.9f, 36.3f), -173.4f),
                    new EVector3(new Vector3(-791.9f, -199.6f, 36.2f), -169.4f),
                    new EVector3(new Vector3(-792.5f, -199.8f, 36.3f), 174.6f),
                    new EVector3(new Vector3(-792.6f, -199.5f, 36.3f), 170.6f),
                    new EVector3(new Vector3(-788.1f, -197.4f, 36.2f), -132.0f)
                },
                new EVector3(new Vector3(-787.1f, -191.9f, 37.4f), 122.2f),
                new EVector3(new Vector3(-782.6f, -198.5f, 36.8f), 167.9f),
                new EVector3(new Vector3(-788.8f, -194.9f, 36.8f), 100.6f)
                )};

        private int m_Location = 0;
        private int m_BehavPath = 0;

        Ped[] m_Peds;

        Vehicle m_Vehicle1;
        Vehicle m_Vehicle2;

        public override void Start()
        {
            base.Start();

            Log("Starting");

            Log("Clearing area of peds and cars");

            foreach (Vehicle v in World.GetAllVehicles())
            {
                if (v.DistanceTo(m_Locations[m_Location].Car1.Vector3) < 10 && v.Exists() && v != Game.LocalPlayer.LastVehicle)
                {
                    v.Delete();
                }
            }

            foreach (Ped p in World.GetAllPeds())
            {
                if (p.DistanceTo(m_Locations[m_Location].Car1.Vector3) < 10 && p.Exists())
                {
                    p.Delete();
                }
            }

            Log("Spawning peds and animations");

            m_Peds = new Ped[m_Locations[m_Location].Bums.Count];

            for (int i = 0; i < m_Locations[m_Location].Bums.Count; i++)
            {
                m_Peds[i] = ResourceManager.CreatePed(m_Locations[m_Location].Bums[i].Vector3, m_Locations[m_Location].Bums[i].Heading);
            }

            foreach (Ped p in m_Peds)
            {
                AnimationType anim;
                anim = Animation.GetRandomIdleAnimation();

                p.Tasks.PlayAnimation(anim.Dictionary, anim.Animation, 1, AnimationFlags.Loop);
            }

            Log("Setting ped items and personas");

            foreach (Ped p in m_Peds)
            {
                Wrapper.SetPedItems(p, SearchItems.GetRandomItemsYellowPed());
            }

            Log("Spawning vehicles");

            m_Vehicle1 = ResourceManager.CreateVehicle("Cavalcade", m_Locations[m_Location].Car1.Vector3, m_Locations[m_Location].Car1.Heading);
            m_Vehicle2 = ResourceManager.CreateVehicle("Gresley", m_Locations[m_Location].Car2.Vector3, m_Locations[m_Location].Car2.Heading);

            Log("Setting up vehicles");

            m_Vehicle1.Windows[0].Smash();
            m_Vehicle1.Windows[1].Smash();

            m_Vehicle2.Windows[0].Smash();
            m_Vehicle2.Windows[2].Smash();

            NativeFunction.Natives.SET_VEHICLE_ALARM(m_Vehicle1, true);
            NativeFunction.Natives.SET_VEHICLE_ALARM(m_Vehicle2, true);

            m_Vehicle1.AlarmTimeLeft = TimeSpan.FromHours(1);
            m_Vehicle2.AlarmTimeLeft = TimeSpan.FromHours(1);

            Log("Setting behaviour path");

            //m_BehavPath = Random.Next(0, 3);//0,1,2
            m_BehavPath = 0;

            Log("Setting behaviour specific");


            Log("Done setting up");
        }

        public override void Update()
        {
            base.Update();

            m_Vehicle1.AlarmTimeLeft = TimeSpan.FromHours(1);
            m_Vehicle2.AlarmTimeLeft = TimeSpan.FromHours(1);

            switch (m_BehavPath)
            {
                 default:
                    break;
            }
        }

        public override void End()
        {
            base.End();

            foreach(Ped p in m_Peds)
            {
                ResourceManager.RemovePed(p);
            }

            m_Peds = null;

            ResourceManager.RemoveVehicle(m_Vehicle1);
            ResourceManager.RemoveVehicle(m_Vehicle2);

            m_Vehicle1 = null;
            m_Vehicle2 = null;
        }
    }

    public struct HomlessDisturbanceLocations
    {
        public EVector3 Car1;
        public EVector3 Car2;

        public List<EVector3> Bums;

        public List<EVector3> Bottles;
        public EVector3 ProtestSign;
        public EVector3 Trolly1;
        public EVector3 Trolly2;

        public HomlessDisturbanceLocations(EVector3 car1, EVector3 car2, List<EVector3> bums, List<EVector3> bottles, EVector3 protestSign, EVector3 trolly1, EVector3 trolly2)
        {
            Car1 = car1;
            Car2 = car2;
            Bums = bums;
            Bottles = bottles;
            ProtestSign = protestSign;
            Trolly1 = trolly1;
            Trolly2 = trolly2;
        }
    }
}
