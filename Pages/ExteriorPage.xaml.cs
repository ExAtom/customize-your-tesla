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
    /// <summary>
    /// Interaction logic for ExteriorPage.xaml
    /// </summary>
    public partial class ExteriorPage : PageBase
    {
        public ExteriorPage()
        {
            InitializeComponent();
        }

        private void Windows_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            if (Windows.ActualWidth <= 710)
            {
                Menu.Width = 230;
            }
            else
            {
                Menu.Width = 400;
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
                tbInfos.Text = "A vászontető napjaink legdivatosabb autókialakítása. Nagy sebességnél kellemes hangot kelt. A mi vászontetőnk viszont nem csak divatos, de speciális funkciója is van. Gombonymásra visszahúzódik a csomagtartóba és nyitott lesz az utastér.";
                tbPrice.Text = "Ára: 13.900.000 Ft";
            }
            if (currentButton.Name == "spoilers")
            {
                tbInfos.Text = "Spoilerek a hiányzó tapadást hozzák létre, így sokkal gyorsabban száguldozhat autójával, mint egyébként. Automatikusan állítja az autó szoftvere az állásukat, így lassításnál még nagyobb segítséget nyújt.";
                tbPrice.Text = "Ára: 5.600.000 Ft";
            }
            if (currentButton.Name == "bottomLights")
            {
                tbInfos.Text = "Azoknak ajánljuk, akik szeretnek kitűnni a tömegből. Egy LED sor világítja ki az autó alját, így önt jobban láthatják a sötétben és sokkal ütősebb lesz a megjelenése.";
                tbPrice.Text = "Ára: 1.200.000 Ft";
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
