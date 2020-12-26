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

namespace TeslaCarConfigurator.UserControls.Inputs
{
    public partial class PhoneNumberInput : UserControl
    {
        public PhoneNumber PhoneNumber
        {
            get { return (PhoneNumber)GetValue(PhoneNumberProperty); }
            set { SetValue(PhoneNumberProperty, value); }
        }

        public static readonly DependencyProperty PhoneNumberProperty =
            DependencyProperty.Register(nameof(PhoneNumber),
                                        typeof(PhoneNumber),
                                        typeof(PhoneNumberInput),
                                        new PropertyMetadata(null));

        public PhoneNumberInput()
        {
            if (PhoneNumber == null)
            {
                PhoneNumber = new PhoneNumber();
            }
            DataContext = PhoneNumber;
            InitializeComponent();
        }

        
    }
}
