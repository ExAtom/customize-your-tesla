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
    public partial class InteriorPage : PageBase
    {
        public InteriorPage()
        {
            InitializeComponent();
            PageTitle.SetTitle("Belső kiválasztása");
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
            byte chosenMaterialIndex = Config?.Interior?.MaterialIndex ?? 0;
            byte chosenColorIndex = Config?.Interior?.ColorIndex ?? 0;
            RadioButton selected = null;

            if (chosenMaterialIndex == 0)
            {
                selected = iMaterial1;
            }
            if (chosenMaterialIndex == 1)
            {
                selected = iMaterial2;
            }
            if (chosenMaterialIndex == 2)
            {
                selected = iMaterial3;
            }
            if (chosenMaterialIndex == 3)
            {
                selected = iMaterial4;
            }
            selected.IsChecked = true;

            if (chosenColorIndex == 0)
            {
                selected = iColor1;
            }
            if (chosenColorIndex == 1)
            {
                selected = iColor2;
            }
            if (chosenColorIndex == 2)
            {
                selected = iColor3;
            }

            if (selected == null)
            {
                return;
            }
            selected.IsChecked = true;

            seatHeating.IsChecked = Config.Interior.HasSeatHeating;
            stearingWheelHeating.IsChecked = Config.Interior.HasSteeringWheelHeating;
            spineSupport.IsChecked = Config.Interior.HasSpineSupport;
            sunlightProtection.IsChecked = Config.Interior.HasSunlightProtection;
            darkenedWindows.IsChecked = Config.Interior.HasDarkenedWindows;
        }

        private void iRadioSet_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton currentButton = (RadioButton)sender;

            if (currentButton.Name == "iMaterial1")
            {
                Infos.SetInfo(Interior.MaterialDescriptions[0]);
                Infos.SetPrice($"Ára: Alap anyag");
            }
            if (currentButton.Name == "iMaterial2")
            {
                Infos.SetInfo(Interior.MaterialDescriptions[1]);
                Infos.SetPrice($"Ára: {Interior.MaterialPrices[1].ToString("C", Formatting.CurrencyFormat)}");
            }
            if (currentButton.Name == "iMaterial3")
            {
                Infos.SetInfo(Interior.MaterialDescriptions[2]);
                Infos.SetPrice($"Ára: {Interior.MaterialPrices[2].ToString("C", Formatting.CurrencyFormat)}");
            }
            if (currentButton.Name == "iMaterial4")
            {
                Infos.SetInfo(Interior.MaterialDescriptions[3]);
                Infos.SetPrice($"Ára: {Interior.MaterialPrices[3].ToString("C", Formatting.CurrencyFormat)}");
            }
            if (currentButton.Name == "iColor1")
            {
                Infos.SetInfo(Interior.ColorDescriptions[0]);
                Infos.SetPrice($"Ára: Alap szín");
            }
            if (currentButton.Name == "iColor2")
            {
                Infos.SetInfo(Interior.ColorDescriptions[1]);
                Infos.SetPrice($"Ára: {Interior.ColorPrices[1].ToString("C", Formatting.CurrencyFormat)}");
            }
            if (currentButton.Name == "iColor3")
            {
                Infos.SetInfo(Interior.ColorDescriptions[2]);
                Infos.SetPrice($"Ára: {Interior.ColorPrices[2].ToString("C", Formatting.CurrencyFormat)}");
            }

            if (Config == null)
            {
                return;
            }

            if (currentButton.GroupName == "materials")
            {
                byte index = (byte)(byte.Parse(currentButton.Name.Replace("iMaterial", "")) - 1);
                Config.Interior.MaterialIndex = index;
            }
            if (currentButton.GroupName == "colors")
            {
                byte index = (byte)(byte.Parse(currentButton.Name.Replace("iColor", "")) - 1);
                Config.Interior.ColorIndex = index;
            }
        }
        private void iCheckboxSet_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox currentButton = (CheckBox)sender;

            if (currentButton.Name == "seatHeating")
            {
                Infos.SetInfo(Interior.SeatHeatingDescription);
                Infos.SetPrice($"Ára: {Interior.SeatHeatingPrice.ToString("C", Formatting.CurrencyFormat)}");
            }
            if (currentButton.Name == "stearingWheelHeating")
            {
                Infos.SetInfo(Interior.SteeringWheelHeatingDescription);
                Infos.SetPrice($"Ára: {Interior.SteeringWheelHeatingPrice.ToString("C", Formatting.CurrencyFormat)}");
            }
            if (currentButton.Name == "spineSupport")
            {
                Infos.SetInfo(Interior.SpineSupportDescription);
                Infos.SetPrice($"Ára: {Interior.SpineSupportPrice.ToString("C", Formatting.CurrencyFormat)}");
            }
            if (currentButton.Name == "sunlightProtection")
            {
                Infos.SetInfo(Interior.SunlightProtectionDescription);
                Infos.SetPrice($"Ára: {Interior.SunlightProtectionPrice.ToString("C", Formatting.CurrencyFormat)}");
            }
            if (currentButton.Name == "darkenedWindows")
            {
                Infos.SetInfo(Interior.DarkenedWindowsDescription);
                Infos.SetPrice($"Ára: {Interior.DarkenedWindowsPrice.ToString("C", Formatting.CurrencyFormat)}");
            }

            if (Config == null)
            {
                return;
            }

            string setting = currentButton.Name;
            switch (setting)
            {
                case "seatHeating":
                    Config.Interior.HasSeatHeating = seatHeating.IsChecked == true;
                    break;
                case "stearingWheelHeating":
                    Config.Interior.HasSteeringWheelHeating = stearingWheelHeating.IsChecked == true;
                    break;
                case "spineSupport":
                    Config.Interior.HasSpineSupport = spineSupport.IsChecked == true;
                    break;
                case "sunlightProtection":
                    Config.Interior.HasSunlightProtection = sunlightProtection.IsChecked == true;
                    break;
                case "darkenedWindows":
                    Config.Interior.HasDarkenedWindows = darkenedWindows.IsChecked == true;
                    break;
            }
        }
    }
}
