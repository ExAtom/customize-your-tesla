using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaCarConfigurator.Data
{
    public class Exterior : Feature
    {
        public static int ByteLength { get; private set; } = 1;

        public static string LinenRoofDescription { get; private set; } = "A vászontető napjaink legdivatosabb autókialakítása.Nagy sebességnél kellemes hangot kelt.A mi vászontetőnk viszont nem csak divatos, de speciális funkciója is van.Gombonymásra visszahúzódik a csomagtartóba és nyitott lesz az utastér.";

        public static int LinenRoofPrice { get; private set; } = 13900000;

        public static int SpoilersPrice { get; private set; } = 5600000;

        public static int BottomLightsPrice { get; private set; } = 1200000;

        public static string SpoilersDescription { get; private set; } = "Spoilerek a hiányzó tapadást hozzák létre, így sokkal gyorsabban száguldozhat autójával, mint egyébként. Automatikusan állítja az autó szoftvere az állásukat, így lassításnál még nagyobb segítséget nyújt.";

        public static string BottomLightsDescription { get; private set; } = "Azoknak ajánljuk, akik szeretnek kitűnni a tömegből. Egy LED sor világítja ki az autó alját, így önt jobban láthatják a sötétben és sokkal ütősebb lesz a megjelenése.";

        // vászontető
        public bool HasLinenRoof { get; set; }

        // spoilerek
        public bool HasSpoilers { get; set; }

        // alulvilágítás
        public bool HasBottomLights { get; set; }

        public Exterior(bool hasLinenRoof, bool hasSpoilers, bool hasBottomLights)
        {
            HasLinenRoof = hasLinenRoof;
            HasSpoilers = hasSpoilers;
            HasBottomLights = hasBottomLights;
        }

        public Exterior(byte[] bytes)
        {
            byte data = bytes[0];
            byte linenRoofMask = 0b_0000_0001;
            byte linenRoof = (byte)(data & linenRoofMask);
            HasLinenRoof = linenRoof > 0;

            byte spoilersMask = 0b_0000_0010;
            byte spoilers = (byte)(data & spoilersMask);
            HasSpoilers = spoilers > 0;

            byte bottomLightsMask = 0b_0000_0100;
            byte bottomLights = (byte)(data & bottomLightsMask);
            HasBottomLights = bottomLights > 0;
        }

        public override byte[] ToBytes()
        {
            
            byte value = (byte)((HasLinenRoof ? 1 : 0) + (HasSpoilers ? 1 : 0) * 2 + (HasBottomLights ? 1 : 0) * 4);

            return new byte[] {value };
        }

        public override int CalculateAdditionalPrices()
        {
            return (HasLinenRoof ? 13900000 : 0) +
                (HasSpoilers ? 5600000 : 0) +
                (HasBottomLights ? 1200000 : 0);
        }
    }
}
