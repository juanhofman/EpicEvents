using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EpicEvents
{
    public class Settings
    {
        public static int MinTimeBetweenEvents = 100;
        public static int MaxTimeBetweenEvents = 400;

        public static bool DrugDealerEventEnabled = true;
        public static bool HomelessEventEnabled = true;
        public static bool ShootingEventEnabled = true;

        public static int DrugDealerEventProbability = 1;
        public static int HomelessEventProbability = 1;
        public static int ShootingEventProbability = 1;

        public static int ShootingWanderTime = 30;

        public static bool SpawnDetails = false;
        public static bool SendData = true;
        public static bool DispatchNotify = true;

        enum EventSettings { DrugDealer, Homeless, Shooting};

        public Settings()
        {
            string FilePath = @"G:\Projecten\EpicEvents\EpicEvents\EpicEvents\API\EpicEvents.xml";

            EventSettings currentsetting = EventSettings.DrugDealer;

            try
            {

                using (XmlReader reader = XmlReader.Create(FilePath))
                {
                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            switch (reader.Name)
                            {
                                case "DispatchMessage":
                                    Game.LogTrivial("[EE] Setting dispatch.");
                                    DispatchNotify = bool.Parse(reader.ReadInnerXml());
                                    break;

                                case "MinTimeBetweenEvents":
                                    Game.LogTrivial("[EE] Setting minimal time between events.");
                                    MinTimeBetweenEvents = int.Parse(reader.ReadInnerXml());
                                    break;

                                case "MaxTimeBetweenEvents":
                                    Game.LogTrivial("[EE] Setting maximum time between events.");
                                    MaxTimeBetweenEvents = int.Parse(reader.ReadInnerXml());
                                    break;

                                case "EnableDetailSpawning":
                                    Game.LogTrivial("[EE] Setting detail spawning.");
                                    SpawnDetails = bool.Parse(reader.ReadInnerXml());
                                    break;

                                case "EventEnabled":
                                    switch (currentsetting)
                                    {
                                        case EventSettings.DrugDealer:
                                            Game.LogTrivial("[EE] Setting drugdealer enabled.");
                                            DrugDealerEventEnabled = bool.Parse(reader.ReadInnerXml());
                                            break;
                                        case EventSettings.Homeless:
                                            Game.LogTrivial("[EE] Setting homeless enabled.");
                                            HomelessEventEnabled = bool.Parse(reader.ReadInnerXml());
                                            break;
                                        case EventSettings.Shooting:
                                            Game.LogTrivial("[EE] Setting homeless enabled.");
                                            ShootingEventEnabled = bool.Parse(reader.ReadInnerXml());
                                            break;
                                    }
                                    break;

                                case "EventProbability":
                                    switch (currentsetting)
                                    {
                                        case EventSettings.DrugDealer:
                                            Game.LogTrivial("[EE] Setting prob drugdealer.");
                                            DrugDealerEventProbability = int.Parse(reader.ReadInnerXml());
                                            break;
                                        case EventSettings.Homeless:
                                            Game.LogTrivial("[EE] Setting prob homeless.");
                                            HomelessEventProbability = int.Parse(reader.ReadInnerXml());
                                            break;
                                        case EventSettings.Shooting:
                                            Game.LogTrivial("[EE] Setting prob shooting.");
                                            ShootingEventProbability = int.Parse(reader.ReadInnerXml());
                                            break;
                                    }
                                    break;

                                case "MinWanderTime":
                                    Game.LogTrivial("[EE] Setting wander time.");
                                    ShootingWanderTime = int.Parse(reader.ReadInnerXml());
                                    break;

                                case "SendData":
                                    Game.LogTrivial("[EE] Setting send data.");
                                    SendData = bool.Parse(reader.ReadInnerXml());
                                    break;

                                case "DrugDealerSettings":
                                    currentsetting = EventSettings.DrugDealer;
                                    break;

                                case "HomelessSettings":
                                    currentsetting = EventSettings.Homeless;
                                    break;

                                case "ShootingSettings":
                                    currentsetting = EventSettings.Shooting;
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Game.DisplayNotification("EpicEvents: " + e + " assigning default settings.");
                Game.LogTrivial(e.ToString());
            }
        }
    }
}
