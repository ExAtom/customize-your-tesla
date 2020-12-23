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

namespace TeslaCarConfigurator.UserControls.Summary
{
    
    public partial class BatterySummaryContent : UserControl
    {
        private Battery battery;

        public BatterySummaryContent(Battery battery)
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
            tbBattery.Text = $"{battery.Capacity} kWh";
        }
    }
}
