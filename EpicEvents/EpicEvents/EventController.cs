using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicEvents
{
    public class EventController
    {
        private List<Event> m_Events;

        public EventController()
        {
            m_Events = new List<Event>();
        }

        public void StartEvents()
        {

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
    }
}
