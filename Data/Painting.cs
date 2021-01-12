using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaCarConfigurator.Data
{

    public class Painting : Feature
    {
        public static int ByteLength { get; private set; } = 1;

        public static List<string> AvailableColors { get; private set; } = new List<string>() { "Kristályfehér", "Máglyafekete", "Szürke metál", "Kék metál", "Vörös metál" };

        public static List<string> ColorDescriptions { get; private set; } = new List<string>() 
        { 
            "A kristályfehér az ártatlanság és a tökéletesség színe. Kiváló választás azon személyeknek, akik rendszeresen tisztítják autójukat és szeretik az egyszerűséget.",
            "Máglyafekete fényezésünk a legelegánsabb. Tulajdonosa céltudatosságot sugall. Előnyös választás lehet, hiszen a szennyeződések nehezen vehetőek észre a kaszni felületen.",
            "Impozáns szüke metál fényezésünk az elmúlt évek tapasztalatai alapján a legtöbbet választott szín. Tulajdonosa kreatív és társaságkedvelő valamint jó alkalmazkodóképességű.",
            "A kék a víz, a harmónia, magabiztosság, kreativizmus és béke szimbóluma. Nagy valószínűséggel a járókelőknek is ez fog Önről eszükbe jutni, ha megláták a forgalomban.",
            "Gyönyörű piros fényezésünk a szerelem és az energia színe. Tulajdonosa általában dinamikus és körültekintő, ugyanakkor hajlamos két végén égetni a gyertyát.",
        };

        public static List<int> Prices { get; private set; } = new List<int>() { 0, 20000, 29000, 38000, 40500 };

        public string Color => AvailableColors[ColorIndex];

        public byte ColorIndex { get; set; }


        public Painting(byte colorIndex)
        {
            ColorIndex = colorIndex;
        }

        public Painting(byte[] bytes)
        {
            byte data = bytes[0];
            ColorIndex = data;
            if (ColorIndex >= AvailableColors.Count)
            {
                throw new Exception();
            }
        }

        public override byte[] ToBytes()
        {
            return new byte[] { ColorIndex };
        }

        public override int CalculateAdditionalPrices()
        {
            return Prices[ColorIndex];
        }
    }
}
