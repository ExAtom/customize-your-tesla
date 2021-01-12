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
    public partial class ExteriorPage : PageBase
    {
        public ExteriorPage()
        {
            InitializeComponent();
            PageTitle.SetTitle("Külső kiválasztása");
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
            linenRoof.IsChecked = Config.Exterior.HasLinenRoof;
            spoilers.IsChecked = Config.Exterior.HasSpoilers;
            bottomLights.IsChecked = Config.Exterior.HasBottomLights;
        }

        private void exteriorSet_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox currentButton = (CheckBox)sender;
            if (currentButton.Name == "linenRoof")
            {
                Infos.SetInfo(Exterior.LinenRoofDescription);
                Infos.SetPrice($"Ára: {Exterior.LinenRoofPrice.ToString("C", Formatting.CurrencyFormat)}");
            }
            if (currentButton.Name == "spoilers")
            {
                Infos.SetInfo(Exterior.SpoilersDescription);
                Infos.SetPrice($"Ára: {Exterior.SpoilersPrice.ToString("C", Formatting.CurrencyFormat)}");
            }
            if (currentButton.Name == "bottomLights")
            {
                Infos.SetInfo(Exterior.BottomLightsDescription);
                Infos.SetPrice($"Ára: {Exterior.BottomLightsPrice.ToString("C", Formatting.CurrencyFormat)}");
            }

            if (Config == null)
            {
                return;
            }

            string setting = currentButton.Name;
            switch (setting)
            {
                case "linenRoof":
                    Config.Exterior.HasLinenRoof = linenRoof.IsChecked == true;
                    break;
                case "spoilers":
                    Config.Exterior.HasSpoilers = spoilers.IsChecked == true;
                    break;
                case "bottomLights":
                    Config.Exterior.HasBottomLights = bottomLights.IsChecked == true;
                    break;
            }
        }
    }
}
