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
using TeslaCarConfigurator.UserControls.Accordion;
using TeslaCarConfigurator.Data;
using TeslaCarConfigurator.Helpers;

namespace TeslaCarConfigurator.UserControls.Summary
{
    /// <summary>
    /// Interaction logic for ModelSummary.xaml
    /// </summary>
    public partial class InteriorSummary : UserControl
    {
        private Interior interior;

        public InteriorSummary(Interior interior)
        {
            InitializeComponent();
            this.interior = interior;
        }

        private void tbPrice_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tbPrice = (TextBlock)sender;
            int prices = interior.CalculateAdditionalPrices();
            if (prices == 0)
            {
                return;
            }

            tbPrice.Text = "+" + prices.ToString("C", Formatting.CurrencyFormat);
        }

        
    }
}
