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
        private List<string[]> chosenTransmissionTexts;


        public TransmissionConfiguration()
        {
            chosenTransmissionTexts = new List<string[]>()
            {
                new string[2]{ Transmission.TransmissionDescriptions[0], "Alapból jár hozzá" },
                new string[2]{ Transmission.TransmissionDescriptions[1], $"Ára: {Transmission.Prices[1]}FT" },
            };
            InitializeComponent();


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
            string[] texts = chosenTransmissionTexts[index];
            tbInfos.Text = texts[0];
            tbPrice.Text = texts[1];
            if (Config == null)
            {
                return;
            }
            Config.Transmission.TypeIndex = index;
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
    }
}
