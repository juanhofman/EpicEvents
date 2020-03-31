using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicEvents
{
    public class Event
    {
        protected EventController EventController = Main.EventController;

        public Event()
        {
            EventController.RegisterEvent(this);
        }

        public virtual void Start()
        {
        }
        public virtual void Update()
        {
        }
        public virtual void End()
        {
        }
    }
}
