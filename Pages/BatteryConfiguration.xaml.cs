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
        public BatteryConfiguration()
        {
            InitializeComponent();
            PageTitle.SetTitle("Akkumulátor kiválasztása");
            Application.Current.MainWindow.MinWidth = 280;
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
            if (rb.Name == "rbBatteryType0")
            {
                Infos.SetInfo(Battery.CapacityDescriptions[0]);
                Infos.SetPrice($"Ára: {Battery.Prices[0].ToString("C", Formatting.CurrencyFormat)}");
            }
            if (rb.Name == "rbBatteryType1")
            {
                Infos.SetInfo(Battery.CapacityDescriptions[1]);
                Infos.SetPrice($"Ára: {Battery.Prices[1].ToString("C", Formatting.CurrencyFormat)}");
            }
            if (rb.Name == "rbBatteryType2")
            {
                Infos.SetInfo(Battery.CapacityDescriptions[2]);
                Infos.SetPrice($"Ára: {Battery.Prices[2].ToString("C", Formatting.CurrencyFormat)}");
            }
            if (rb.Name == "rbBatteryType3")
            {
                Infos.SetInfo(Battery.CapacityDescriptions[3]);
                Infos.SetPrice($"Ára: {Battery.Prices[3].ToString("C", Formatting.CurrencyFormat)}");
            }
            if (rb.Name == "rbBatteryType4")
            {
                Infos.SetInfo(Battery.CapacityDescriptions[4]);
                Infos.SetPrice($"Ára: {Battery.Prices[4].ToString("C", Formatting.CurrencyFormat)}");
            }
            if (rb.Name == "rbBatteryType5")
            {
                Infos.SetInfo(Battery.CapacityDescriptions[5]);
                Infos.SetPrice($"Ára: {Battery.Prices[5].ToString("C", Formatting.CurrencyFormat)}");
            }

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
                Menu.Width = 430;
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
    }
}
