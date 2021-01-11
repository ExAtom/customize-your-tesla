using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TeslaCarConfigurator.Data
{
    public class Model : Feature
    {
        public static int ByteLength { get; private set; } = 1;

        public static List<string> AvailableModelNames { get; private set; } = new List<string>() { "Model 3", "Model Y", "Model X", "Model S" };

        public static List<string> ModelDescriptions { get; private set; } = new List<string>() 
        {
             "➤ 430 kilométer hatótávolság\n➤ 225 km/h végsebesség\n➤ 5.6 mp 0-100 km/h gyorsulás\n➤ Elektromos csomagtérajtó",
             "➤ 480 kilométer hatótávolság\n➤ 241 km/h végsebesség\n➤ 3.7 mp 0-100 km/h gyorsulás\n➤ Összkerék meghajtás",
             "➤ 561 kilométer hatótávolság\n➤ 250 km/h végsebesség\n➤ 4.6 mp 0-100 km/h gyorsulás\n➤ Összkerék meghajtás",
             "➤ 840+ kilométer hatótávolság\n➤ 320 km/h végsebesség\n➤ <2.1 mp 0-100 km/h gyorsulás\n➤ Három motoros összkerék meghajtás" 
        };

        public static List<int> Prices { get; private set; } = new List<int>() { 20610000, 35470000, 41640000, 53180000 };

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
            return Prices[ModelNameIndex];
        }
    }
}
