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
        public static ResourceManager ResourceManager;
        public static Settings Settings;
        public static Random Random;

        public override void Initialize()
        {
            Game.LogTrivial("[EE] Initializing. version:  0.2.0");
            Game.DisplayNotification("Epic events: version 0.2.0");

            Random = new Random();
            Settings = new Settings();

            EventController = new EventController();
            ResourceManager = new ResourceManager();

            if (Settings.DrugDealerEventEnabled)
            {
                for (int i = 0; i < Settings.DrugDealerEventProbability; i++)
                {
                    EventController.RegisterEvent(typeof(Events.DrugDealer));
                }
            }

            if (Settings.HomelessEventEnabled)
            {
                for (int i = 0; i < Settings.HomelessEventProbability; i++)
                {
                    EventController.RegisterEvent(typeof(Events.HomlessDisturbance));
                }
            }

            if(Settings.ShootingEventEnabled)
            {
                for (int i = 0; i < Settings.ShootingEventProbability; i++)
                {
                    EventController.RegisterEvent(typeof(Events.Shooting));
                }
            }
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
            else
            {
                EventController.StopEvents();
            }
        }

        private void StopEvents()
        {
            EventController.StopEvents();
        }
    }
}