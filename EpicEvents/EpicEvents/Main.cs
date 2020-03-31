using LSPD_First_Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rage;
using Rage.Native;
using LSPD_First_Response.Mod.API;
using LSPD_First_Response.Mod.Callouts;
using LSPD_First_Response.Engine.Scripting.Entities;

namespace EpicEvents
{
    public class Main : Plugin
    {
        public static EventController EventController;

        public override void Initialize()
        {
            EventController = new EventController();
            Functions.PlayerWentOnDutyFinishedSelection += StartEvents;
        }

        public override void Finally()
        {
            if(EventController != null)
            {
                StopEvents();
            }
        }

        private void StartEvents()
        {
            EventController.StartEvents();
        }

        private void StopEvents()
        {
            EventController.StopEvents();
        }
    }
}