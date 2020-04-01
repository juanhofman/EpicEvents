using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicEvents
{
    public static class SearchItems
    {
        public static Random Random = Main.Random;

        #region Peds

        /// <summary>
        /// Get fully legal items.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static string GetRandomItemsGreenPed(int items = 4)
        {
            if (items <= 0)
                return null;

            string s = "";
            int count = items;

            for (int i = 0; i < count; i++)
            {
                s += m_GreenPed[Random.Next(0, m_GreenPed.Length)];
                if (i != count - 1)
                {
                    s += ", ";
                }
            }
            return s;
        }

        /// <summary>
        /// Get gray area items, like kitchen knifes and pils.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static string GetRandomItemsYellowPed(int items = 5)
        {
            if (items <= 0)
                return null;

            string s = "";
            int count = items;

            if (count <= 2)
            {
                for (int i = 0; i < count; i++)
                {
                    s += m_YellowPed[Random.Next(0, m_YellowPed.Length)];
                    if (i != count - 1)
                    {
                        s += ", ";
                    }
                }
            }
            else
            {
                count -= 2;
                for (int i = 0; i < 2; i++)
                {
                    s += m_YellowPed[Random.Next(0, m_YellowPed.Length)];
                    s += ", ";
                }

                for (int i = 0; i < count; i++)
                {
                    s += m_GreenPed[Random.Next(0, m_GreenPed.Length)];
                    if (i != count - 1)
                    {
                        s += ", ";
                    }
                }
            }

            return s;
        }

        /// <summary>
        /// Get green area items, like guns and drugs.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static string GetRandomItemsRedPed(int items = 3)
        {
            if (items <= 0)
                return null;

            string s = "";
            int count = items;

            if (count <= 2)
            {
                for (int i = 0; i < count; i++)
                {
                    s += m_RedPed[Random.Next(0, m_RedPed.Length)];
                    if (i != count - 1)
                    {
                        s += ", ";
                    }
                }
            }
            else
            {
                count -= 2;
                for (int i = 0; i < 2; i++)
                {
                    s += m_RedPed[Random.Next(0, m_RedPed.Length)];
                    s += ", ";
                }

                count -= 1;
                s += m_YellowPed[Random.Next(0, m_YellowPed.Length)];
                if (count != 0)
                {
                    s += ", ";
                }

                for (int i = 0; i < count; i++)
                {
                    s += m_GreenPed[Random.Next(0, m_GreenPed.Length)];
                    if (i != count - 1)
                    {
                        s += ", ";
                    }
                }
            }

            return s;
        }

        private static string[] m_GreenPed = new string[]
        {
            "~g~wallet~s~","~g~phone~s~","~g~pens~s~","~g~sigarettes~s~","~g~money~s~","~g~credit card~s~","~g~bookstore card~s~","~g~water~s~"
        };
        private static string[] m_YellowPed = new string[]
        {
            "~y~pocket knife~s~","~y~small bag of weed~s~","~y~crowbar~s~","~y~screwdriver~s~"
        };
        private static string[] m_RedPed = new string[]
        {
            "~r~handgun~s~","~r~automatic pistol~s~","~r~handgun with a scratched serial~s~","~r~handgun modified to fire automatic~s~"
        };

        #endregion

        #region Vehicles

        /// <summary>
        /// Get fully legal items.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static string GetRandomItemsGreenVehicles(int items = 4)
        {
            if (items <= 0)
                return null;

            string s = "";
            int count = items;

            for (int i = 0; i < count; i++)
            {
                s += m_GreenVehicles[Random.Next(0, m_GreenVehicles.Length)];
                if (i != count - 1)
                {
                    s += ", ";
                }
            }
            return s;
        }

        /// <summary>
        /// Get gray area items, like kitchen knifes and pils.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static string GetRandomItemsYellowVehicles(int items = 5)
        {
            if (items <= 0)
                return null;

            string s = "";
            int count = items;

            if (count <= 2)
            {
                for (int i = 0; i < count; i++)
                {
                    s += m_YellowVehicles[Random.Next(0, m_YellowVehicles.Length)];
                    if (i != count - 1)
                    {
                        s += ", ";
                    }
                }
            }
            else
            {
                count -= 2;
                for (int i = 0; i < 2; i++)
                {
                    s += m_YellowVehicles[Random.Next(0, m_YellowVehicles.Length)];
                    s += ", ";
                }

                for (int i = 0; i < count; i++)
                {
                    s += m_GreenVehicles[Random.Next(0, m_GreenVehicles.Length)];
                    if (i != count - 1)
                    {
                        s += ", ";
                    }
                }
            }

            return s;
        }

        /// <summary>
        /// Get green area items, like guns and drugs.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static string GetRandomItemsRedVehicles(int items = 3)
        {
            if (items <= 0)
                return null;

            string s = "";
            int count = items;

            if (count <= 2)
            {
                for (int i = 0; i < count; i++)
                {
                    s += m_RedVehicles[Random.Next(0, m_RedVehicles.Length)];
                    if (i != count - 1)
                    {
                        s += ", ";
                    }
                }
            }
            else
            {
                count -= 2;
                for (int i = 0; i < 2; i++)
                {
                    s += m_RedVehicles[Random.Next(0, m_RedVehicles.Length)];
                    s += ", ";
                }

                count -= 1;
                s += m_YellowVehicles[Random.Next(0, m_YellowVehicles.Length)];
                if (count != 0)
                {
                    s += ", ";
                }

                for (int i = 0; i < count; i++)
                {
                    s += m_GreenVehicles[Random.Next(0, m_GreenVehicles.Length)];
                    if (i != count - 1)
                    {
                        s += ", ";
                    }
                }
            }

            return s;
        }

        private static string[] m_GreenVehicles = new string[]
        {
            "~g~wallet~s~","~g~phone~s~","~g~pens~s~","~g~sigarettes~s~","~g~money~s~","~g~credit cards~s~","~g~bookstore card~s~","~g~water~s~"
        };
        private static string[] m_YellowVehicles = new string[]
        {
            "~y~pocket knife~s~","~y~small bag of weed~s~","~y~crowbar~s~","~y~screwdriver~s~"
        };
        private static string[] m_RedVehicles = new string[]
        {
            "~r~handgun~s~","~r~automatic pistol~s~","~r~handgun with a scratched serial~s~","~r~handgun modified to full fire automatic~s~",
            "~r~assault rifle modified to fire full automatic~s~", "~r~assault rifle~s~","~r~assault rifle with a scratched serial~s~",
            "~r~bucket of bullets~s~"
        };

        #endregion
    }
}
