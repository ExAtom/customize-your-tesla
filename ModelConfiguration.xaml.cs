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
using TeslaCarConfigurator.Helpers;

namespace TeslaCarConfigurator
{
    /// <summary>
    /// Interaction logic for ModelConfiguration.xaml
    /// </summary>
    public partial class ModelConfiguration : PageBase
    {
        public ModelConfiguration()
        {
            InitializeComponent();
            tbModel1.Text = "➤ 430 kilométer hatótávolság\n➤ 225 km/h végsebesség\n➤ 5.6 mp 0-100 km/h gyorsulás\n➤ Elektromos csomagtérajtó";

        }
    }
}
