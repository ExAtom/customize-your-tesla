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
    public partial class PaintingSummary : UserControl
    {
        private Painting painting;

        public PaintingSummary(Painting painting)
        {
            InitializeComponent();
            this.painting = painting;
        }

        private void tbPrice_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tbPrice = (TextBlock)sender;
            int prices = painting.CalculateAdditionalPrices();
            if (prices == 0)
            {
                return;
            }

            tbPrice.Text = "+" + prices.ToString("C", Formatting.CurrencyFormat);
        }

        private void tbDescription_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tbDescription = (TextBlock)sender;
            tbDescription.Text = Painting.ColorDescriptions[painting.ColorIndex];
        }

        private void tbChosenText_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tbChosenText = (TextBlock)sender;
            tbChosenText.Text = painting.Color;
        }

        private void colorImage_Loaded(object sender, RoutedEventArgs e)
        {
            Image colorImage = (Image)sender;
            colorImage.Source = new BitmapImage(new Uri($"../../Assets/Color{painting.ColorIndex + 1}.png", UriKind.Relative));
        }
    }
}
