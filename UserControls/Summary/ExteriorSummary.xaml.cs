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
    public partial class ExteriorSummary : UserControl
    {
        private Exterior exterior;

        public ExteriorSummary(Exterior exterior)
        {
            InitializeComponent();
            this.exterior = exterior;
        }

        private void tbPrice_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tbPrice = (TextBlock)sender;
            int prices = exterior.CalculateAdditionalPrices();
            if (prices == 0)
            {
                return;
            }

            tbPrice.Text = "+" + prices.ToString("C", Formatting.CurrencyFormat);
        }

        private void imgLinenRoof_Loaded(object sender, RoutedEventArgs e)
        {
            Image imgLinenRoof = (Image)sender;
            if (exterior.HasLinenRoof)
            {
                imgLinenRoof.Source = new BitmapImage(new Uri("../../Assets/plus.png", UriKind.Relative));
            }
            else
            {
                imgLinenRoof.Source = new BitmapImage(new Uri("../../Assets/minus.png", UriKind.Relative));
            }
        }

        private void tbLinenRoofTitle_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tbLinenRoofTitle = (TextBlock)sender;
            tbLinenRoofTitle.Text = "Vászontető";
            tbLinenRoofTitle.Foreground = exterior.HasLinenRoof ? Brushes.White : new SolidColorBrush(Color.FromArgb(255, 201, 201, 201));
        }

        private void tbLinenRoofCost_Loaded(object sender, RoutedEventArgs e)
        {
            if (exterior.HasLinenRoof)
            {
                TextBlock tbLinenRoofCost = (TextBlock)sender;
                tbLinenRoofCost.Text = "+" + Exterior.LinenRoofPrice.ToString("C", Formatting.CurrencyFormat);
            }
        }

        private void tbLinenRoofDescription_Loaded(object sender, RoutedEventArgs e)
        {
            if (exterior.HasLinenRoof)
            {
                TextBlock tbLinenRoofDescription = (TextBlock)sender;
                tbLinenRoofDescription.Text = Exterior.LinenRoofDescription;
            }
        }

        private void imgSpoilers_Loaded(object sender, RoutedEventArgs e)
        {
            Image imgSpoilers = (Image)sender;
            if (exterior.HasSpoilers)
            {
                imgSpoilers.Source = new BitmapImage(new Uri("../../Assets/plus.png", UriKind.Relative));
            }
            else
            {
                imgSpoilers.Source = new BitmapImage(new Uri("../../Assets/minus.png", UriKind.Relative));
            }
        }

        private void tbSpoilersTitle_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tbSpoilersTitle = (TextBlock)sender;
            tbSpoilersTitle.Text = "Spoilerek";
            tbSpoilersTitle.Foreground = exterior.HasSpoilers ? Brushes.White : new SolidColorBrush(Color.FromArgb(255, 201, 201, 201));
        }

        private void tbSpoilersCost_Loaded(object sender, RoutedEventArgs e)
        {
            if (exterior.HasSpoilers)
            {
                TextBlock tbSpoilersCost = (TextBlock)sender;
                tbSpoilersCost.Text = "+" + Exterior.SpoilersPrice.ToString("C", Formatting.CurrencyFormat);
            }
        }

        private void tbSpoilersDescription_Loaded(object sender, RoutedEventArgs e)
        {
            if (exterior.HasSpoilers)
            {
                TextBlock tbSpoilersDescription = (TextBlock)sender;
                tbSpoilersDescription.Text = Exterior.SpoilersDescription;
            }
        }

        private void imgBottomLights_Loaded(object sender, RoutedEventArgs e)
        {
            Image imgBottomsLights = (Image)sender;
            if (exterior.HasBottomLights)
            {
                imgBottomsLights.Source = new BitmapImage(new Uri("../../Assets/plus.png", UriKind.Relative));
            }
            else
            {
                imgBottomsLights.Source = new BitmapImage(new Uri("../../Assets/minus.png", UriKind.Relative));
            }
        }

        private void tbBottomLightsTitle_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tbBottomLightsTitle = (TextBlock)sender;
            tbBottomLightsTitle.Text = "Alulvilágítás";
            tbBottomLightsTitle.Foreground = exterior.HasBottomLights ? Brushes.White : new SolidColorBrush(Color.FromArgb(255, 201, 201, 201));
        }

        private void tbBottomLightsCost_Loaded(object sender, RoutedEventArgs e)
        {
            if (exterior.HasBottomLights)
            {
                TextBlock tbBottomLightsCost = (TextBlock)sender;
                tbBottomLightsCost.Text = "+" + Exterior.BottomLightsPrice.ToString("C", Formatting.CurrencyFormat);
            }
        }

        private void tbBottomLightsDescription_Loaded(object sender, RoutedEventArgs e)
        {
            if (exterior.HasBottomLights)
            {
                TextBlock tbBottomLightsDescription = (TextBlock)sender;
                tbBottomLightsDescription.Text = Exterior.BottomLightsDescription;
            }
        }
    }
}
