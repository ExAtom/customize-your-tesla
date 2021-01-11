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
    /// Interaction logic for PageTitle.xaml
    /// </summary>
    public partial class PageTitle : UserControl
    {
        public PageTitle()
        {
            InitializeComponent();
        }

        public void SwitchToDesktop() 
        {
            Mobile.Visibility = Visibility.Collapsed;
            Desktop.Visibility = Visibility.Visible;
        }

        public void SwitchToMobile()
        {
            Mobile.Visibility = Visibility.Visible;
            Desktop.Visibility = Visibility.Collapsed;
        }

        public void SetTitle(string title) 
        {
            tbTitleD.Text = title;
            tbTitleM.Text = title;
        }
    }
}
