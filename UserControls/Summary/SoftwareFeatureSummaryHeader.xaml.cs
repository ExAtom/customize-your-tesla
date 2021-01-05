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
using TeslaCarConfigurator.UserControls.Accordion;

namespace TeslaCarConfigurator.UserControls.Summary
{
    public partial class SoftwareFeatureSummaryHeader : AccordionHeader
    {
        private SoftwareFeatures softwareFeatures;

        public SoftwareFeatureSummaryHeader(SoftwareFeatures softwareFeatures)
        {
            this.softwareFeatures = softwareFeatures;
            Initialized += OnInitialized;
            InitializeComponent();
        }

        private void OnInitialized(object sender, EventArgs e)
        {
            if (softwareFeatures == null)
            {
                return;
            }
            tbPrice.Text = $"+{softwareFeatures.CalculateAdditionalPrices().ToString("C", Formatting.CurrencyFormat)}";
        }
    }
}
