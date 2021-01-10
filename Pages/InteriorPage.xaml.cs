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
                tbInfos.Text = "A bio műanyag egy erősebb és környezetkímélőbb alternatíva. A textúrájának kidolgozása az aszfaltra hasonlít, ezzel egyé válhat az úttal, amin éppen halad.";
                tbPrice.Text = "Alap anyag";
            }
            if (currentButton.Name == "iMaterial2")
            {
                tbInfos.Text = "Az öntött fa nem igazi fa, külseje üveges, de ez adja át a legtermészetesebb hatást. Mintha csak visszautaztunk volna az időben, de az autó megtartja prémium érzetét.";
                tbPrice.Text = "Ára: 560.000 Ft";
            }
            if (currentButton.Name == "iMaterial3")
            {
                tbInfos.Text = "A jegelt üveg egy speciális felületcsiszolással készül, ezzel erősítve magát az anyagot, valamint az ujjlenyomatoktól is védi. A végeredmény egy hó textúrájára hasonlít. A legjobb választás téli kocsikázásra.";
                tbPrice.Text = "Ára: 665.000 Ft";
            }
            if (currentButton.Name == "iMaterial4")
            {
                tbInfos.Text = "A krokodilbőr a legritkább fajtájú, Gangeszi aprókrokodil bőre. Elképesztően jóminőségű, tapintása eszméletlen és a szaga új autójéra hasonlít.";
                tbPrice.Text = "Ára: 1.029.000 Ft";
            }

            if (currentButton.Name == "iColor1")
            {
                tbInfos.Text = "Fekete. Milyen egyszerű. Milyen elegáns. Egyszerűen tökéletes. Az űrre és annak végtelenül csodálatosságára emlékeztet. Csodás választás.";
                tbPrice.Text = "Alap szín";
            }
            if (currentButton.Name == "iColor2")
            {
                tbInfos.Text = "A fehér kitisztultság, felsőbbrendűségre sugall. Vezetés közben páratlanul kiemelkedő érzése lehet a vezetőnek.";
                tbPrice.Text = "Ára: 500.000 Ft";
            }
            if (currentButton.Name == "iColor3")
            {
                tbInfos.Text = "A barna a legtermészetesebb színünk. Az öntött fával vagy krokodilbőrrel együtt teljes az összhatás. Klasszikus és csodás.";
                tbPrice.Text = "Ára: 600.000 Ft";
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
                tbInfos.Text = "Ülés fűtés és hűtés. Bármilyen idő legyen kint, a legkényelmesebb vezetést nyújtja.";
                tbPrice.Text = "Ára: 150.000 Ft";
            }
            if (currentButton.Name == "stearingWheelHeating")
            {
                tbInfos.Text = "Kormánykerék fűtése és hűtése. Reggeli induláskor gyakran kényelmetlenül forró vagy hideg lehet a kormány, így az nehezíti a kormányzást. Ennek megoldása ez a beállítás.";
                tbPrice.Text = "Ára: 110.000 Ft";
            }
            if (currentButton.Name == "spineSupport")
            {
                tbInfos.Text = "Hosszú utakon nagyban segíthet a gerinctámasz beszerelése. Britt tudósok szerint még a látása is javul tőle.";
                tbPrice.Text = "Ára: 69.420 Ft";
            }
            if (currentButton.Name == "sunlightProtection")
            {
                tbInfos.Text = "Elég lesz a borzalmas műanyag fényvisszaverő lapokból, amiket senki se bír normálisan az ablkba. Ez az új technológia az autó kikapcsolásakor elsőtétíti az ablakokat, amin kereszül a napfény nem jut be az autóba.";
                tbPrice.Text = "Ára: 650.000 Ft";
            }
            if (currentButton.Name == "darkenedWindows")
            {
                tbInfos.Text = "Kívülről senki se lát be, de belülről ki lát mindenki. Az eleganciapontja is kiemelkedően növekszik a járműnek ennek használatakor.";
                tbPrice.Text = "Ára: 190.000 Ft";
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
