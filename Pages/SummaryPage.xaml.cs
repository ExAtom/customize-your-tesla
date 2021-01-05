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
            if (Config?.IsSaved == true)
            {
                SwitchToUpdateView();
            }
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

        private void SwitchToUpdateView()
        {
            btnUpdateConfig.Visibility = Visibility.Visible;
            btnSaveConfig.Content = "Másolat mentése";
            nameInputLabel.Content = "Másolat neve";
        }

        private void InitDropdown()
        {
            Model model = Config.CarModel;
            Battery battery = Config.Battery;
            Transmission transmission = Config.Transmission;
            Painting painting = Config.Painting;
            Data.WheelConfiguration wheel = Config.Wheels;
            Exterior exterior = Config.Exterior;
            Interior interior = Config.Interior;
            SoftwareFeatures softwareFeatures = Config.SoftwareFeatures;

            AccordionItem modelItem = new AccordionItem(new ModelSummaryContent(model), new ModelSummaryHeader(model));
            summaryAccordion .AddAccordionItem(modelItem);

            AccordionItem batteryItem = new AccordionItem(new BatterySummaryContent(battery), new BatterySummaryHeader(battery));
            summaryAccordion .AddAccordionItem(batteryItem);

            AccordionItem transmissionItem = new AccordionItem(new TransmissionSummaryContent(transmission), new TransmissionSummaryHeader(transmission));
            summaryAccordion .AddAccordionItem(transmissionItem);

            AccordionItem paintingItem = new AccordionItem(new PaintingSummaryContent(painting), new PaintingSummaryHeader(painting));
            summaryAccordion .AddAccordionItem(paintingItem);

            AccordionItem wheelItem = new AccordionItem(new WheelSummaryContent(wheel), new WheelSummaryHeader(wheel));
            summaryAccordion .AddAccordionItem(wheelItem);

            AccordionItem exteriorItem = new AccordionItem(new ExteriorSummaryContent(exterior), new ExteriorSummaryHeader(exterior));
            summaryAccordion .AddAccordionItem(exteriorItem);

            AccordionItem interiorItem = new AccordionItem(new InteriorSummaryContent(interior), new InteriorSummaryHeader(interior));
            summaryAccordion .AddAccordionItem(interiorItem);

            AccordionItem softwareFeatureItem = new AccordionItem(new SoftwareFeatureSummaryContent(softwareFeatures), new SoftwareFeatureSummaryHeader(softwareFeatures));
            summaryAccordion .AddAccordionItem(softwareFeatureItem);
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
