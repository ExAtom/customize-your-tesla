using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaCarConfigurator.Data
{
    public class Battery : Feature
    {
        public static int ByteLength { get; private set; } = 1;

        public static List<byte> AvailableCapacities { get; private set; } = new List<byte>() { 60, 70, 80, 90, 100, 110 };

        public static List<int> Prices { get; private set; } = new List<int>() { 70000, 100000, 140000, 170000, 220000, 270000 };

        // kapacitás kWh-ban
        public byte Capacity => AvailableCapacities[CapacityIndex];

        public byte CapacityIndex { get; set; }

        public Battery(byte capacityIndex)
        {
            CapacityIndex = capacityIndex;
        }

        public Battery(byte[] bytes)
        {
            CapacityIndex = bytes[0];
            if (CapacityIndex >= AvailableCapacities.Count)
            {
                throw new Exception();
            }
        }

        public override byte[] ToBytes()
        {
            return new byte[] { CapacityIndex };
        }

        public override int CalculateAdditionalPrices()
        {
            return Prices[CapacityIndex];
        }
    }
}
