using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaCarConfigurator.Data
{
    public class Transmission : Feature
    {
        public static int ByteLength { get; private set; } = 1;

        public List<string> AvailableTransmissions { get; set; } = new List<string>() { "Manuális", "Szoftveres" };

        public static List<int> Prices { get; private set; } = new List<int>() { 0,60000 };

        // típus
        public string Type => AvailableTransmissions[TypeIndex];

        public byte TypeIndex { get; set; }

        public Transmission(byte typeIndex)
        {
            TypeIndex = typeIndex;
        }

        public Transmission(byte[] bytes)
        {
            byte data = bytes[0];
            TypeIndex = data;
            if (TypeIndex >= AvailableTransmissions.Count)
            {
                throw new Exception();
            }
        }

        public override byte[] ToBytes()
        {

            return new byte[] { TypeIndex };
        }

        public override int CalculateAdditionalPrices()
        {
            return Prices[TypeIndex];
        }
    }

}
