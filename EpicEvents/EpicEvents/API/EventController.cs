using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rage;


namespace EpicEvents
{
    public class EventController
    {
        public Random Random = Main.Random;
        private List<Type> m_Events;
        private bool m_Looping = false;

        public EventController()
        {
            Game.LogTrivial("[EE] EventController Initializing.");
            m_Events = new List<Type>();
            Game.LogTrivial("[EE] EventController Initialized.");
        }

        public void StartEvents()
        {
            Game.LogTrivial("[EE] EvenController Starting.");
            m_Looping = true;
            EventLoop();
            Game.LogTrivial("[EE] EvenController Started.");
        }

        public void StopEvents(bool hard = false)
        {
            if (hard)
            {
                if (m_ActiveEvent != null)
                {
                    m_ActiveEvent.End();
                    m_ActiveEvent = null;
                }
            }
            else
            {
                m_Generating = false;
            }
        }

        public void SetSpecificEvent(Type type)
        {
            if(m_ActiveEvent == null)
            {
                Event e = (Event)Activator.CreateInstance(type);
                bool ev = e.Start();
                if (ev)
                {
                    m_ActiveEvent = e;
                }
            }
            else if(m_ActiveEvent.GetType() != typeof(Type))
            {
                m_ActiveEvent.End();

                Event e = (Event)Activator.CreateInstance(type);
                bool ev = e.Start();
                if (ev)
                {
                    m_ActiveEvent = e;
                }
            }
            else
            {
                m_ActiveEvent.End();
                m_ActiveEvent = null;
            }
        }

        public void EndOfEvent()
        {
            m_ActiveEvent = null;
        }

        public void RegisterEvent(Type eventtype)
        {
            m_Events.Add(eventtype);
        }

        private bool m_Generating = false;
        private Event m_ActiveEvent = null;

        private int m_MinTimeBetween = 100;
        private int m_MaxTimeBetween = 500;
        
        private float m_TimeBetween = 0;
        private float m_TimeBetweenTimer = 0;

        private void EventLoop()
        {
            m_Looping = true;
            m_Generating = true;

            GameFiber.StartNew(delegate
            {
                Game.LogTrivial("[EE] EvenController Starting thread #2.");
                while (m_Looping)
                {
                    if (Game.IsKeyDown(Keys.F7) && !Game.IsAltKeyDownRightNow)
                    {
                        SetSpecificEvent(typeof(Events.Shooting));
                    }

                    if(Game.IsKeyDown(Keys.F7) && Game.IsAltKeyDownRightNow)
                    {
                        Main.ResourceManager.RemoveAll();
                    }

                    if (m_ActiveEvent == null)
                    {
                        if (!m_Generating)
                        {
                            m_Looping = false;
                            Game.LogTrivial("[EE] EvenController stopping thread #2");
                            GameFiber.Hibernate();
                        }
                        else
                        {
                            //generate new events.
                            if(m_TimeBetween == 0)
                            {
                                m_TimeBetween = Random.Next(m_MinTimeBetween, m_MaxTimeBetween);
                            }

                            if(m_TimeBetweenTimer >= m_TimeBetween)//gen event
                            {
                                Type type = m_Events[Random.Next(0,m_Events.Count)];
                                Event e = (Event)Activator.CreateInstance(type);

                                bool ev = e.Start();
                                if (ev)
                                {
                                    m_ActiveEvent = e;
                                }

                                m_TimeBetweenTimer = 0;
                            }
                            else
                            {
                                m_TimeBetweenTimer += Game.FrameTime;
                            }

                        }
                    }
                    else
                    {
                        m_ActiveEvent.Update();

                        if (Game.IsKeyDownRightNow(Keys.End))
                        {
                            m_ActiveEvent.End();
                            m_ActiveEvent = null;
                        }
                    }

                    GameFiber.Yield();
                }
                GameFiber.Yield();
            });
        }
    }
}
