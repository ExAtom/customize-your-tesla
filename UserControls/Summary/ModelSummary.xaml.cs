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

namespace TeslaCarConfigurator.UserControls.Summary
{
    /// <summary>
    /// Interaction logic for ModelSummary.xaml
    /// </summary>
    public partial class ModelSummary : UserControl
    {
        private TextBlock tbPrice;

        public ModelSummary()
        {
            InitializeComponent();
        }

        private void tbPrice_Loaded(object sender, RoutedEventArgs e)
        {
            tbPrice = (TextBlock)sender;
        }
    }
}
