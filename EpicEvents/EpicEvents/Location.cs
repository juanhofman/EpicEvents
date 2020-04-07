using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicEvents
{
    public static class Location
    {
        public enum ObjectType
        {
            Ped = 1, Vehicle, Object
        }

        public static int GetPedsCountInArray(LocationItem[] item)
        {
            int i = 0;
            foreach (LocationItem l in item)
            {
                if (l.Type == ObjectType.Ped)
                    i++;
            }
            return i;
        }
        public static int GetVehiclesCountInArray(LocationItem[] item)
        {
            int i = 0;
            foreach (LocationItem l in item)
            {
                if (l.Type == ObjectType.Vehicle)
                    i++;
            }
            return i;
        }
        public static int GetObjectsCountInArrau(LocationItem[] item)
        {
            int i = 0;
            foreach (LocationItem l in item)
            {
                if (l.Type == ObjectType.Object)
                    i++;
            }
            return i;
        }
        public static LocationItem[] GetPedsInArray(LocationItem[] item)
        {
            List<LocationItem> items = new List<LocationItem>();
            for (int i = 0; i < item.Length; i++)
            {
                if (item[i].Type == ObjectType.Ped)
                    items.Add(item[i]);
            }
            return items.ToArray();
        }
        public static LocationItem[] GetVehiclesInArray(LocationItem[] item)
        {
            List<LocationItem> items = new List<LocationItem>();
            for (int i = 0; i < item.Length; i++)
            {
                if (item[i].Type == ObjectType.Vehicle)
                    items.Add(item[i]);
            }
            return items.ToArray();
        }
        public static LocationItem[] GetObjectsInArray(LocationItem[] item)
        {
            List<LocationItem> items = new List<LocationItem>();
            for (int i = 0; i < item.Length; i++)
            {
                if (item[i].Type == ObjectType.Object)
                    items.Add(item[i]);
            }
            return items.ToArray();
        }
        public static int GetClosestLocationInArray(LocationItem[][] item, Vector3 location)
        {
            float distance = float.MaxValue;
            int index = 0;

            for (int i = 0; i < item.GetLength(0); i++)
            {
                if (location.DistanceTo(item[i][0].Posistion) < distance)
                {
                    distance = location.DistanceTo(item[i][0].Posistion);
                    index = i;
                }
            }

            return index;
        }
        public static Vector3 GetNextPosistionOnSidewalk(Vector3 around, float min, float max)
        {
            return new Vector3();
        }


        public static LocationItem[][] HomlessLocations = new LocationItem[9][]
        {
            new LocationItem[]
            {
                new LocationItem(-787.053894f, -198.843399f, 37.0953369f, 0.000349821727f, 0.160985678f, 115.264412f, "", "", false, 0x779f23aa, (ObjectType)2),
                new LocationItem(-790.835083f, -190.555313f, 37.2145462f, 0.130138233f, 0.09372098f, 79.5388336f, "", "", false, 0xa3fc0f4d, (ObjectType)2),
                new LocationItem(-787.198669f, -197.030823f, 37.2818336f, 0.0345403552f, 0.302632362f, 19.1417198f, "amb@world_human_bum_slumped@male@laying_on_left_side@base", "base", false, 0x4705974a, (ObjectType)1),
                new LocationItem(-793.685852f, -199.408127f, 37.2816811f, -0f, 0f, -21.2219582f, "switch@trevor@scares_tramp", "trev_scares_tramp_idle_tramp", false, 0x1ec93fd0, (ObjectType)1),
                new LocationItem(-786.124817f, -198.297974f, 37.7381134f, -0f, 4.2688751e-07f, -67.1325607f, "savecouch@", "t_sleep_loop_couch", true, 0x174d4245, (ObjectType)1),
                new LocationItem(-789.091431f, -192.740097f, 37.2836342f, 7.04374406e-11f, -4.60734728e-10f, 125.257164f, "amb@world_human_bum_standing@depressed@base", "base", false, 0x6a8f1f9b, (ObjectType)1),
                new LocationItem(-790.062439f, -194.077789f, 37.2836418f, -0f, 0f, 45.4848595f, "amb@medic@standing@kneel@idle_a", "idle_a", false, 0x48f96f5b, (ObjectType)43),
                new LocationItem(-791.297974f, -193.121307f, 36.4241257f, 0f, 0f, -25.2142849f, "", "", true, 0xbc22517f, (ObjectType)3),
                new LocationItem(-791.185425f, -193.165909f, 36.4241257f, 0f, 0f, -31.4504623f, "", "", true, 0xbc22517f, (ObjectType)3),
                new LocationItem(-787.387329f, -196.899567f, 36.4241257f, -0f, 0f, -112.866402f, "", "", true, 0x2e23bce7, (ObjectType)3),
                new LocationItem(-785.947571f, -197.800369f, 38.1823692f, -0f, 0f, -156.170578f, "", "", true, 0x3256c688, (ObjectType)3),
                new LocationItem(-792.006958f, -199.969421f, 36.3073654f, -0f, 0f, -173.409348f, "", "", true, 0x417e64d7, (ObjectType)3),
                new LocationItem(-791.909607f, -199.639984f, 36.2837105f, -0f, 0f, -169.424942f, "", "", true, 0x417e64d7, (ObjectType)3),
                new LocationItem(-792.456604f, -199.782013f, 36.2837105f, -0f, 0f, 174.63797f, "", "", true, 0x3256c688, (ObjectType)3),
                new LocationItem(-792.568542f, -199.56601f, 36.2837105f, -0f, 0f, 170.566971f, "", "", true, 0x3256c688, (ObjectType)3),
                new LocationItem(-788.118164f, -197.362076f, 36.2836952f, -0f, 0f, -132.006424f, "", "", true, 0xf84fdd9c, (ObjectType)3),
                new LocationItem(-791.119202f, -192.559677f, 36.2907524f, 0f, 0f, -28.5880833f, "", "", true, 0x1a6321c6, (ObjectType)3),
                new LocationItem(-790.336914f, -191.755463f, 36.2907524f, 0f, 0f, -33.7848434f, "", "", true, 0x1a6321c6, (ObjectType)3),
                new LocationItem(-789.371948f, -192.882874f, 36.4535599f, 0f, 0f, -54.6583977f, "", "", true, 0xb27096d5, (ObjectType)3),
                new LocationItem(-787.907654f, -193.655548f, 36.7128296f, 0f, 0f, -63.1462708f, "", "", true, 0x2571cda2, (ObjectType)3),
                new LocationItem(-787.407959f, -193.387924f, 36.7128296f, 0f, 0f, 48.4129791f, "", "", true, 0x2571cda2, (ObjectType)3),
                new LocationItem(-784.566223f, -197.590546f, 36.342968f, -0f, 0f, 147.151886f, "", "", true, 0x684a97ae, (ObjectType)3),
                new LocationItem(-784.596252f, -197.510284f, 36.342968f, -0f, 0f, 146.199066f, "", "", true, 0x684a97ae, (ObjectType)3),
                new LocationItem(-787.158691f, -196.757248f, 36.342968f, -0f, 0f, -153.951263f, "", "", true, 0x684a97ae, (ObjectType)3),
                new LocationItem(-789.32782f, -197.77298f, 36.5554504f, -0f, 0f, 127.921761f, "", "", true, 0xaf0dd721, (ObjectType)3),
                new LocationItem(-787.051453f, -191.899719f, 37.4098053f, -0f, 0f, 122.201424f, "", "", true, 0xb856d4ce, (ObjectType)3),
                new LocationItem(-787.687866f, -197.69429f, 36.291317f, -0f, 0f, 159.788315f, "", "", true, 0xaffe1f5a, (ObjectType)3),
                new LocationItem(-787.789856f, -197.480087f, 36.3028069f, -0f, 0f, -131.437576f, "", "", true, 0xf3565180, (ObjectType)3),
                new LocationItem(-789.227051f, -197.576492f, 36.8463707f, -0f, 0f, -147.807083f, "", "", true, 0xf3565180, (ObjectType)3),
                new LocationItem(-789.489807f, -197.78096f, 36.8383293f, -0f, 0f, -93.8425217f, "", "", true, 0x8a154872, (ObjectType)3),
                new LocationItem(-787.184448f, -197.32193f, 36.3391037f, -0f, 0f, -125.455093f, "", "", true, 0xe6cb661e, (ObjectType)3),
                new LocationItem(-787.658081f, -197.090988f, 36.2939606f, -0f, 0f, -146.675018f, "", "", true, 0xd6aa6804, (ObjectType)3),
                new LocationItem(-789.262329f, -197.77034f, 36.8372307f, -0f, 0f, 144.899277f, "", "", true, 0x207cec12, (ObjectType)3),
                new LocationItem(-789.365417f, -197.788284f, 36.8372307f, -0f, 0f, 140.56842f, "", "", true, 0x207cec12, (ObjectType)3),
                new LocationItem(-788.932556f, -197.148941f, 36.3135529f, -0f, 0f, -95.3131332f, "", "", true, 0x26e7fcb1, (ObjectType)3),
                new LocationItem(-782.604919f, -198.534927f, 36.7905655f, -0f, 0f, 167.878067f, "", "", true, 0x72574963, (ObjectType)3),
                new LocationItem(-788.752747f, -194.973785f, 36.7909889f, -0f, 0f, 100.578003f, "", "", true, 0xf249c94a, (ObjectType)3)
            },
            new LocationItem[]
            {
                new LocationItem(-1515.95154f, -545.348206f, 32.7866669f, -1.05849147f, -0.129584238f, -143.681244f, "", "", false, 0x8f0e3594, (ObjectType)2),
                new LocationItem(-1517.37134f, -545.741699f, 33.1099663f, -0f, 0f, 131.586273f, "amb@world_human_bum_standing@drunk@idle_a", "idle_a", false, 0x8ca0c266, (ObjectType)1),
                new LocationItem(-1519.8136f, -545.926025f, 33.144146f, -0f, 0f, -164.8069f, "amb@world_human_bum_slumped@male@laying_on_left_side@base", "base", false, 0x8ca0c266, (ObjectType)1)
            },
            new LocationItem[]
            {
                new LocationItem(-1079.70862f, -1049.97278f, 1.4900949f, 0.001744785f, 0.0471368283f, -147.643356f, "", "", false, 0x1d06d681, (ObjectType)2),
                new LocationItem(-1083.19592f, -1050.30115f, 1.71443009f, 0.0079921307f, 0.0147342067f, 33.0811882f, "", "", false, 0xa988d3a2, (ObjectType)2),
                new LocationItem(-1078.85571f, -1049.11426f, 2.14564753f, 5.33608556e-07f, 5.336085e-07f, -84.2767792f, "amb@world_human_bum_slumped@male@laying_on_left_side@idle_a", "idle_a", false, 0x53b57eb0, (ObjectType)1),
                new LocationItem(-1075.58716f, -1045.12573f, 2.15109968f, -0f, 0f, 162.863861f, "amb@world_human_bum_standing@twitchy@base", "base", false, 0x53b57eb0, (ObjectType)1),
                new LocationItem(-1073.99719f, -1046.2605f, 2.14652729f, -0f, 0f, 93.7451401f, "amb@world_human_bum_slumped@male@laying_on_right_side@idle_a", "idle_c", false, 0x53b57eb0, (ObjectType)1),
            },
            new LocationItem[]
            {
                new LocationItem(-494.24588f, -950.503235f, 24.0141773f, -0.303967267f, -0.35703668f, 102.614708f, "", "", false, 0x1c534995, (ObjectType)2),
                new LocationItem(-495.906677f, -952.703796f, 23.9603729f, -0f, 0f, -122.752197f, "amb@world_human_bum_standing@twitchy@base", "base", false, 0x1ec93fd0, (ObjectType)1),
                new LocationItem(-495.059723f, -953.807068f, 23.9611015f, -0f, 0f, 26.3970852f, "amb@world_human_bum_standing@drunk@base", "base", false, 0x1ec93fd0, (ObjectType)1)
            },
            new LocationItem[]
            {
                new LocationItem(27.0833492f, -1034.58801f, 28.7859306f, -0.210234895f, -0.0947543904f, 64.4044418f, "", "", false, 0x13b57d8a, (ObjectType)2),
                new LocationItem(28.2873783f, -1033.69714f, 29.3407383f, -0f, 0f, -22.9937973f, "amb@world_human_bum_slumped@male@laying_on_left_side@base", "base", false, 0x4705974a, (ObjectType)1)
            },
            new LocationItem[]
            {
                new LocationItem(237.233749f, 36.7017555f, 83.3530121f, 6.03511381f, 3.99023604f, -102.250938f, "", "", false, 0x3fc5d440, (ObjectType)2),
                new LocationItem(237.597397f, 38.3258209f, 83.734375f, -0f, 0f, 47.5231552f, "amb@world_human_bum_standing@drunk@base", "base", false, 0xd172497e, (ObjectType)1),
                new LocationItem(238.54863f, 45.4135323f, 83.987709f, -0f, 0f, 105.467545f, "amb@world_human_bum_slumped@male@laying_on_left_side@idle_a", "idle_b", false, 0xd172497e, (ObjectType)1),
                new LocationItem(241.757843f, 43.4300957f, 83.9803009f, -0f, 0f, 44.4045258f, "amb@world_human_bum_slumped@male@laying_on_right_side@idle_a", "idle_b", false, 0xd172497e, (ObjectType)1)
            },
            new LocationItem[]
            {
                new LocationItem(758.580505f, -1335.69836f, 25.4236851f, -0.039165128f, 0.0813752562f, 82.0263977f, "", "", false, 0x51d83328, (ObjectType)2),
                new LocationItem(744.357788f, -1334.96228f, 25.434494f, -0.155750468f, 0.0592301227f, 88.6955719f, "", "", false, 0x51d83328, (ObjectType)2),
                new LocationItem(750.437073f, -1335.55554f, 25.8763409f, -0.111069851f, 0.0505200066f, 92.4197617f, "", "", false, 0xc3ddfdce, (ObjectType)2),
                new LocationItem(744.013855f, -1336.20117f, 26.2329464f, -0f, 0f, -167.335876f, "amb@world_human_bum_slumped@male@laying_on_left_side@base", "base", false, 0x4705974a, (ObjectType)1),
                new LocationItem(751.421326f, -1332.78711f, 27.2741528f, -0f, 0f, -64.7848358f, "amb@world_human_bum_standing@twitchy@base", "base", false, 0x4705974a, (ObjectType)1),
                new LocationItem(752.142761f, -1332.55066f, 27.2741413f, -0f, 0f, 116.269638f, "amb@world_human_bum_standing@drunk@base", "base", false, 0x4705974a, (ObjectType)1)
            },
            new LocationItem[]
            {
                new LocationItem(-451.730652f, -1721.88794f, 18.3906174f, -1.10497415f, -0.231282353f, 162.964432f, "", "", false, 0x5b42a5c4, (ObjectType)2),
                new LocationItem(-452.777039f, -1721.12378f, 18.7055016f, -0f, 4.2688356e-07f, 72.6914368f, "amb@world_human_bum_slumped@male@laying_on_left_side@base", "base", false, 0x4705974a, (ObjectType)1),
                new LocationItem(-454.723328f, -1726.62305f, 18.672739f, -0f, 0f, 140.595612f, "switch@trevor@jerking_off", "trev_jerking_off_loop", false, 0x4705974a, (ObjectType)1),
                new LocationItem(-458.690582f, -1726.81433f, 18.6827202f, -0f, 0f, 44.3678627f, "amb@world_human_bum_standing@twitchy@base", "base", false, 0x4705974a, (ObjectType)1)
            },
            new LocationItem[]
            {
                new LocationItem(1133.80017f, -3125.98145f, 5.4114995f, 0.00537372101f, -0.0131102037f, -173.356781f, "", "", false, 0x8e9254fb, (ObjectType)2),
                new LocationItem(1132.1123f, -3126.96216f, 5.89854956f, -0f, 0f, -130.421219f, "amb@world_human_bum_standing@drunk@base", "base", false, 0x4705974a, (ObjectType)1),
                new LocationItem(1133.88354f, -3127.82861f, 6.80883121f, -0f, 0f, 29.2947865f, "amb@world_human_bum_slumped@male@laying_on_right_side@idle_a", "idle_b", false, 0x4705974a, (ObjectType)1)
            }
        };

        public static LocationItem[][] DrugDealerLocation = new LocationItem[6][]
        {
            new LocationItem[]
            {
                new LocationItem(-550.260315f, 302.303528f, 82.612442f, -1.26564944f, 1.57898355f, 94.6226959f, "", "", false, 0x14d69010, (ObjectType)2),
                new LocationItem(-550.250916f, 305.825134f, 82.6819153f, 0.374282807f, -2.83794856f, -95.4159241f, "", "", false, 0x14d69010, (ObjectType)2),
                new LocationItem(-553.417297f, 305.201294f, 83.3122864f, 2.54444361e-14f, 5.33600485e-07f, -47.2303886f, "amb@world_human_drug_dealer_hard@male@idle_b", "idle_d", false, 0xe497bbef, (ObjectType)1),
                new LocationItem(-554.098938f, 306.211548f, 83.2979126f, -0f, 0f, -56.0966759f, "amb@world_human_drug_dealer_hard@male@idle_a", "idle_b", false, 0xe497bbef, (ObjectType)1),
                new LocationItem(-543.966003f, 310.606781f, 83.0157318f, -0f, 0f, -90.7217484f, "timetable@gardener@smoking_joint", "idle_cough", false, 0xe497bbef, (ObjectType)1),
                new LocationItem(-553.25177f, 306.96286f, 83.2642517f, -0f, 0f, 163.330093f, "amb@world_human_drug_dealer_hard@male@idle_a", "idle_a", false, 0xe497bbef, (ObjectType)1)
            },
            new LocationItem[]
            {
                new LocationItem(127.733292f, -418.739441f, 40.5363045f, -0.000672326074f, -0.00645108894f, 67.0974655f, "", "", false, 0x1f3766e3, (ObjectType)2),
                new LocationItem(129.433487f, -414.790161f, 40.4948006f, -0.00210483302f, -0.0466712341f, -137.168976f, "", "", false, 0xca62927a, (ObjectType)2),
                new LocationItem(130.571945f, -420.844269f, 41.0621986f, -0f, 0f, -8.63303661f, "amb@world_human_drug_dealer_hard@male@idle_b", "idle_d", false, 0xe497bbef, (ObjectType)1),
                new LocationItem(131.144165f, -419.262177f, 41.0702209f, -0f, 0f, 162.342407f, "amb@world_human_drug_dealer_hard@male@idle_a", "idle_c", false, 0xe497bbef, (ObjectType)1)
            },
            new LocationItem[]
            {
                new LocationItem(-1277.05615f, -1087.25732f, 6.9212594f, -2.03674674f, -0.804251432f, 29.8162327f, "", "", false, 0x95466bdb, (ObjectType)2),
                new LocationItem(-1276.47925f, -1085.27417f, 7.59176683f, 0f, 0f, 48.5364418f, "amb@world_human_drug_dealer_hard@male@idle_a", "idle_a", false, 0xe497bbef, (ObjectType)1)
            },
            new LocationItem[]
            {
                new LocationItem(-943.176086f, -2081.27295f, 8.75052071f, 0.000130665707f, 0.0121497149f, 43.0176697f, "", "", false, 0xe9805550, (ObjectType)2),
                new LocationItem(-942.275757f, -2084.06079f, 9.29911518f, -0f, 0f, -28.1123562f, "amb@world_human_drug_dealer_hard@male@idle_a", "idle_a", false, 0xe497bbef, (ObjectType)1),
                new LocationItem(-940.8974f, -2081.95728f, 9.29902554f, -0f, 0f, 156.580429f, "amb@world_human_drug_dealer_hard@male@idle_b", "idle_d", false, 0xe497bbef, (ObjectType)1)
            },
            new LocationItem[]
            {
                new LocationItem(86.8202896f, -1250.60583f, 28.7915745f, 0.000115974886f, -0.0692671984f, 97.3034134f, "", "", false, 0x9b909c94, (ObjectType)2),
                new LocationItem(88.5265427f, -1252.05139f, 29.316164f, -0f, -6.19121602e-06f, 60.5782547f, "amb@world_human_drug_dealer_hard@male@idle_a", "idle_c", false, 0xe497bbef, (ObjectType)1),
                new LocationItem(87.1566696f, -1252.27222f, 29.318224f, 0f, 0f, -47.4291229f, "amb@world_human_drug_dealer_hard@male@idle_a", "idle_a", false, 0xe497bbef, (ObjectType)1)
            },
            new LocationItem[]
            {
                new LocationItem(276.558136f, -2628.77881f, 5.56053543f, 0.1949175f, -0.653557539f, -160.123566f, "", "", false, 0x9b909c94, (ObjectType)2),
                new LocationItem(278.248535f, -2631.22949f, 6.06302929f, -0f, 0f, 119.237434f, "amb@world_human_drug_dealer_hard@male@idle_b", "idle_d", false, 0xe497bbef, (ObjectType)1),
                new LocationItem(276.743744f, -2631.83594f, 6.05718756f, -0f, 0f, -77.2895355f, "amb@world_human_drug_dealer_hard@male@idle_a", "idle_a", false, 0xe497bbef, (ObjectType)1)
            }
        };

        private static LocationItem[] m_SidewalkPosistions = new LocationItem[]
        {

        };
    }


    public class LocationItem
    {
        public Vector3 Posistion;
        public Vector3 Rotation;

        public string AnimDict;
        public string AnimName;

        public bool Frozen;
        public UInt32 Model;
        public Location.ObjectType Type;

        public LocationItem(float x, float y, float z, float pitch, float roll, float yaw, string animDict, string animName,
            bool frozen, uint model, Location.ObjectType type)
        {
            Posistion = new Vector3(x, y, z);
            Rotation = new Vector3(pitch, roll, yaw);
            AnimDict = animDict;
            AnimName = animName;
            Frozen = frozen;
            Model = model;
            Type = type;
        }
    }
}
