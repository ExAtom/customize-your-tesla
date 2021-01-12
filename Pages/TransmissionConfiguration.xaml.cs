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
    public partial class TransmissionConfiguration : PageBase
    {
        public TransmissionConfiguration()
        {
            InitializeComponent();
            PageTitle.SetTitle("Váltótípus kiválasztása");
            Application.Current.MainWindow.MinWidth = 280;
        }

        public override void OnAttachedToFrame()
        {
            byte chosenTransmission = Config?.Transmission?.TypeIndex ?? 0;
            Viewbox selectedVb = (Viewbox)transmissionOptionsContainer.Children[chosenTransmission];
            RadioButton selected = (RadioButton)selectedVb.Child;
            selected.IsChecked = true;
        }

        private void rbTransmissionType_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            string name = rb.Name;
            byte index = byte.Parse(name.Replace("rbTransmissionType", ""));

            if (rb.Name == "rbTransmissionType0")
            {
                Infos.SetInfo(Transmission.TransmissionDescriptions[0]);
                Infos.SetPrice($"Alapból jár hozzá");
            }
            if (rb.Name == "rbTransmissionType1")
            {
                Infos.SetInfo(Transmission.TransmissionDescriptions[1]);
                Infos.SetPrice($"Ára: {Transmission.Prices[1].ToString("C", Formatting.CurrencyFormat)}");
            }

            if (Config == null)
            {
                return;
            }

            Config.Transmission.TypeIndex = index;

            if (index == 0)
            {
                Config.SoftwareFeatures.HasSelfdriving = false;
            }
        }

        private void Windows_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (Windows.ActualWidth <= 710)
            {
                spMenu.Width = Double.NaN;
                Panel menuParent = (Panel)spMenu.Parent;
                if (menuParent != null && menuParent != MobileContainer)
                {
                    menuParent.Children.Remove(spMenu);
                    MobileContainer.Children.Add(spMenu);
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
                spMenu.Width = 400;
                Panel menuParent = (Panel)spMenu.Parent;
                if (menuParent != null && menuParent != DesktopContainer)
                {
                    menuParent.Children.Remove(spMenu);
                    DesktopContainer.Children.Add(spMenu);
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
    }
}
