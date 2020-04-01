﻿using LSPD_First_Response;
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
        public static ResourceManager ResourceManager;
        public static Random Random;

        public override void Initialize()
        {
            Game.LogTrivial("[EE] Initializing.");

            EventController = new EventController();
            ResourceManager = new ResourceManager();
            Random = new Random();

            Functions.OnOnDutyStateChanged += StartEvents;

            Game.LogTrivial("[EE] Initialized.");
        }

        public override void Finally()
        {
            if (EventController != null)
            {
                Game.LogTrivial("[EE] Stopping.");
                ResourceManager.RemoveAll();
                StopEvents();
                Game.LogTrivial("[EE] Stopped.");
            }
        }

        private void StartEvents(bool state)
        {
            if (state)
            {
                Game.LogTrivial("[EE] Starting events.");
                EventController.StartEvents();
                Game.LogTrivial("[EE] Started events.");
            }
        }

        private void StopEvents()
        {
            EventController.StopEvents();
        }
    }
}