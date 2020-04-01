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
        private List<Event> m_Events;
        private bool m_Looping = false;

        public EventController()
        {
            Game.LogTrivial("[EE] EventController Initializing.");
            m_Events = new List<Event>();
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

            }
            else
            {

            }
        }

        public void RegisterEvent(Event eventtype)
        {
            m_Events.Add(eventtype);
        }

        private bool m_IsEventActive = false;
        private Event m_ActiveEvent = null;


        private void EventLoop()
        {
            Game.LogTrivial("[EE] EvenController Starting loop.");
            m_Looping = true;
            GameFiber.StartNew(delegate
            {
                Game.LogTrivial("[EE] EvenController Starting thread #2.");
                while (m_Looping)
                {
                    if (Game.IsKeyDown(Keys.F5))
                    {
                        if (m_IsEventActive)
                        {
                            m_ActiveEvent.End();
                            m_IsEventActive = false;
                        }
                        else
                        {
                            m_ActiveEvent = new Events.DrugDealer();
                            m_ActiveEvent.Start();
                            m_IsEventActive = true;
                        }
                    }

                    if(Game.IsKeyDown(Keys.F6) && m_IsEventActive)
                    {
                        m_ActiveEvent.End();
                        m_IsEventActive = false;
                    }

                    if (m_IsEventActive)
                    {
                        m_ActiveEvent.Update();
                        GameFiber.Yield();
                    }

                    GameFiber.Yield();
                }
                GameFiber.Yield();
            });
        }
    }
}
