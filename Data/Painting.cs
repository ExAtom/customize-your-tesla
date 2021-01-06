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

        public static List<string> AvailableColors { get; private set; } = new List<string>() { "Kristályfehér", "Máglyafekete", "Szürke metál", "Kék metál", "Vörös metál" };

        public static List<int> Prices { get; private set; } = new List<int>() {0, 20000, 29000, 38000, 40500};

        public string Color => AvailableColors[ColorIndex];

        public byte ColorIndex { get; set; }


        public Painting(byte colorIndex)
        {
            ColorIndex = colorIndex;
        }

        public Painting(byte[] bytes)
        {
            byte data = bytes[0];
            ColorIndex = data;
            if (ColorIndex >= AvailableColors.Count)
            {
                throw new Exception();
            }
        }

        public override byte[] ToBytes()
        {
            return new byte[] { ColorIndex };
        }

        public override int CalculateAdditionalPrices()
        {
            return Prices[ColorIndex];
        }
    }
}
