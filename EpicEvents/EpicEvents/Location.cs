using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicEvents
{
    class Location
    {
        public static LocationItem[,] HomlessLocations = new LocationItem[,]
        {
            {
                new LocationItem(-787.053894f, -198.843399f, 37.0953369f, 0.000349821727f, 0.160985678f, 115.264412f, "", "", false, 0x779f23aa),
new LocationItem(-790.835083f, -190.555313f, 37.2145462f, 0.130138233f, 0.09372098f, 79.5388336f, "", "", false, 0xa3fc0f4d),
new LocationItem(-787.198669f, -197.030823f, 37.2818336f, 0.0345403552f, 0.302632362f, 19.1417198f, "amb@world_human_bum_slumped@male@laying_on_left_side@base", "base", false, 0x4705974a),
new LocationItem(-793.685852f, -199.408127f, 37.2816811f, -0f, 0f, -21.2219582f, "switch@trevor@scares_tramp", "trev_scares_tramp_idle_tramp", false, 0x1ec93fd0),
new LocationItem(-786.124817f, -198.297974f, 38.7381134f, -0f, 4.2688751e-07f, -67.1325607f, "savecouch@", "t_sleep_loop_couch", true, 0x174d4245),
new LocationItem(-789.091431f, -192.740097f, 37.2836342f, 7.04374406e-11f, -4.60734728e-10f, 125.257164f, "amb@world_human_bum_standing@depressed@base", "base", false, 0x6a8f1f9b),
new LocationItem(-790.062439f, -194.077789f, 37.2836418f, -0f, 0f, 45.4848595f, "amb@medic@standing@kneel@idle_a", "idle_a", false, 0x48f96f5b),
new LocationItem(-791.297974f, -193.121307f, 36.4241257f, 0f, 0f, -25.2142849f, "", "", true, 0xbc22517f),
new LocationItem(-791.185425f, -193.165909f, 36.4241257f, 0f, 0f, -31.4504623f, "", "", true, 0xbc22517f),
new LocationItem(-787.387329f, -196.899567f, 36.4241257f, -0f, 0f, -112.866402f, "", "", true, 0x2e23bce7),
new LocationItem(-785.947571f, -197.800369f, 38.1823692f, -0f, 0f, -156.170578f, "", "", true, 0x3256c688),
new LocationItem(-792.006958f, -199.969421f, 36.3073654f, -0f, 0f, -173.409348f, "", "", true, 0x417e64d7),
new LocationItem(-791.909607f, -199.639984f, 36.2837105f, -0f, 0f, -169.424942f, "", "", true, 0x417e64d7),
new LocationItem(-792.456604f, -199.782013f, 36.2837105f, -0f, 0f, 174.63797f, "", "", true, 0x3256c688),
new LocationItem(-792.568542f, -199.56601f, 36.2837105f, -0f, 0f, 170.566971f, "", "", true, 0x3256c688),
new LocationItem(-788.118164f, -197.362076f, 36.2836952f, -0f, 0f, -132.006424f, "", "", true, 0xf84fdd9c),
new LocationItem(-791.119202f, -192.559677f, 36.2907524f, 0f, 0f, -28.5880833f, "", "", true, 0x1a6321c6),
new LocationItem(-790.336914f, -191.755463f, 36.2907524f, 0f, 0f, -33.7848434f, "", "", true, 0x1a6321c6),
new LocationItem(-789.371948f, -192.882874f, 36.4535599f, 0f, 0f, -54.6583977f, "", "", true, 0xb27096d5),
new LocationItem(-787.907654f, -193.655548f, 36.7128296f, 0f, 0f, -63.1462708f, "", "", true, 0x2571cda2),
new LocationItem(-787.407959f, -193.387924f, 36.7128296f, 0f, 0f, 48.4129791f, "", "", true, 0x2571cda2),
new LocationItem(-784.566223f, -197.590546f, 36.342968f, -0f, 0f, 147.151886f, "", "", true, 0x684a97ae),
new LocationItem(-784.596252f, -197.510284f, 36.342968f, -0f, 0f, 146.199066f, "", "", true, 0x684a97ae),
new LocationItem(-787.158691f, -196.757248f, 36.342968f, -0f, 0f, -153.951263f, "", "", true, 0x684a97ae),
new LocationItem(-789.32782f, -197.77298f, 36.5554504f, -0f, 0f, 127.921761f, "", "", true, 0xaf0dd721),
new LocationItem(-787.051453f, -191.899719f, 37.4098053f, -0f, 0f, 122.201424f, "", "", true, 0xb856d4ce),
new LocationItem(-787.687866f, -197.69429f, 36.291317f, -0f, 0f, 159.788315f, "", "", true, 0xaffe1f5a),
new LocationItem(-787.789856f, -197.480087f, 36.3028069f, -0f, 0f, -131.437576f, "", "", true, 0xf3565180),
new LocationItem(-789.227051f, -197.576492f, 36.8463707f, -0f, 0f, -147.807083f, "", "", true, 0xf3565180),
new LocationItem(-789.489807f, -197.78096f, 36.8383293f, -0f, 0f, -93.8425217f, "", "", true, 0x8a154872),
new LocationItem(-787.184448f, -197.32193f, 36.3391037f, -0f, 0f, -125.455093f, "", "", true, 0xe6cb661e),
new LocationItem(-787.658081f, -197.090988f, 36.2939606f, -0f, 0f, -146.675018f, "", "", true, 0xd6aa6804),
new LocationItem(-789.262329f, -197.77034f, 36.8372307f, -0f, 0f, 144.899277f, "", "", true, 0x207cec12),
new LocationItem(-789.365417f, -197.788284f, 36.8372307f, -0f, 0f, 140.56842f, "", "", true, 0x207cec12),
new LocationItem(-788.932556f, -197.148941f, 36.3135529f, -0f, 0f, -95.3131332f, "", "", true, 0x26e7fcb1),
new LocationItem(-782.604919f, -198.534927f, 36.7905655f, -0f, 0f, 167.878067f, "", "", true, 0x72574963),
new LocationItem(-788.752747f, -194.973785f, 36.7909889f, -0f, 0f, 100.578003f, "", "", true, 0xf249c94a),

            }
        };
    }

    class LocationItem
    {
        public float X;
        public float Y;
        public float Z;

        public float Pitch;
        public float Roll;
        public float Yaw;

        public string AnimDict;
        public string AnimName;

        public bool Frozen;
        public UInt32 Model;

        public LocationItem(float x, float y, float z, float pitch, float roll, float yaw, string animDict, string animName, bool frozen, uint model)
        {
            X = x;
            Y = y;
            Z = z;
            Pitch = pitch;
            Roll = roll;
            Yaw = yaw;
            AnimDict = animDict;
            AnimName = animName;
            Frozen = frozen;
            Model = model;
        }
    }
}
