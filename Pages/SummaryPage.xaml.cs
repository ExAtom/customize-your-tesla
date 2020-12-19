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
    public partial class SummaryPage : PageBase
    {

        public SummaryPage()
        {
            
            InitializeComponent();


        }

        public override void OnAttachedToFrame()
        {
            tbConfigName.Text = Config?.ConfigName ?? "";
            if (Config?.IsSaved == true)
            {
                SwitchToUpdateView();
            }
        }

        private void tbConfigName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Config == null)
            {
                return;
            }
            Config.ConfigName = tbConfigName.Text;
            btnSaveConfig.IsEnabled = Config.ConfigName.Length > 0;
            
        }

        private void SwitchToUpdateView()
        {
            btnUpdateConfig.Visibility = Visibility.Visible;
            btnSaveConfig.Content = "Másolat mentése";
            nameInputLabel.Content = "Másolat neve";
        }

        private void btnSaveConfig_Click(object sender, RoutedEventArgs e)
        {
            bool isUniqueName = SaveManager.SavedConfigs.All(c => c == null || c.ConfigName != Config.ConfigName);
            if (!isUniqueName && !ConfirmSaveOverrride())
            {
                return;
            }
            SaveManager.SaveNewConfig(Config);
            if (Config?.IsSaved == true)
            {
                SwitchToUpdateView();
            }
        }

        private void btnUpdateConfig_Click(object sender, RoutedEventArgs e)
        {
            SaveManager.UpdateSavedConfig(Config);
        }

        private bool ConfirmSaveOverrride()
        {
            var result = MessageBox.Show("Már van ilyen néven elmentett konfigurációja. Szeretné felülírni?", "Mentés felülírása", MessageBoxButton.YesNo);
            return result == MessageBoxResult.Yes;
        }

        private void btnCopyToClipboard_Click(object sender, RoutedEventArgs e)
        {
            if (Config == null)
            {
                return;
            }
            Clipboard.SetText(Config.ToToken());
        }
    }
}
