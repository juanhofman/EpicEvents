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
    class Shooting : Event
    {
        private int m_TimeoutTime = 60;
        private float m_TimeoutTimer = 0;

        private int m_MinDistance = 150;
        private int m_MaxDistnace = 300;

        private int m_MinPeds = 2;
        private int m_MaxPeds = 3;

        private float m_TimeBeforeEventTimer;

        private Vector3 m_EventPos;
        private Ped[] m_Peds;
        private Blip m_Blip;
        private LHandle m_Pursuit;

        private bool m_HasEventStarted = false;

        private int m_BehavPath = 0;

        public override bool Start()
        {
            Log("Finding posistion");
            m_EventPos = World.GetNextPositionOnStreet(Game.LocalPlayer.Character.Position.Around(Random.Next(m_MinDistance, m_MaxDistnace)));

            Log("Spawning peds");
            m_Peds = new Ped[Random.Next(m_MinPeds, m_MaxPeds + 1)];

            for (int i = 0; i < m_Peds.Length; i++)
            {
                m_Peds[i] = ResourceManager.CreatePed(m_EventPos);

                if (i == 0)
                    m_Peds[i].Tasks.Wander();
                else
                    m_Peds[i].Tasks.FollowToOffsetFromEntity(m_Peds[0], Vector3.RelativeBack * Random.Next(2, 15));
            }

            m_Blip = ResourceManager.CreatBlip(m_Peds[0].Position.Around(10), 120.0f);
            m_Blip.Alpha = 0.5f;
            m_Blip.Color = System.Drawing.Color.Yellow;

            Log("Time: " + Settings.ShootingWanderTime.ToString());

            return true;
        }


        public override void Update()
        {
            switch (m_BehavPath)
            {
                default://Shoot each other and run
                    #region default
                    if (!m_HasEventStarted)
                    {
                        m_TimeBeforeEventTimer += Game.FrameTime;
                    }

                    if (m_TimeBeforeEventTimer >= Settings.ShootingWanderTime && !m_HasEventStarted)//Stop wander start shoot
                    {
                        m_HasEventStarted = true;

                        ResourceManager.RemoveBlip(m_Blip);
                        m_Blip = ResourceManager.CreatBlip(m_Peds[0].Position.Around(2), 20.0f);
                        m_Blip.Alpha = 0.5f;
                        m_Blip.Color = System.Drawing.Color.Yellow;

                        for (int i = 0; i < m_Peds.Length; i++)
                        {
                            m_Peds[i].Inventory.GiveNewWeapon(WeaponHash.Pistol, 500, true);
                            if (i == 0)
                                m_Peds[i].Tasks.FireWeaponAt(m_Peds[1], Random.Next(5000, 10000), FiringPattern.BurstFire);
                            else
                                m_Peds[i].Tasks.FireWeaponAt(m_Peds[0], Random.Next(5000, 10000), FiringPattern.BurstFire);
                        }

                        GameFiber.StartNew(delegate
                        {
                            GameFiber.Sleep(15000);
                            m_Pursuit = Functions.CreatePursuit();

                            foreach (Ped p in m_Peds)
                            {
                                if (p.Exists())
                                {
                                    Functions.AddPedToPursuit(m_Pursuit, p);
                                    PedPursuitAttributes attri = Functions.GetPedPursuitAttributes(p);
                                    attri.HandlingAbility = (float)Random.NextDouble() + 0.5f;
                                }
                            }

                            Functions.SetPursuitCopsCanJoin(m_Pursuit, true);
                            Functions.SetPursuitTacticsEnabled(m_Pursuit, true);
                            Functions.SetPursuitIsActiveForPlayer(m_Pursuit, true);
                            GameFiber.Hibernate();
                        });
                    }

                    if (m_HasEventStarted)
                    {
                        m_TimeoutTimer += Game.FrameTime;
                        if (m_TimeoutTimer >= m_TimeoutTime && Game.LocalPlayer.Character.DistanceTo(m_Peds[0].Position) > 50 && AllPedsDead())
                        {
                            End();
                        }
                    }

                    break;
                #endregion

                case 1://Shoot at cop and run
                    #region 1
                    if (!m_HasEventStarted)
                    {
                        m_TimeBeforeEventTimer += Game.FrameTime;
                    }

                    if (m_TimeBeforeEventTimer >= Settings.ShootingWanderTime && !m_HasEventStarted)//Stop wander start shoot
                    {
                        m_HasEventStarted = true;

                        ResourceManager.RemoveBlip(m_Blip);
                        m_Blip = ResourceManager.CreatBlip(m_Peds[0].Position.Around(2), 20.0f);
                        m_Blip.Alpha = 0.5f;
                        m_Blip.Color = System.Drawing.Color.Yellow;

                        for (int i = 0; i < m_Peds.Length; i++)
                        {
                            m_Peds[i].Inventory.GiveNewWeapon(WeaponHash.Pistol, 12, true);
                            m_Peds[i].Tasks.FireWeaponAt(Game.LocalPlayer.Character, Random.Next(5000, 10000), FiringPattern.BurstFirePistol);

                        }

                        GameFiber.StartNew(delegate
                        {
                            GameFiber.Sleep(15000);
                            m_Pursuit = Functions.CreatePursuit();

                            foreach (Ped p in m_Peds)
                            {
                                if (p.Exists())
                                {
                                    Functions.AddPedToPursuit(m_Pursuit, p);
                                    PedPursuitAttributes attri = Functions.GetPedPursuitAttributes(p);
                                    attri.HandlingAbility = (float)Random.NextDouble() + 0.5f;
                                }
                            }

                            Functions.SetPursuitCopsCanJoin(m_Pursuit, true);
                            Functions.SetPursuitTacticsEnabled(m_Pursuit, true);
                            Functions.SetPursuitIsActiveForPlayer(m_Pursuit, true);
                            GameFiber.Hibernate();
                        });
                    }

                    if (m_HasEventStarted)
                    {
                        m_TimeoutTimer += Game.FrameTime;
                        if (m_TimeoutTimer >= m_TimeoutTime && Game.LocalPlayer.Character.DistanceTo(m_Peds[0].Position) > 50 && AllPedsDead())
                        {
                            End();
                        }
                    }
                    #endregion
                    break;

                case 2://Run
                    #region 2
                    if (!m_HasEventStarted)
                    {
                        m_TimeBeforeEventTimer += Game.FrameTime;
                    }

                    if (m_TimeBeforeEventTimer >= Settings.ShootingWanderTime && !m_HasEventStarted && 
                        Game.LocalPlayer.Character.DistanceTo(m_Peds[0].Position) < 50)//Stop wander start shoot
                    {
                        m_HasEventStarted = true;

                        ResourceManager.RemoveBlip(m_Blip);
                        m_Blip = ResourceManager.CreatBlip(m_Peds[0].Position.Around(2), 20.0f);
                        m_Blip.Alpha = 0.5f;
                        m_Blip.Color = System.Drawing.Color.Yellow;

                        for (int i = 0; i < m_Peds.Length; i++)
                        {
                            m_Peds[i].Inventory.GiveNewWeapon(WeaponHash.AssaultRifle, 12, true);
                        }

                        m_Pursuit = Functions.CreatePursuit();

                        foreach (Ped p in m_Peds)
                        {
                            if (p.Exists())
                            {
                                Functions.AddPedToPursuit(m_Pursuit, p);
                                PedPursuitAttributes attri = Functions.GetPedPursuitAttributes(p);
                                attri.HandlingAbility = (float)Random.NextDouble() + 0.5f;
                            }
                        }

                        Functions.SetPursuitCopsCanJoin(m_Pursuit, true);
                        Functions.SetPursuitTacticsEnabled(m_Pursuit, true);
                        Functions.SetPursuitIsActiveForPlayer(m_Pursuit, true);
                        GameFiber.Hibernate();
                    }

                    if (m_HasEventStarted)
                    {
                        m_TimeoutTimer += Game.FrameTime;
                        if (m_TimeoutTimer >= m_TimeoutTime && Game.LocalPlayer.Character.DistanceTo(m_Peds[0].Position) > 50 && AllPedsDead())
                        {
                            End();
                        }
                    }
                    #endregion
                    break;
            }

            if (Game.LocalPlayer.Character.DistanceTo(m_Peds[0]) > 400)
                End();
        }

        private bool AllPedsDead()
        {
            bool state = false;
            foreach (Ped p in m_Peds)
            {
                if (p.IsDead)
                    state = true;
            }
            return state;
        }

        public override void End()
        {
            foreach (Ped p in m_Peds)
            {
                ResourceManager.RemovePed(p);
            }
            m_Peds = null;

            ResourceManager.RemoveBlip(m_Blip);
            m_Blip = null;

            base.End();
        }
    }
}