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
    public partial class WheelSummaryContent : UserControl
    {
        private Data.WheelConfiguration wheel ;

        public WheelSummaryContent(Data.WheelConfiguration wheel)
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
            tbWheelType.Text = wheel.Type;
        }
    }
}
