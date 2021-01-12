using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaCarConfigurator.Data
{
    public class SoftwareFeatures:Feature
    {
        public static int ByteLength { get; private set; } = 1;

        public static int SelfdrivingPrice { get; private set; } = 990000;

        public static string SelfdrivingDescription { get; private set; } = "A Tesla autók egyik legkiemelkedőbb szolgáltatása az önvezetés, ami olyan precizitással segít a mindennapi forgalmakban, mint eddig semmilyen más cég autói.";

        public static int GpsPrice { get; private set; } = 95000;

        public static string GpsDescription { get; private set; } = "GPS-szel könnyedén megállapíthatja a helyzetét és segítséget kaphat, hogy milyen irányban folytassa az útján a célpontjának eléréséhez.";

        public static int HeadlightAssistantPrice { get; private set; } = 269000;

        public static string HeadlightAssistantDescription { get; private set; } = "Néha nehéz észrevenni időben, ha egy szemben lévő autó látótávolságba kerül. Ilyenkor a távolsági fényszórókat le kell kapcsolni. Ebben segítene a fényszóró asszisztens.";

        public static int AdaptiveLightsPrice { get; private set; } = 246000;

        public static string AdaptiveLightsDescription { get; private set; } = "Fényviszonyokhoz alkalmazkodik az autó fényberendezései, ezzel kevesebb dologgal foglalkozhat a sofőr, így könnyebben odafigyelhet a balesetmentes vezetésre.";

        // önvezetés
        public bool HasSelfdriving { get; set; }

        // GPS
        public bool HasGps { get; set; }

        // távolsági fényszóró asszisztens
        public bool HasHeadlightAssistant { get; set; }

        // adaptív fényszóró
        public bool HasAdaptiveLights { get; set; }

        public SoftwareFeatures(bool hasSelfdriving, bool hasGps, bool hasHeadlightAssistant, bool hasAdaptiveLights)
        {
            HasSelfdriving = hasSelfdriving;
            HasGps = hasGps;
            HasHeadlightAssistant = hasHeadlightAssistant;
            HasAdaptiveLights = hasAdaptiveLights;
        }

        public SoftwareFeatures(byte[] bytes, byte transmissionType) 
        {
            byte data = bytes[0];
            byte selfdrivingMask = 0b_0000_0001;
            byte selfdriving = (byte)(data & selfdrivingMask);
            HasSelfdriving = selfdriving > 0 && transmissionType > 0;

            byte gpsMask = 0b_0000_0010;
            byte gps = (byte)(data & gpsMask);
            HasGps = gps > 0;

            byte headlightMask = 0b_0000_0100;
            byte headlight = (byte)(data & headlightMask);
            HasHeadlightAssistant = headlight > 0;

            byte adativeLightsMask = 0b_0000_1000;
            byte adativeLights = (byte)(data & adativeLightsMask);
            HasAdaptiveLights = adativeLights > 0;
        }

        public override byte[] ToBytes()
        {
            byte selfdriving = (byte)((HasSelfdriving ? 1 : 0));
            byte gps = (byte)((HasGps ? 1 : 0) << 1);
            byte headlight = (byte)((HasHeadlightAssistant ? 1 : 0) << 2);
            byte adaptiveLights = (byte)((HasAdaptiveLights ? 1 : 0) << 3);


            byte data = (byte)(selfdriving + gps + headlight + adaptiveLights);

            return new byte[] { data };
        }

        public override int CalculateAdditionalPrices()
        {
            return (HasSelfdriving ? 990000 : 0) +
                (HasGps ? 95000 : 0) +
                (HasHeadlightAssistant ? 269000 : 0) +
                (HasAdaptiveLights ? 246000 : 0);
        }
    }
}
