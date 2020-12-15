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

namespace TeslaCarConfigurator
{
    /// <summary>
    /// Interaction logic for ModelConfiguration.xaml
    /// </summary>
    public partial class ModelConfiguration : PageBase
    {
        public ModelConfiguration()
        {
            InitializeComponent();
            tbModel1.Text = "➤ 430 kilométer hatótávolság\n➤ 225 km/h végsebesség\n➤ 5.6 mp 0-100 km/h gyorsulás\n➤ Elektromos csomagtérajtó";
            tbModel2.Text = "➤ 480 kilométer hatótávolság\n➤ 241 km/h végsebesség\n➤ 3.7 mp 0-100 km/h gyorsulás\n➤ Összkerék meghajtás";
            tbModel3.Text = "➤ 561 kilométer hatótávolság\n➤ 250 km/h végsebesség\n➤ 4.6 mp 0-100 km/h gyorsulás\n➤ Összkerék meghajtás";
            tbModel4.Text = "➤ 840+ kilométer hatótávolság\n➤ 320 km/h végsebesség\n➤ <2.1 mp 0-100 km/h gyorsulás\n➤ Három motoros összkerék meghajtás";
        }

        public override void OnAttachedToFrame()
        {
            byte chosenTypeIndex = Config?.CarModel?.ModelNameIndex ?? 0;
            RadioButton selected = null;

            if (chosenTypeIndex == 0)
            {
                selected = rbModel1;
            }

            if (chosenTypeIndex == 1)
            {
                selected = rbModel2;
            }

            if (chosenTypeIndex == 2)
            {
                selected = rbModel3;
            }

            if (chosenTypeIndex == 3)
            {
                selected = rbModel4;
            }

            if (selected == null)
            {
                return;
            }
            selected.IsChecked = true;
        }

        private void rbModelType_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton currentButton = (RadioButton)sender;
            byte index = (byte)(byte.Parse(currentButton.Name.Replace("rbModel", "")) - 1);
            Config.CarModel.ModelNameIndex = index;
            if (Config == null)
            {
                return;
            }
        }
    }
}
