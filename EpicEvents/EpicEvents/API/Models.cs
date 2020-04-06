using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;

namespace EpicEvents
{
    public static class Models
    {
        private static UInt32[] m_HomlessModels = new UInt32[]
        {
            0x4705974a, 0x1ec93fd0, 0x174d4245, 0x48f96f5b
        };

        public static UInt32 GetRandomHomless()
        {
            return m_HomlessModels[Main.Random.Next(0, m_HomlessModels.Length)];
        }
    }
}
