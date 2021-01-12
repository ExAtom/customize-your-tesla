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
using TeslaCarConfigurator.Helpers;

namespace TeslaCarConfigurator.Pages
{
    public partial class WheelConfiguration : PageBase
    {
        public WheelConfiguration()
        {
            InitializeComponent();
            PageTitle.SetTitle("Keréktípus kiválasztása");
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
            byte chosenTypeIndex = Config?.Wheels?.TypeIndex ?? 0;
            RadioButton selected = null;

            if (chosenTypeIndex == 0)
            {
                selected = rbWheel1;
            }

            if (chosenTypeIndex == 1)
            {
                selected = rbWheel2;
            }

            if (chosenTypeIndex == 2)
            {
                selected = rbWheel3;
            }

            if (chosenTypeIndex == 3)
            {
                selected = rbWheel4;
            }

            if (selected == null)
            {
                return;
            }
            selected.IsChecked = true;
        }

        private void rbWheelSet_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton currentButton = (RadioButton)sender;
            if (currentButton.Name == "rbWheel1")
            {
                Infos.SetInfo(Data.WheelConfiguration.WheelDescriptions[0]);
                Infos.SetPrice($"Ára: {Data.WheelConfiguration.Prices[0].ToString("C", Formatting.CurrencyFormat)}");
            }
            if (currentButton.Name == "rbWheel2")
            {
                Infos.SetInfo(Data.WheelConfiguration.WheelDescriptions[1]);
                Infos.SetPrice($"Ára: {Data.WheelConfiguration.Prices[1].ToString("C", Formatting.CurrencyFormat)}");
            }
            if (currentButton.Name == "rbWheel3")
            {
                Infos.SetInfo(Data.WheelConfiguration.WheelDescriptions[2]);
                Infos.SetPrice($"Ára: {Data.WheelConfiguration.Prices[2].ToString("C", Formatting.CurrencyFormat)}");
            }
            if (currentButton.Name == "rbWheel4")
            {
                Infos.SetInfo(Data.WheelConfiguration.WheelDescriptions[3]);
                Infos.SetPrice($"Ára: {Data.WheelConfiguration.Prices[3].ToString("C", Formatting.CurrencyFormat)}");
            }

            if (Config == null)
            {
                return;
            }

            byte index = (byte)(byte.Parse(currentButton.Name.Replace("rbWheel", "")) - 1);
            Config.Wheels.TypeIndex = index;
        }
    }


}
