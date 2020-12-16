using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TeslaCarConfigurator.Helpers;

namespace TeslaCarConfigurator
{
    public partial class BatteryConfiguration : PageBase
    {
        private List<string[]> chosenBatteryTexts;


        public BatteryConfiguration()
        {
            chosenBatteryTexts = new List<string[]>()
            {
                new string[2]{ "Ez a legkisebb választható akkumulátor, amit olyanoknak ajánlunk, akik kis távolságokra használnák.", "Ára: 70.000FT" },
                new string[2]{ "A 70 kWh-s akkumulátor már egy kicsivel erősebb, ideális választás városok között ingázóknak.", "Ára: 100.000FT" },
                new string[2]{ "A 80 kWh-s akkumulátor már 2 heti folyamatos városi használatot is képes kibírni.", "Ára: 140.000FT" },
                new string[2]{ "Ezt az akkumulátort azoknak ajánljuk, akik naponta hosszabb távokat szeretnének megtenni.", "Ára: 170.000FT" },
                new string[2]{ "A 100 kWh-s akkumulátort azoknak terveztük, akik naponta körbejárják az országot.", "Ára: 220.000FT" },
                new string[2]{ "A legerősebb akkumulátorunk olyanok igényeit is tökéletesen kielégíti, akik folyamatosan úton vannak Közép-Európa szerte.", "Ára: 270.000FT" },
            };
            InitializeComponent();


        }

        public override void OnAttachedToFrame()
        {
            byte chosenBatteryIndex = Config?.Battery?.CapacityIndex ?? 0;
            Viewbox selectedVb = (Viewbox)batteryOptionsContainer.Children[chosenBatteryIndex];
            RadioButton selected = (RadioButton)selectedVb.Child;
            selected.IsChecked = true;
        }

        private void rbBatteryType_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            string name = rb.Name;
            byte index = byte.Parse(name.Replace("rbBatteryType", ""));
            string[] texts = chosenBatteryTexts[index];
            tbInfos.Text = texts[0];
            tbPrice.Text = texts[1];
            if (Config == null)
            {
                return;
            }
            Config.Battery.CapacityIndex = index;
        }

        
    }
}
