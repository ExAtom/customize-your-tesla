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
    public partial class LandingPage : PageBase
    {
        public LandingPage()
        {
            InitializeComponent();
            Application.Current.MainWindow.MinWidth = 420;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow closeWindow = new CloseWindow();
            closeWindow.Show();
        }

        private async void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (!Router.HasConfig)
            {
                Router.SetConfig(new CarConfiguration());
                Router.ChangeCurrentPage(new ModelConfiguration());
            }
            else
            {
                bool isOverrideConfirmed = await ConfirmConfigOverride();
                if (isOverrideConfirmed)
                {
                    Router.SetConfig(new CarConfiguration());
                }
                if (IsVisible)
                {
                    Router.ChangeCurrentPage(new ModelConfiguration());
                }
                else
                {
                    Router.ReloadPage();
                }
            }
        }

        private void btnOpenSaved_Click(object sender, RoutedEventArgs e)
        {
            Router.ChangeCurrentPage(new SavedConfigsPage());
        }

        private async Task<bool> ConfirmConfigOverride()
        {
            btnOpenSaved.IsEnabled = false;
            btnStart.IsEnabled = false;
            bool result = await MessageBarController.ShowWarning("Már elkezdett konfigurálni egy Tesla autót. Szeretné azt a konfigot felülírni?", -1, showYesNo: true);
            if (IsVisible)
            {
                btnOpenSaved.IsEnabled = false;
                btnStart.IsEnabled = false;
            }
            return result;
        }

        
    }
}
