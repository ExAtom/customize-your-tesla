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
    public partial class InteriorSummary : UserControl
    {
        private Interior interior;

        public InteriorSummary(Interior interior)
        {
            InitializeComponent();
            this.interior = interior;
        }

        private void tbPrice_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tbPrice = (TextBlock)sender;
            int prices = interior.CalculateAdditionalPrices();
            if (prices == 0)
            {
                return;
            }

            tbPrice.Text = "+" + prices.ToString("C", Formatting.CurrencyFormat);
        }

        private void tbChosenMaterialTitle_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            tb.Text = $"Anyag: {interior.Material}";
        }

        private void tbChosenMaterialPrice_Loaded(object sender, RoutedEventArgs e)
        {
            int price = Interior.MaterialPrices[interior.MaterialIndex];
            if (price != 0)
            {
                TextBlock tb = (TextBlock)sender;
                tb.Text = "+" + price.ToString("C", Formatting.CurrencyFormat);

            }
        }

        private void tbChosenMaterialDescription_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            tb.Text = Interior.MaterialDescriptions[interior.MaterialIndex];
        }



        private void tbChosenColorTitle_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            tb.Text = $"Belső tér színe: {interior.InteriorColor}";

        }

        private void tbChosenColorPrice_Loaded(object sender, RoutedEventArgs e)
        {

            int price = Interior.ColorPrices[interior.ColorIndex];
            if (price != 0)
            {
                TextBlock tb = (TextBlock)sender;
                tb.Text = "+" + price.ToString("C", Formatting.CurrencyFormat);
            }

        }

        private void tbChosenColorDescription_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            tb.Text = Interior.ColorDescriptions[interior.ColorIndex];

        }



        private void imgSeatHeating_Loaded(object sender, RoutedEventArgs e)
        {
            Image img = (Image)sender;
            if (interior.HasSeatHeating)
            {
                img.Source = new BitmapImage(new Uri("../../Assets/plus.png", UriKind.Relative));
            }
            else
            {
                img.Source = new BitmapImage(new Uri("../../Assets/minus.png", UriKind.Relative));
            }
        }

        private void tbSeatHeatingTitle_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            tb.Foreground = interior.HasSeatHeating ? Brushes.White : new SolidColorBrush(Color.FromArgb(255, 201, 201, 201));

        }

        private void tbSeatHeatingCost_Loaded(object sender, RoutedEventArgs e)
        {
            if (interior.HasSeatHeating)
            {
                TextBlock tb = (TextBlock)sender;
                tb.Text = Interior.SeatHeatingPrice.ToString("C", Formatting.CurrencyFormat);
            }
        }

        private void tbSeatHeatingDescription_Loaded(object sender, RoutedEventArgs e)
        {
            if (interior.HasSeatHeating)
            {
                TextBlock tb = (TextBlock)sender;
                tb.Text = Interior.SeatHeatingDescription;
            }
        }



        private void imgSteeringWheelHeating_Loaded(object sender, RoutedEventArgs e)
        {
            Image img = (Image)sender;
            if (interior.HasSteeringWheelHeating)
            {
                img.Source = new BitmapImage(new Uri("../../Assets/plus.png", UriKind.Relative));
            }
            else
            {
                img.Source = new BitmapImage(new Uri("../../Assets/minus.png", UriKind.Relative));
            }
        }

        private void tbSteeringWheelHeatingTitle_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            tb.Foreground = interior.HasSteeringWheelHeating ? Brushes.White : new SolidColorBrush(Color.FromArgb(255, 201, 201, 201));

        }


        private void tbSteeringWheelHeatingCost_Loaded(object sender, RoutedEventArgs e)
        {
            if (interior.HasSteeringWheelHeating)
            {
                TextBlock tb = (TextBlock)sender;
                tb.Text = Interior.SteeringWheelHeatingPrice.ToString("C", Formatting.CurrencyFormat);
            }
        }

        private void tbSteeringWheelHeatingDescription_Loaded(object sender, RoutedEventArgs e)
        {
            if (interior.HasSteeringWheelHeating)
            {
                TextBlock tb = (TextBlock)sender;
                tb.Text = Interior.SteeringWheelHeatingDescription;
            }
        }



        private void imgSpineSupport_Loaded(object sender, RoutedEventArgs e)
        {
            Image img = (Image)sender;
            if (interior.HasSpineSupport)
            {
                img.Source = new BitmapImage(new Uri("../../Assets/plus.png", UriKind.Relative));
            }
            else
            {
                img.Source = new BitmapImage(new Uri("../../Assets/minus.png", UriKind.Relative));
            }
        }

        private void tbSpineSupportTitle_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            tb.Foreground = interior.HasSpineSupport ? Brushes.White : new SolidColorBrush(Color.FromArgb(255, 201, 201, 201));

        }

        private void tbSpineSupportCost_Loaded(object sender, RoutedEventArgs e)
        {
            if (interior.HasSpineSupport)
            {
                TextBlock tb = (TextBlock)sender;
                tb.Text = Interior.SpineSupportPrice.ToString("C", Formatting.CurrencyFormat);
            }
        }

        private void tbSpineSupportDescription_Loaded(object sender, RoutedEventArgs e)
        {
            if (interior.HasSpineSupport)
            {
                TextBlock tb = (TextBlock)sender;
                tb.Text = Interior.SpineSupportDescription;
            }
        }



        private void imgSunlightProtection_Loaded(object sender, RoutedEventArgs e)
        {
            Image img = (Image)sender;
            if (interior.HasSunlightProtection)
            {
                img.Source = new BitmapImage(new Uri("../../Assets/plus.png", UriKind.Relative));
            }
            else
            {
                img.Source = new BitmapImage(new Uri("../../Assets/minus.png", UriKind.Relative));
            }
        }

        private void tbSunlightProtectionTitle_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            tb.Foreground = interior.HasSunlightProtection ? Brushes.White : new SolidColorBrush(Color.FromArgb(255, 201, 201, 201));

        }

        private void tbSunlightProtectionCost_Loaded(object sender, RoutedEventArgs e)
        {
            if (interior.HasSunlightProtection)
            {
                TextBlock tb = (TextBlock)sender;
                tb.Text = Interior.SunlightProtectionPrice.ToString("C", Formatting.CurrencyFormat);
            }
        }

        private void tbSunlightProtectionDescription_Loaded(object sender, RoutedEventArgs e)
        {
            if (interior.HasSunlightProtection)
            {
                TextBlock tb = (TextBlock)sender;
                tb.Text = Interior.SunlightProtectionDescription;
            }
        }



        private void imgDarkenedWindows_Loaded(object sender, RoutedEventArgs e)
        {
            Image img = (Image)sender;
            if (interior.HasDarkenedWindows)
            {
                img.Source = new BitmapImage(new Uri("../../Assets/plus.png", UriKind.Relative));
            }
            else
            {
                img.Source = new BitmapImage(new Uri("../../Assets/minus.png", UriKind.Relative));
            }
        }

        private void tbDarkenedWindowsTitle_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            tb.Foreground = interior.HasDarkenedWindows ? Brushes.White : new SolidColorBrush(Color.FromArgb(255, 201, 201, 201));
        }

        private void tbDarkenedWindowsCost_Loaded(object sender, RoutedEventArgs e)
        {
            if (interior.HasDarkenedWindows)
            {
                TextBlock tb = (TextBlock)sender;
                tb.Text = Interior.DarkenedWindowsPrice.ToString("C", Formatting.CurrencyFormat);
            }
        }

        private void tbDarkenedWindowsDescription_Loaded(object sender, RoutedEventArgs e)
        {
            if (interior.HasDarkenedWindows)
            {
                TextBlock tb = (TextBlock)sender;
                tb.Text = Interior.DarkenedWindowsDescription;
            }
        }
    }
}
