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
    public partial class PaintingPage : PageBase
    {
        public PaintingPage()
        {
            InitializeComponent();
            PageTitle.SetTitle("Fényezés kiválasztása");
            Application.Current.MainWindow.MinWidth = 280;
        }

        private void Windows_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Windows.Title = $"{Windows.ActualWidth} x {Windows.ActualHeight}";

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

        private void rbColorSet_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton currentColor = (RadioButton)sender;
            if (currentColor.Name == "rbColor1")
            {
                Infos.SetInfo(Painting.ColorDescriptions[0]);
                Infos.SetPrice("Alap festés");
            }
            if (currentColor.Name == "rbColor2")
            {
                Infos.SetInfo(Painting.ColorDescriptions[1]);
                Infos.SetPrice($"Ára: {Painting.Prices[1].ToString("C", Formatting.CurrencyFormat)}");
            }
            if (currentColor.Name == "rbColor3")
            {
                Infos.SetInfo(Painting.ColorDescriptions[2]);
                Infos.SetPrice($"Ára: {Painting.Prices[2].ToString("C", Formatting.CurrencyFormat)}");
            }
            if (currentColor.Name == "rbColor4")
            {
                Infos.SetInfo(Painting.ColorDescriptions[3]);
                Infos.SetPrice($"Ára: {Painting.Prices[3].ToString("C", Formatting.CurrencyFormat)}");
            }
            if (currentColor.Name == "rbColor5")
            {
                Infos.SetInfo(Painting.ColorDescriptions[4]);
                Infos.SetPrice($"Ára: {Painting.Prices[4].ToString("C", Formatting.CurrencyFormat)}");
            }

            if (Config == null)
            {
                return;
            }

            byte index = (byte)(byte.Parse(currentColor.Name.Replace("rbColor", "")) - 1);
            Config.Painting.ColorIndex = index;
        }

        public override void OnAttachedToFrame()
        {
            byte chosenColorIndex = Config?.Painting?.ColorIndex ?? 0;
            RadioButton selected = null;

            if (chosenColorIndex == 0)
            {
                selected = rbColor1;
            }

            if (chosenColorIndex == 1)
            {
                selected = rbColor2;
            }

            if (chosenColorIndex == 2)
            {
                selected = rbColor3;
            }

            if (chosenColorIndex == 3)
            {
                selected = rbColor4;
            }

            if (chosenColorIndex == 4)
            {
                selected = rbColor5;
            }

            if (selected == null)
            {
                return;
            }
            selected.IsChecked = true;
        }
    }
}
