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

        // típus
        public TransmissionType Type { get; set; }

        public Transmission(TransmissionType type)
        {
            Type = type;
        }

        public Transmission(byte[] bytes)
        {
            byte data = bytes[0];
            Type = (TransmissionType)data;

        }

        public override byte[] ToBytes()
        {
            byte data = (byte)Type;

            return new byte[] { data };
        }

        public override int CalculateAdditionalPrices()
        {
            throw new NotImplementedException();
        }
    }

    public enum TransmissionType
    {
        Automatic, Manual
    }
}
