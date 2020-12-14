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
using System.Windows.Shapes;
using TeslaCarConfigurator.Data;
using TeslaCarConfigurator.Helpers;

namespace TeslaCarConfigurator
{
    public partial class MainWindow : Window
    {
        private RoutingHelper router;

        public MainWindow()
        {
            SaveManager.LoadSavedConfigs();
            Initialized += OnWindowInitialized;
            InitializeComponent();
        }

        private void OnWindowInitialized(object sender, EventArgs e)
        {
            router = new RoutingHelper(Container);
            router.ChangeCurrentPage(new LandingPage());
        }

        private void Windows_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Windows.Title = $"{Windows.ActualWidth} x {Windows.ActualHeight}";
        }
    }
}
