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

        public SoftwareFeatures(byte[] bytes) 
        {
            byte data = bytes[0];
            byte selfdrivingMask = 0b_0000_0001;
            byte selfdriving = (byte)(data & selfdrivingMask);
            HasSelfdriving = selfdriving > 0;

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
            byte selfdriving = (byte)((HasSelfdriving ? 0 : 1));
            byte gps = (byte)((HasGps ? 0 : 1) << 1);
            byte headlight = (byte)((HasHeadlightAssistant ? 0 : 1) << 2);
            byte adaptiveLights = (byte)((HasAdaptiveLights ? 0 : 1) << 3);


            byte data = (byte)(selfdriving + gps + headlight + adaptiveLights);

            return new byte[] { data };
        }

        public override int CalculateAdditionalPrices()
        {
            throw new NotImplementedException();
        }
    }
}
