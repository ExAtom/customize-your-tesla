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
using TeslaCarConfigurator.UserControls.Summary;
using System.Globalization;
using TeslaCarConfigurator.UserControls.Accordion;

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

            tbTotalPrice.Text = $"Végösszeg: {Config.TotalPrice.ToString("C", Formatting.CurrencyFormat)}";

            InitDropdown();
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

        private void InitDropdown()
        {
            summaryAccordion.Children.Clear();

            Model model = Config.CarModel;
            Battery battery = Config.Battery;
            Transmission transmission = Config.Transmission;
            Painting painting = Config.Painting;
            Data.WheelConfiguration wheel = Config.Wheels;
            Exterior exterior = Config.Exterior;
            Interior interior = Config.Interior;
            SoftwareFeatures softwareFeatures = Config.SoftwareFeatures;

            summaryAccordion.Children.Add(new ModelSummary(model));
            summaryAccordion.Children.Add(new BatterySummary(battery));
            summaryAccordion.Children.Add(new TransmissionSummary(transmission));
            summaryAccordion.Children.Add(new PaintingSummary(painting));
            summaryAccordion.Children.Add(new WheelsSummary(wheel));
            summaryAccordion.Children.Add(new ExteriorSummary(exterior));
        }

        private async void btnSaveConfig_Click(object sender, RoutedEventArgs e)
        {
            bool isUniqueName = SaveManager.IsUniqueName(Config);
            if (!isUniqueName && !await ConfirmSaveOverrride())
            {
                return;
            }
            try
            {
                SaveManager.AddOrOverride(Config);
                await MessageBarController.ShowSuccess("Konfig sikeresen elmentve.", 2000);
            }
            catch (Exception)
            {
                await MessageBarController.ShowError("Konfig elmentése sikertelen.", 2000);
            }
        }

        private void btnUpdateConfig_Click(object sender, RoutedEventArgs e)
        {
            SaveManager.AddOrOverride(Config);
        }

        private async Task<bool> ConfirmSaveOverrride()
        {
            btnSaveConfig.IsEnabled = false;
            tbConfigName.IsEnabled = false;
            bool result = await MessageBarController.ShowWarning("Már van ilyen néven elmentett konfigurációja. Szeretné felülírni?", -1, showYesNo: true);
            if (IsVisible)
            {
                btnSaveConfig.IsEnabled = true;
                tbConfigName.IsEnabled = true;
            }

            return result;
        }

        private void btnCopyToClipboard_Click(object sender, RoutedEventArgs e)
        {
            if (Config == null)
            {
                return;
            }
            try
            {
                Clipboard.SetText(Config.ToToken());
                MessageBarController.ShowSuccess("Vágólapra másolva", 2000);
            }
            catch (Exception)
            {
                MessageBarController.ShowError("Vágólapra másolás sikertelen!", 2000);

            }
        }
    }
}
