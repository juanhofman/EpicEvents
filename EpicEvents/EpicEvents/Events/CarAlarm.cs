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
    class CarAlarm : Event
    {

        public override bool Start()
        {
            


            return true;
        }


        public override void Update()
        {

        }

        public override void End()
        {
            

                base.End();
        }
    }
}
