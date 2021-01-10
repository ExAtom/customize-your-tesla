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
using TeslaCarConfigurator.Data;
using TeslaCarConfigurator.Helpers;

namespace TeslaCarConfigurator.Pages
{
    public partial class BatteryConfiguration : PageBase
    {
        private List<string[]> chosenBatteryTexts;


        public BatteryConfiguration()
        {
            chosenBatteryTexts = new List<string[]>()
            {
                new string[2]{ Battery.CapacityDescriptions[0], $"Ára: {Battery.Prices[0]}FT" },
                new string[2]{ Battery.CapacityDescriptions[1], $"Ára: {Battery.Prices[1]}FT" },
                new string[2]{ Battery.CapacityDescriptions[2], $"Ára: {Battery.Prices[2]}FT" },
                new string[2]{ Battery.CapacityDescriptions[3], $"Ára: {Battery.Prices[3]}FT" },
                new string[2]{ Battery.CapacityDescriptions[4], $"Ára: {Battery.Prices[4]}FT" },
                new string[2]{ Battery.CapacityDescriptions[5], $"Ára: {Battery.Prices[5]}FT" },
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

        private void Windows_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            if (Windows.ActualWidth <= 710)
            {
                Menu.Width = 230;
            }
            else
            {
                Menu.Width = 400;
            }
        }
    }
}
