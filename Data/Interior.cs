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

        public static List<string> AvailableMaterials { get; private set; } = new List<string>() { "Bio Műanyag", "Öntött Fa", "Jegelt Üveg", "Krokodilbőr" };
        public static List<int> MaterialPrices { get; private set; } = new List<int>() { 0, 560000, 665000, 1029000 };

        public static List<string> AvailableColors { get; private set; } = new List<string>() { "Fekete", "Fehér", "Barna" };
        public static List<int> ColorPrices { get; private set; } = new List<int>() { 0, 500000, 600000 };

        public static List<string> MaterialDescriptions { get; private set; } = new List<string>() 
        { 
            "A bio műanyag egy erősebb és környezetkímélőbb alternatíva. A textúrájának kidolgozása az aszfaltra hasonlít, ezzel egyé válhat az úttal, amin éppen halad.",
            "Az öntött fa nem igazi fa, külseje üveges, de ez adja át a legtermészetesebb hatást. Mintha csak visszautaztunk volna az időben, de az autó megtartja prémium érzetét.",
            "A jegelt üveg egy speciális felületcsiszolással készül, ezzel erősítve magát az anyagot, valamint az ujjlenyomatoktól is védi. A végeredmény egy hó textúrájára hasonlít. A legjobb választás téli kocsikázásra.",
            "A krokodilbőr a legritkább fajtájú, Gangeszi aprókrokodil bőre. Elképesztően jóminőségű, tapintása eszméletlen és a szaga új autójéra hasonlít."
        };

        public static List<string> ColorDescriptions { get; private set; } = new List<string>() 
        {
            "Fekete. Milyen egyszerű. Milyen elegáns. Egyszerűen tökéletes. Az űrre és annak végtelenül csodálatosságára emlékeztet. Csodás választás.",
            "A fehér kitisztultság, felsőbbrendűségre sugall. Vezetés közben páratlanul kiemelkedő érzése lehet a vezetőnek.",
            "A barna a legtermészetesebb színünk. Az öntött fával vagy krokodilbőrrel együtt teljes az összhatás. Klasszikus és csodás."
        };

        public static int SeatHeatingPrice { get; private set; } = 150000;

        public static string SeatHeatingDescription { get; private set; } = "Ülés fűtés és hűtés. Bármilyen idő legyen kint, a legkényelmesebb vezetést nyújtja.";

        public static int SteeringWheelHeatingPrice { get; private set; } = 110000;

        public static string SteeringWheelHeatingDescription { get; private set; } = "Kormánykerék fűtése és hűtése. Reggeli induláskor gyakran kényelmetlenül forró vagy hideg lehet a kormány, így az nehezíti a kormányzást. Ennek megoldása ez a beállítás.";

        public static int SpineSupportPrice { get; private set; } = 69420;

        public static string SpineSupportDescription { get; private set; } = "Hosszú utakon nagyban segíthet a gerinctámasz beszerelése. Britt tudósok szerint még a látása is javul tőle.";

        public static int SunlightProtectionPrice { get; private set; } = 650000;

        public static string SunlightProtectionDescription { get; private set; } = "Elég lesz a borzalmas műanyag fényvisszaverő lapokból, amiket senki se bír normálisan az ablkba. Ez az új technológia az autó kikapcsolásakor elsőtétíti az ablakokat, amin kereszül a napfény nem jut be az autóba.";

        public static int DarkenedWindowsPrice { get; private set; } = 190000;

        public static string DarkenedWindowsDescription { get; private set; } = "Kívülről senki se lát be, de belülről ki lát mindenki. Az eleganciapontja is kiemelkedően növekszik a járműnek ennek használatakor.";


        // ülésfűtés
        public bool HasSeatHeating { get; set; }

        // kormányfűtés
        public bool HasSteeringWheelHeating { get; set; }

        // gerinctámasz
        public bool HasSpineSupport { get; set; }

        // napfényvédő roló
        public bool HasSunlightProtection { get; set; }

        // sötétített ablak
        public bool HasDarkenedWindows { get; set; }

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

            byte darkenedWindowsMask = 0b_0001_0000;
            byte darkenedWindows = (byte)(booleans & darkenedWindowsMask);
            HasDarkenedWindows = darkenedWindows > 0;

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

        public Interior(bool hasSeatHeating, bool hasSteeringWheelHeating, bool hasSpineSupport, bool hasSunlightProtection, bool hasDarkenedWindows, byte materialIndex, byte colorIndex)
        {
            HasSeatHeating = hasSeatHeating;
            HasSteeringWheelHeating = hasSteeringWheelHeating;
            HasSpineSupport = hasSpineSupport;
            HasSunlightProtection = hasSunlightProtection;
            HasDarkenedWindows = hasDarkenedWindows;
            MaterialIndex = materialIndex;
            ColorIndex = colorIndex;
        }

        public override byte[] ToBytes()
        {
            byte seatHeating = (byte)(HasSeatHeating ? 1 : 0);
            byte steeringWheel = (byte)((HasSteeringWheelHeating ? 1 : 0) * 2);
            byte spineSupport = (byte)((HasSpineSupport ? 1 : 0) * 4);
            byte sunlightProtection = (byte)((HasSunlightProtection ? 1 : 0) * 8);
            byte darkenedWindows = (byte)((HasDarkenedWindows ? 1 : 0) * 16);
            
            byte booleanBytes = (byte)(seatHeating + steeringWheel + spineSupport + sunlightProtection + darkenedWindows);

            return new byte[] { booleanBytes,MaterialIndex,ColorIndex };
        }

        public override int CalculateAdditionalPrices()
        {
            return MaterialPrices[MaterialIndex] +
                ColorPrices[ColorIndex] +
                (HasSeatHeating ? 150000 : 0) +
                (HasSteeringWheelHeating ? 110000 : 0) +
                (HasSpineSupport ? 69420 : 0) +
                (HasSunlightProtection ? 650000 : 0) +
                (HasDarkenedWindows ? 190000 : 0);
        }
    }
}
