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

namespace TeslaCarConfigurator.UserControls.Summary
{
    /// <summary>
    /// Interaction logic for BatterySummary.xaml
    /// </summary>
    public partial class BatterySummary : UserControl
    {

        private Battery battery;

        public BatterySummary(Battery battery)
        {
            InitializeComponent();
            this.battery = battery;
        }

        private void tbPrice_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tbPrice = (TextBlock)sender;
            tbPrice.Text = "+" + battery.CalculateAdditionalPrices().ToString("C", Formatting.CurrencyFormat);
        }

        private void tbDescription_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tbDescription = (TextBlock)sender;
            tbDescription.Text = Battery.CapacityDescriptions[battery.CapacityIndex];
        }

        private void tbChosenText_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tbChosenText = (TextBlock)sender;
            tbChosenText.Text = battery.Capacity.ToString() + " kWh";
        }


    }
}
