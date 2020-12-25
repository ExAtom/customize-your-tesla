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

namespace TeslaCarConfigurator.UserControls.Inputs
{
    /// <summary>
    /// Interaction logic for PhonenumberInput.xaml
    /// </summary>
    public partial class PhoneNumberInput : UserControl
    {


        public string PhoneNumber
        {
            get { return (string)GetValue(PhoneNumberProperty); }
            set { SetValue(PhoneNumberProperty, value); }
        }

        
        public static readonly DependencyProperty PhoneNumberProperty =
            DependencyProperty.Register("PhoneNumber", typeof(string), typeof(PhoneNumberInput), new PropertyMetadata(""));



        public PhoneNumberInput()
        {
            InitializeComponent();
        }
    }
}
