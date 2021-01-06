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
                tbInfos.Text = "A bio műanyag egy erősebb és környezetkímélőbb alternatíva. A textúrájának kidolgozása az aszfaltra hasonlít, ezzel egyé válhat az úttal, amin éppen halad.";
                tbPrice.Text = "Alap anyag";
            }
            if (currentButton.Name == "iMaterial2")
            {
                tbInfos.Text = "Az öntött fa nem igazi fa, külseje üveges, de ez adja át a legtermészetesebb hatást. Mintha csak visszautaztunk volna az időben, de az autó megtartja prémium érzetét.";
                tbPrice.Text = "Ára: 5600.000 Ft";
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

            if (Config == null)
            {
                return;
            }

            byte index = (byte)(byte.Parse(currentButton.Name.Replace("iMaterial", "")) - 1);
            Config.Interior.MaterialIndex = index;
        }
    }


}
