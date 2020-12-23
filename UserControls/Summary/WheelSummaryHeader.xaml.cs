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
using TeslaCarConfigurator.UserControls.Dropdown;

namespace TeslaCarConfigurator.UserControls.Summary
{
    public partial class WheelSummaryHeader : DropdownHeader
    {
        private Data.WheelConfiguration wheel;

        public WheelSummaryHeader(Data.WheelConfiguration wheel)
        {
            this.wheel = wheel;
            Initialized += OnInitialized;
            InitializeComponent();
        }

        private void OnInitialized(object sender, EventArgs e)
        {
            if (wheel == null)
            {
                return;
            }
            tbPrice.Text = $"+{wheel.CalculateAdditionalPrices()}FT";
        }
    }
}
