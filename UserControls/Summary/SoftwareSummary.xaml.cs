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
    public partial class SoftwareSummary : UserControl
    {
        private SoftwareFeatures software;

        public SoftwareSummary(SoftwareFeatures software)
        {
            InitializeComponent();
            this.software = software;
        }

        private void tbPrice_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tbPrice = (TextBlock)sender;
            int prices = software.CalculateAdditionalPrices();
            if (prices == 0)
            {
                return;
            }

            tbPrice.Text = "+" + prices.ToString("C", Formatting.CurrencyFormat);
        }

        private void imgSelfdriving_Loaded(object sender, RoutedEventArgs e)
        {
            Image img = (Image)sender;
            if (software.HasSelfdriving)
            {
                img.Source = new BitmapImage(new Uri("../../Assets/plus.png", UriKind.Relative));
            }
            else
            {
                img.Source = new BitmapImage(new Uri("../../Assets/minus.png", UriKind.Relative));
            }
        }

        private void tbSelfdrivingTitle_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            tb.Foreground = software.HasSelfdriving ? Brushes.White : new SolidColorBrush(Color.FromArgb(255, 201, 201, 201));
        }

        private void tbSelfdrivingPrice_Loaded(object sender, RoutedEventArgs e)
        {
            if (software.HasSelfdriving)
            {
                TextBlock tb = (TextBlock)sender;
                tb.Text = "+" + SoftwareFeatures.SelfdrivingPrice.ToString("C", Formatting.CurrencyFormat);
            }
        }

        private void tbSelfdrivingDescription_Loaded(object sender, RoutedEventArgs e)
        {
            if (software.HasSelfdriving)
            {
                TextBlock tb = (TextBlock)sender;
                tb.Text = SoftwareFeatures.SelfdrivingDescription;
            }
        }



        private void imgGps_Loaded(object sender, RoutedEventArgs e)
        {
            Image img = (Image)sender;
            if (software.HasGps)
            {
                img.Source = new BitmapImage(new Uri("../../Assets/plus.png", UriKind.Relative));
            }
            else
            {
                img.Source = new BitmapImage(new Uri("../../Assets/minus.png", UriKind.Relative));
            }
        }

        private void tbGpsTitle_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            tb.Foreground = software.HasGps ? Brushes.White : new SolidColorBrush(Color.FromArgb(255, 201, 201, 201));
        }

        private void tbGpsPrice_Loaded(object sender, RoutedEventArgs e)
        {
            if (software.HasGps)
            {
                TextBlock tb = (TextBlock)sender;
                tb.Text = "+" + SoftwareFeatures.GpsPrice.ToString("C", Formatting.CurrencyFormat);
            }
        }

        private void tbGpsDescription_Loaded(object sender, RoutedEventArgs e)
        {
            if (software.HasGps)
            {
                TextBlock tb = (TextBlock)sender;
                tb.Text = SoftwareFeatures.GpsDescription;
            }
        }



        private void imgHeadlightAssistant_Loaded(object sender, RoutedEventArgs e)
        {
            Image img = (Image)sender;
            if (software.HasHeadlightAssistant)
            {
                img.Source = new BitmapImage(new Uri("../../Assets/plus.png", UriKind.Relative));
            }
            else
            {
                img.Source = new BitmapImage(new Uri("../../Assets/minus.png", UriKind.Relative));
            }
        }

        private void tbHeadlightAssistantTitle_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            tb.Foreground = software.HasHeadlightAssistant ? Brushes.White : new SolidColorBrush(Color.FromArgb(255, 201, 201, 201));
        }

        private void tbHeadlightAssistantPrice_Loaded(object sender, RoutedEventArgs e)
        {
            if (software.HasHeadlightAssistant)
            {
                TextBlock tb = (TextBlock)sender;
                tb.Text = "+" + SoftwareFeatures.HeadlightAssistantPrice.ToString("C", Formatting.CurrencyFormat);
            }
        }

        private void tbHeadlightAssistantDescription_Loaded(object sender, RoutedEventArgs e)
        {
            if (software.HasHeadlightAssistant)
            {
                TextBlock tb = (TextBlock)sender;
                tb.Text = SoftwareFeatures.HeadlightAssistantDescription;
            }
        }



        private void imgAdaptiveLights_Loaded(object sender, RoutedEventArgs e)
        {
            Image img = (Image)sender;
            if (software.HasAdaptiveLights)
            {
                img.Source = new BitmapImage(new Uri("../../Assets/plus.png", UriKind.Relative));
            }
            else
            {
                img.Source = new BitmapImage(new Uri("../../Assets/minus.png", UriKind.Relative));
            }
        }

        private void tbAdaptiveLightsTitle_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            tb.Foreground = software.HasAdaptiveLights ? Brushes.White : new SolidColorBrush(Color.FromArgb(255, 201, 201, 201));
        }

        private void tbAdaptiveLightsPrice_Loaded(object sender, RoutedEventArgs e)
        {
            if (software.HasAdaptiveLights)
            {
                TextBlock tb = (TextBlock)sender;
                tb.Text = "+" + SoftwareFeatures.AdaptiveLightsPrice.ToString("C", Formatting.CurrencyFormat);
            }
        }

        private void tbAdaptiveLightsDescription_Loaded(object sender, RoutedEventArgs e)
        {
            if (software.HasAdaptiveLights)
            {
                TextBlock tb = (TextBlock)sender;
                tb.Text = SoftwareFeatures.AdaptiveLightsDescription;
            }
        }
    }
}
