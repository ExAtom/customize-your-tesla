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
    public partial class ModelSummaryHeader : AccordionHeader
    {
        private Model model;

        public ModelSummaryHeader(Model model)
        {
            this.model = model;
            Initialized += OnInitialized;
            InitializeComponent();
        }

        private void OnInitialized(object sender, EventArgs e)
        {
            if (model == null)
            {
                return;
            }
            tbPrice.Text = $"{model.CalculateAdditionalPrices().ToString("C", Formatting.CurrencyFormat)}";
        }
    }
}
