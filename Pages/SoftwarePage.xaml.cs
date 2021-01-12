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
    public partial class SoftwarePage : PageBase
    {
        public SoftwarePage()
        {
            InitializeComponent();
            PageTitle.SetTitle("Szoftverek kiválasztása");
            Application.Current.MainWindow.MinWidth = 280;
        }

        private void Windows_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            if (Windows.ActualWidth <= 710)
            {
                Menu.Width = Double.NaN;
                Panel menuParent = (Panel)Menu.Parent;
                if (menuParent != null && menuParent != MobileContainer)
                {
                    menuParent.Children.Remove(Menu);
                    MobileContainer.Children.Add(Menu);
                }

                Panel infosParent = (Panel)Infos.Parent;
                if (menuParent != null && infosParent != MobileContainer)
                {
                    infosParent.Children.Remove(Infos);
                    MobileContainer.Children.Add(Infos);
                }
                Infos.SwitchToMobile();
                PageTitle.SwitchToMobile();
            }
            else
            {
                Menu.Width = 400;
                Panel menuParent = (Panel)Menu.Parent;
                if (menuParent != null && menuParent != DesktopContainer)
                {
                    menuParent.Children.Remove(Menu);
                    DesktopContainer.Children.Add(Menu);
                }

                Panel infosParent = (Panel)Infos.Parent;
                if (menuParent != null && infosParent != DesktopContainer)
                {
                    infosParent.Children.Remove(Infos);
                    DesktopContainer.Children.Add(Infos);
                }
                Infos.SwitchToDesktop();
                PageTitle.SwitchToDesktop();
            }

        }

        public override void OnAttachedToFrame()
        {
            selfdriving.IsChecked = Config.SoftwareFeatures.HasSelfdriving;
            gps.IsChecked = Config.SoftwareFeatures.HasGps;
            headlightAssistant.IsChecked = Config.SoftwareFeatures.HasHeadlightAssistant;
            adaptiveLights.IsChecked = Config.SoftwareFeatures.HasAdaptiveLights;
            selfdriving.IsEnabled = Config.Transmission.TypeIndex != 0;
        }

        private void softwareSet_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox currentButton = (CheckBox)sender;

            if (currentButton.Name == "selfdriving")
            {
                Infos.SetInfo(SoftwareFeatures.SelfdrivingDescription);
                Infos.SetPrice($"Ára: {SoftwareFeatures.SelfdrivingPrice.ToString("C", Formatting.CurrencyFormat)}");
            }
            if (currentButton.Name == "gps")
            {
                Infos.SetInfo(SoftwareFeatures.GpsDescription);
                Infos.SetPrice($"Ára: {SoftwareFeatures.GpsPrice.ToString("C", Formatting.CurrencyFormat)}");
            }
            if (currentButton.Name == "headlightAssistant")
            {
                Infos.SetInfo(SoftwareFeatures.HeadlightAssistantDescription);
                Infos.SetPrice($"Ára: {SoftwareFeatures.HeadlightAssistantPrice.ToString("C", Formatting.CurrencyFormat)}");
            }
            if (currentButton.Name == "adaptiveLights")
            {
                Infos.SetInfo(SoftwareFeatures.AdaptiveLightsDescription);
                Infos.SetPrice($"Ára: {SoftwareFeatures.AdaptiveLightsPrice.ToString("C", Formatting.CurrencyFormat)}");
            }

            if (Config == null)
            {
                return;
            }

            string setting = currentButton.Name;
            switch (setting)
            {
                case "selfdriving":
                    Config.SoftwareFeatures.HasSelfdriving = selfdriving.IsChecked == true;
                    break;
                case "gps":
                    Config.SoftwareFeatures.HasGps = gps.IsChecked == true;
                    break;
                case "headlightAssistant":
                    Config.SoftwareFeatures.HasHeadlightAssistant = headlightAssistant.IsChecked == true;
                    break;
                case "adaptiveLights":
                    Config.SoftwareFeatures.HasAdaptiveLights = adaptiveLights.IsChecked == true;
                    break;
            }
        }
    }
}
