using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TeslaCarConfigurator.Data
{
    public class Model : Feature
    {
        public static int ByteLength { get; private set; } = 1;

        public static List<string> AvailableModelNames { get; private set; } = new List<string>() { "Model S" };

        public byte ModelNameIndex { get; set; }

        public string ModelName => AvailableModelNames[ModelNameIndex];

        public Model(byte nameIndex)
        {
            ModelNameIndex = nameIndex;
        }

        public Model(byte[] bytes)
        {
            ModelNameIndex = bytes[0];
            if (ModelNameIndex >= AvailableModelNames.Count)
            {
                throw new Exception();
            }
        }

        public override byte[] ToBytes()
        {
            return new byte[] { ModelNameIndex };
        }

        public override int CalculateAdditionalPrices()
        {
            throw new NotImplementedException();
        }
    }
}
