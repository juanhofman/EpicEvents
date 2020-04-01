using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rage;
using System.Threading.Tasks;

namespace EpicEvents
{
    public class EVector3
    {
        public Vector3 Vector3;
        public float Heading;

        public EVector3(Vector3 vector3, float heading)
        {
            Vector3 = vector3;
            Heading = heading;
        }

        public EVector3(float x, float y, float z, float h)
        {
            Vector3 = new Vector3(x, y, z);
            Heading = h;
        }
    }
}
