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

namespace TeslaCarConfigurator.UserControls
{
    /// <summary>
    /// Interaction logic for SavedConfigCar.xaml
    /// </summary>
    public partial class SavedConfigCard : UserControl
    {
        public event Action DeleteConfigClick;

        public event Action LoadConfigClick;

        public SavedConfigCard(string configName, bool hasError)
        {
            InitializeComponent();
            tbName.Text = hasError ? "Hibás mentés." : configName;
            btnLoad.Visibility = hasError ? Visibility.Collapsed : Visibility.Visible;
            if (hasError)
            {
                tbName.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 20, 20));
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteConfigClick?.Invoke();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            LoadConfigClick?.Invoke();
        }
    }
}
