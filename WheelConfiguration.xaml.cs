﻿using System;
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

namespace TeslaCarConfigurator
{
    /// <summary>
    /// Interaction logic for WheelConfiguration.xaml
    /// </summary>
    public partial class WheelConfiguration : PageBase
    {
        public WheelConfiguration()
        {
            InitializeComponent();
        }

        private void Windows_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Windows.Title = $"{Windows.ActualWidth} x {Windows.ActualHeight}";

            if (Windows.ActualWidth <= 710)
            {
                Menu.Width = 230;
            }
            else
            {
                Menu.Width = 400;
            }

            //Router.ChangeCurrentPage(new WheelConfiguration());
            //Config.Wheels
        }

        private void rbWheelSet_Click(object sender, RoutedEventArgs e)
        {
            RadioButton currentButton = (RadioButton)sender;
            if (currentButton.Name == "rbWheel1")
            {
                tbInfos.Text = "Az Aero FX530-as típusú kereket legfőképpen városi közlekedésre ajánljuk. Kiváló tapadást bitosít az aszfalhot, így a hirtelen fékezések sem okozhatnak problémát.";
                tbPrice.Text = "Ára: 25.000 Ft";
            }
            if (currentButton.Name == "rbWheel2")
            {
                tbInfos.Text = "A Sport SP002-őt nevéhez híven olyanoknak ajánjuk, akik szeretik a sebességhatárt túllépni, akár versenyzés közben. A 20\"-as kerékátmérő biztosítja a 450 km/h-ás sebesség elérését.";
                tbPrice.Text = "Ára: 82.000 Ft";
            }
            if (currentButton.Name == "rbWheel3")
            {
                tbInfos.Text = "A Turbine T54-es tipikusan az a kerék, melyet terepviszonyokra terveztek. Az 50 cm-es kerékvastagság és a speciális rovátkázsának köszönhetően homokban, hóban, mocsárban sincs akadály.";
                tbPrice.Text = "Ára: 56.000 Ft";
            }
            if (currentButton.Name == "rbWheel4")
            {
                tbInfos.Text = "A Silver SU478-as típus különlegessége speciális kialakítása révén, hogy téli és nyári abroncsként egyaránt funkciónál, így nem kell azt cserélgetni. Leginkább városi és országúti terepre ajánljuk.";
                tbPrice.Text = "Ára: 69.000 Ft";
            }
        }
    }


}
