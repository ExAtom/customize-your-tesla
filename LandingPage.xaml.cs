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

namespace TeslaCarConfigurator
{
    public partial class LandingPage : PageBase
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow closeWindow = new CloseWindow();
            closeWindow.Show();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (!Router.HasConfig || ConfirmConfigOverride())
            {
                Router.SetConfig(new CarConfiguration());
            }
            Router.ChangeCurrentPage(new ModelConfiguration());
        }

        private bool ConfirmConfigOverride()
        {
            var result = MessageBox.Show("Már elkezdett konfigurálni egy Tesla autót. Szeretné azt a konfigot felülírni?", "Új konfig", MessageBoxButton.YesNo);
            return result == MessageBoxResult.Yes;
        }
    }
}
