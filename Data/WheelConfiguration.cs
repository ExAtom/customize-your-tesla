using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaCarConfigurator.Data
{
    public class WheelConfiguration : Feature
    {
        public static int ByteLength { get; set; } = 1;

        public static List<string>  AvailableWheelTypes{ get; set; } = new List<string>() { "Aero FX530", "Sport SP002", "Turbine T54", "Silver SU478" };

        public string Type => AvailableWheelTypes[TypeIndex];

        public byte TypeIndex { get; set; }

        public WheelConfiguration(byte typeIndex)
        {
            TypeIndex = typeIndex;
        }

        public WheelConfiguration(byte[] bytes)
        {
            TypeIndex = bytes[0];
        }
    
        public override byte[] ToBytes()
        {
            return new byte[] { TypeIndex};
        }

        public override int CalculateAdditionalPrices()
        {
            throw new NotImplementedException();
        }
    }
}
