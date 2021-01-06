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
    /// Interaction logic for InteriorPage.xaml
    /// </summary>
    public partial class InteriorPage : PageBase
    {
        public InteriorPage()
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
            byte chosenTypeIndex = Config?.Interior?.MaterialIndex ?? 0;
            RadioButton selected = null;

            if (chosenTypeIndex == 0)
            {
                selected = iMaterial1;
            }

            if (chosenTypeIndex == 1)
            {
                selected = iMaterial2;
            }

            if (chosenTypeIndex == 2)
            {
                selected = iMaterial3; 
            }

            if (chosenTypeIndex == 3)
            {
                selected = iMaterial4;
            }

            if (selected == null)
            {
                return;
            }
            selected.IsChecked = true;
        }

        private void iMaterialSet_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton currentButton = (RadioButton)sender;
            if (currentButton.Name == "iMaterial1")
            {
                tbInfos.Text = "Az Aero FX530-as típusú kereket legfőképpen városi közlekedésre ajánljuk. Kiváló tapadást bitosít az aszfalhot, így a hirtelen fékezések sem okozhatnak problémát.";
                tbPrice.Text = "Ára: 25.000 Ft";
            }
            if (currentButton.Name == "iMaterial2")
            {
                tbInfos.Text = "A Sport SP002-őt nevéhez híven olyanoknak ajánjuk, akik szeretik a sebességhatárt túllépni, akár versenyzés közben. A 20\"-as kerékátmérő biztosítja a 450 km/h-ás sebesség elérését.";
                tbPrice.Text = "Ára: 82.000 Ft";
            }
            if (currentButton.Name == "iMaterial3")
            {
                tbInfos.Text = "A Turbine T54-es tipikusan az a kerék, melyet terepviszonyokra terveztek. Az 50 cm-es kerékvastagság és a speciális rovátkázsának köszönhetően homokban, hóban, mocsárban sincs akadály.";
                tbPrice.Text = "Ára: 56.000 Ft";
            }
            if (currentButton.Name == "iMaterial4")
            {
                tbInfos.Text = "A Silver SU478-as típus különlegessége speciális kialakítása révén, hogy téli és nyári abroncsként egyaránt funkciónál, így nem kell azt cserélgetni. Leginkább városi és országúti terepre ajánljuk.";
                tbPrice.Text = "Ára: 69.000 Ft";
            }

            if (Config == null)
            {
                return;
            }

            byte index = (byte)(byte.Parse(currentButton.Name.Replace("iMaterial", "")) - 1);
            Config.Interior.MaterialIndex = index;
        }
    }


}
