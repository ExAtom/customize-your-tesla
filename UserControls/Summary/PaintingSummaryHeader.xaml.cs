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
    public partial class PaintingSummaryHeader : DropdownHeader
    {
        private Painting painting;

        public PaintingSummaryHeader(Painting painting)
        {
            this.painting = painting;
            Initialized += OnInitialized;
            InitializeComponent();
        }

        private void OnInitialized(object sender, EventArgs e)
        {
            if (painting == null)
            {
                return;
            }
            tbPrice.Text = $"+{painting.CalculateAdditionalPrices()}FT";
        }
    }
}
