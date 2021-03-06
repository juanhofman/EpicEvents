﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using Rage.Native;
using LSPD_First_Response.Mod.API;
using LSPD_First_Response.Mod.Callouts;
using LSPD_First_Response.Engine.Scripting.Entities;

namespace EpicEvents
{
    public class Event
    {
        protected EventController EventController = Main.EventController;
        protected ResourceManager ResourceManager = Main.ResourceManager;
        protected Random Random = Main.Random;

        public virtual bool Start()
        {
            return false;
        }
        public virtual void Update()
        {
        }
        public virtual void End()
        {
            EventController.EndOfEvent();
        }

        protected void Log(string s)
        {
            Game.LogTrivialDebug("[EE] " + this.GetType().Name + ": " + s + ".");
        }
    }
}
