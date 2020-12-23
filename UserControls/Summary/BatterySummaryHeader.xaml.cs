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

namespace TeslaCarConfigurator.UserControls.Summary
{
    
    public partial class BatterySummaryHeader : DropdownHeader
    {
        private Battery battery;

        public BatterySummaryHeader(Battery battery)
        {
            this.battery = battery;
            Initialized += OnInitialized;
            InitializeComponent();
        }

        private void OnInitialized(object sender, EventArgs e)
        {
            if (battery == null)
            {
                return;
            }
            tbPrice.Text = $"+{battery.CalculateAdditionalPrices().ToString("C", Formatting.CurrencyFormat)}";
        }
    }
}
