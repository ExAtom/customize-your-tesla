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
    /// <summary>
    /// Interaction logic for ModelConfiguration.xaml
    /// </summary>
    public partial class ModelConfiguration : PageBase
    {
        public ModelConfiguration()
        {
            InitializeComponent();
            tbModel1.Text = Model.ModelDescriptions[0];
            tbModel2.Text = Model.ModelDescriptions[1];
            tbModel3.Text = Model.ModelDescriptions[2];
            tbModel4.Text = Model.ModelDescriptions[3];
            tbPrice1.Text = $"{Model.Prices[0].ToString("C", Formatting.CurrencyFormat)} -tól";
            tbPrice2.Text = $"{Model.Prices[1].ToString("C", Formatting.CurrencyFormat)} -tól";
            tbPrice3.Text = $"{Model.Prices[2].ToString("C", Formatting.CurrencyFormat)} -tól";
            tbPrice4.Text = $"{Model.Prices[3].ToString("C", Formatting.CurrencyFormat)} -tól";
            Application.Current.MainWindow.MinWidth = 320;
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

        private void Windows_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (Windows.ActualWidth <= 566)
            {
                tbTitle.Margin = new Thickness(-22, 10, 10, 0);
                tbTitle.Padding = new Thickness(40, 5, 30, 5);
            }
            else
            {
                tbTitle.Margin = new Thickness(-22, 10, 97, 0);
                tbTitle.Padding = new Thickness(40, 5, 0, 5);
            }
        }
    }
}
