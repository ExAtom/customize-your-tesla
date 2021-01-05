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
using TeslaCarConfigurator.UserControls.Dropdown;
using TeslaCarConfigurator.UserControls.Summary;
using System.Globalization;

namespace TeslaCarConfigurator.Pages
{
    public partial class CustomerDetailsPage : PageBase
    {
        public CustomerDetailsPage()
        {
            InitializeComponent();
        }

        public override void OnAttachedToFrame()
        {
            if (Config == null)
            {
                return;
            }

            CustomerDetailsViewModel vm = new CustomerDetailsViewModel(Config);
            DataContext = vm;
            vm.Init();
        }

        private void BuyCar(object sender, RoutedEventArgs e)
        {

        }
    }
}
