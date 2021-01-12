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
using TeslaCarConfigurator.UserControls.Accordion;
using TeslaCarConfigurator.Data;
using TeslaCarConfigurator.Helpers;

namespace TeslaCarConfigurator.UserControls.Summary
{
    /// <summary>
    /// Interaction logic for ModelSummary.xaml
    /// </summary>
    public partial class WheelsSummary : UserControl
    {
        private WheelConfiguration wheels;

        public WheelsSummary(WheelConfiguration wheels)
        {
            InitializeComponent();
            this.wheels = wheels;
        }

        private void tbPrice_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tbPrice = (TextBlock)sender;
            int prices = wheels.CalculateAdditionalPrices();
            if (prices == 0)
            {
                return;
            }

            tbPrice.Text = "+" + prices.ToString("C", Formatting.CurrencyFormat);
        }

        private void tbDescription_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tbDescription = (TextBlock)sender;
            tbDescription.Text = WheelConfiguration.WheelDescriptions[wheels.TypeIndex];
        }

        private void tbChosenText_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tbChosenText = (TextBlock)sender;
            tbChosenText.Text = wheels.Type;
        }

        private void wheelImage_Loaded(object sender, RoutedEventArgs e)
        {
            Image wheelImage = (Image)sender;
            wheelImage.Source = new BitmapImage(new Uri($"../../Assets/Wheel{wheels.TypeIndex + 1}.png", UriKind.Relative));
        }
    }
}
