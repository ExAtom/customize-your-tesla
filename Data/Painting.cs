using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaCarConfigurator.Data
{

    public class Painting : Feature
    {
        public static int ByteLength { get; private set; } = 1;

        public static List<string> AvailableColors { get; private set; } = new List<string>() { "Fekete" };

        public string Color => AvailableColors[ColorIndex];

        public byte ColorIndex { get; set; }

        public bool IsMetallic { get; set; }

        public Painting(byte colorIndex, bool isMetallic)
        {
            ColorIndex = colorIndex;
            IsMetallic = isMetallic;
        }

        public Painting(byte[] bytes)
        {
            byte data = bytes[0];
            byte metallicMask = 0b_0000_0001;
            byte metallic = (byte)(data & metallicMask);
            IsMetallic = metallic > 0;
            ColorIndex = (byte)(data >> 1);
            if (ColorIndex >= AvailableColors.Count)
            {
                throw new Exception();
            }
        }

        public override byte[] ToBytes()
        {
            byte data = (byte)(IsMetallic ? 1 : 0);
            data += (byte)(ColorIndex << 1);
            return new byte[] { data };
        }

        public override int CalculateAdditionalPrices()
        {
            throw new NotImplementedException();
        }
    }
}
