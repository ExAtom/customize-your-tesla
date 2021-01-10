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

namespace TeslaCarConfigurator.Pages
{
    /// <summary>
    /// Interaction logic for InteriorPage.xaml
    /// </summary>
    public partial class SoftwarePage : PageBase
    {
        public SoftwarePage()
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
            selfdriving.IsChecked = Config.SoftwareFeatures.HasSelfdriving;
            gps.IsChecked = Config.SoftwareFeatures.HasGps;
            headlightAssistant.IsChecked = Config.SoftwareFeatures.HasHeadlightAssistant;
            adaptiveLights.IsChecked = Config.SoftwareFeatures.HasAdaptiveLights;
        }

        private void softwareSet_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox currentButton = (CheckBox)sender;
            if (currentButton.Name == "selfdriving")
            {
                tbInfos.Text = "A Tesla autók egyik legkiemelkedőbb szolgáltatása az önvezetés, ami olyan precizitással segít a mindennapi forgalmakban, mint eddig semmilyen más cég autói.";
                tbPrice.Text = "Ára: 990.000 Ft";
            }
            if (currentButton.Name == "gps")
            {
                tbInfos.Text = "GPS-szel könnyedén megállapíthatja a helyzetét és segítséget kaphat, hogy milyen irányban folytassa az útján a célpontjának eléréséhez.";
                tbPrice.Text = "Ára: 95.000 Ft";
            }
            if (currentButton.Name == "headlightAssistant")
            {
                tbInfos.Text = "Néha nehéz észrevenni időben, ha egy szemben lévő autó látótávolságba kerül. Ilyenkor a távolsági fényszórókat le kell kapcsolni. Ebben segítene a fényszóró asszisztens.";
                tbPrice.Text = "Ára: 269.000 Ft";
            }
            if (currentButton.Name == "adaptiveLights")
            {
                tbInfos.Text = "Fényviszonyokhoz alkalmazkodik az autó fényberendezései, ezzel kevesebb dologgal foglalkozhat a sofőr, így könnyebben odafigyelhet a balesetmentes vezetésre.";
                tbPrice.Text = "Ára: 246.000 Ft";
            }

            if (Config == null)
            {
                return;
            }

            string setting = currentButton.Name;
            switch (setting)
            {
                case "selfdriving":
                    Config.SoftwareFeatures.HasSelfdriving = selfdriving.IsChecked == true;
                    break;
                case "gps":
                    Config.SoftwareFeatures.HasGps = gps.IsChecked == true;
                    break;
                case "headlightAssistant":
                    Config.SoftwareFeatures.HasHeadlightAssistant = headlightAssistant.IsChecked == true;
                    break;
                case "adaptiveLights":
                    Config.SoftwareFeatures.HasAdaptiveLights = adaptiveLights.IsChecked == true;
                    break;
            }
        }
    }
}