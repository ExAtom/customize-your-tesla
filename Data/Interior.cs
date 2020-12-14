using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaCarConfigurator.Data
{
    public class Interior:Feature
    {
        public static int ByteLength { get; private set; } = 3;

        public static List<string> AvailableMaterials { get; private set; } = new List<string>() { "Bőr" };

        public static List<string> AvailableColors { get; private set; } = new List<string>() { "Fekete" };

        // ülésfűtés
        public bool HasSeatHeating { get; set; }

        // kormányfűtés
        public bool HasSteeringWheelHeating { get; set; }

        // gerinctámasz
        public bool HasSpineSupport { get; set; }

        // napfényvédő roló
        public bool HasSunlightProtection { get; set; }

        // sötétített tükrök
        public bool HasDarkenedMirrors { get; set; }

        // kárpitozás anyaga
        public string Material => AvailableMaterials[MaterialIndex];

        public byte MaterialIndex { get; set; }

        // belső tér színe
        public string InteriorColor => AvailableColors[ColorIndex];

        public byte ColorIndex { get; set; }

        public Interior(byte[] bytes)
        {
            byte booleans = bytes[0];
            byte seatHeatingMask = 0b_0000_0001;
            byte seatHeating = (byte)(booleans & seatHeatingMask);
            HasSeatHeating = seatHeating > 0;

            byte swHeatingMask = 0b_0000_0010;
            byte swHeating = (byte)(booleans & swHeatingMask);
            HasSteeringWheelHeating = swHeating > 0;

            byte spineSupportMask = 0b_0000_0100;
            byte spineSupport = (byte)(booleans & spineSupportMask);
            HasSpineSupport = spineSupport > 0;

            byte sunlightProtectionMask = 0b_0000_1000;
            byte sunlightProtection = (byte)(booleans & sunlightProtectionMask);
            HasSunlightProtection = sunlightProtection > 0;

            byte darkenedMirrorsMask = 0b_0001_0000;
            byte darkenedMirrors = (byte)(booleans & darkenedMirrorsMask);
            HasDarkenedMirrors = darkenedMirrors > 0;

            MaterialIndex = bytes[1];
            if (MaterialIndex >= AvailableMaterials.Count)
            {
                throw new Exception();
            }

            ColorIndex = bytes[2];
            if (ColorIndex >= AvailableColors.Count)
            {
                throw new Exception();
            }
        }

        public Interior(bool hasSeatHeating, bool hasSteeringWheelHeating, bool hasSpineSupport, bool hasSunlightProtection, bool hasDarkenedMirrors, byte materialIndex, byte colorIndex)
        {
            HasSeatHeating = hasSeatHeating;
            HasSteeringWheelHeating = hasSteeringWheelHeating;
            HasSpineSupport = hasSpineSupport;
            HasSunlightProtection = hasSunlightProtection;
            HasDarkenedMirrors = hasDarkenedMirrors;
            MaterialIndex = materialIndex;
            ColorIndex = colorIndex;
        }

        public override byte[] ToBytes()
        {
            byte seatHeating = (byte)(HasSeatHeating ? 1 : 0);
            byte steeringWheel = (byte)((HasSteeringWheelHeating ? 0 : 1) * 2);
            byte spineSupport = (byte)((HasSpineSupport ? 1 : 0) * 4);
            byte sunlightProtection = (byte)((HasSunlightProtection ? 1 : 0) * 8);
            byte darkenedMirrors = (byte)((HasDarkenedMirrors ? 1 : 0) * 16);
            
            byte booleanBytes = (byte)(seatHeating + steeringWheel + spineSupport + sunlightProtection + darkenedMirrors);

            return new byte[] { booleanBytes,MaterialIndex,ColorIndex };
        }

        public override int CalculateAdditionalPrices()
        {
            throw new NotImplementedException();
        }
    }
}
