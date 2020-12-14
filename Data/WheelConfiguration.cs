using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaCarConfigurator.Data
{
    public class WheelConfiguration : Feature
    {
        public static int ByteLength { get; set; } = 0;

        public WheelConfiguration()
        {

        }

        public WheelConfiguration(byte[] bytes)
        {

        }

        public override byte[] ToBytes()
        {


            return new byte[] { };
        }

        public override int CalculateAdditionalPrices()
        {
            throw new NotImplementedException();
        }
    }
}
