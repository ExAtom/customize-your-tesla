using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaCarConfigurator.Data
{
    public class Exterior : Feature
    {
        public static int ByteLength { get; private set; } = 1;

        // vászontető
        public bool HasLinenRoof { get; set; }

        // spoilerek
        public bool HasSpoilers { get; set; }

        // alulvilágítás
        public bool HasBottomLights { get; set; }

        public Exterior(bool hasLinenRoof, bool hasSpoilers, bool hasBottomLights)
        {
            HasLinenRoof = hasLinenRoof;
            HasSpoilers = hasSpoilers;
            HasBottomLights = hasBottomLights;
        }

        public Exterior(byte[] bytes)
        {
            byte data = bytes[0];
            byte linenRoofMask = 0b_0000_0001;
            byte linenRoof = (byte)(data & linenRoofMask);
            HasLinenRoof = linenRoof > 0;

            byte spoilersMask = 0b_0000_0010;
            byte spoilers = (byte)(data & spoilersMask);
            HasSpoilers = spoilers > 0;

            byte bottomLightsMask = 0b_0000_0100;
            byte bottomLights = (byte)(data & bottomLightsMask);
            HasBottomLights = bottomLights > 0;
        }

        public override byte[] ToBytes()
        {
            
            byte value = (byte)((HasLinenRoof ? 1 : 0) + (HasSpoilers ? 1 : 0) * 2 + (HasBottomLights ? 1 : 0) * 4);

            return new byte[] {value };
        }

        public override int CalculateAdditionalPrices()
        {
            return 0;
        }
    }
}
