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

        public static List<string> AvailableWheelTypes { get; private set; } = new List<string>() { "Aero FX530", "Sport SP002", "Turbine T54", "Silver SU478" };

        public static List<string> WheelDescriptions { get; private set; } = new List<string>()
        {
            "Az Aero FX530-as típusú kereket legfőképpen városi közlekedésre ajánljuk. Kiváló tapadást bitosít az aszfalhot, így a hirtelen fékezések sem okozhatnak problémát.",
            "A Sport SP002-őt nevéhez híven olyanoknak ajánjuk, akik szeretik a sebességhatárt túllépni, akár versenyzés közben. A 20\"-as kerékátmérő biztosítja a 450 km/h-ás sebesség elérését.",
            "A Turbine T54-es tipikusan az a kerék, melyet terepviszonyokra terveztek. Az 50 cm-es kerékvastagság és a speciális rovátkázsának köszönhetően homokban, hóban, mocsárban sincs akadály.",
            "A Silver SU478-as típus különlegessége speciális kialakítása révén, hogy téli és nyári abroncsként egyaránt funkciónál, így nem kell azt cserélgetni. Leginkább városi és országúti terepre ajánljuk."
        };

        public static List<int> Prices { get; private set; } = new List<int>() { 25000, 82000, 56000, 69000 };

        public string Type => AvailableWheelTypes[TypeIndex];

        public byte TypeIndex { get; set; }

        public WheelConfiguration(byte typeIndex)
        {
            TypeIndex = typeIndex;
        }

        public WheelConfiguration(byte[] bytes)
        {
            TypeIndex = bytes[0];
            if (TypeIndex >= AvailableWheelTypes.Count)
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
