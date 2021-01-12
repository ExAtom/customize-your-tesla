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

        public static List<string> CapacityDescriptions { get; private set; } = new List<string>()
            {
                 "Ez a legkisebb választható akkumulátor, amit olyanoknak ajánlunk, akik kis távolságokra használnák.",
                 "A 70 kWh-s akkumulátor már egy kicsivel erősebb, ideális választás városok között ingázóknak.",
                 "A 80 kWh-s akkumulátor már 2 heti folyamatos városi használatot is képes kibírni.",
                 "Ezt az akkumulátort azoknak ajánljuk, akik naponta hosszabb távokat szeretnének megtenni.",
                 "A 100 kWh-s akkumulátort azoknak terveztük, akik naponta körbejárják az országot.",
                 "A legerősebb akkumulátorunk olyanok igényeit is tökéletesen kielégíti, akik folyamatosan úton vannak Közép-Európa szerte.",
            };

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
