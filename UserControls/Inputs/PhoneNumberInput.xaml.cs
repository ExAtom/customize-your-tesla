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
        public static readonly DependencyProperty PhoneNumberProperty =
            DependencyProperty.Register(nameof(PhoneNumber),
                                        typeof(PhoneNumber),
                                        typeof(PhoneNumberInput),
                                        new PropertyMetadata(null, OnPhoneNumberChanged));

        private static void OnPhoneNumberChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) 
        {
            PhoneNumberInput phoneNumberInput = (PhoneNumberInput)d;
            phoneNumberInput.OnPhoneNumberChanged((PhoneNumber)e.NewValue);
        }

        public delegate void PhoneNumberChangedEventHandler(object sender, PhoneNumber p);

        public event PhoneNumberChangedEventHandler PhoneNumberChanged;

        public PhoneNumber PhoneNumber
        {
            get { return (PhoneNumber)GetValue(PhoneNumberProperty); }
            set { SetValue(PhoneNumberProperty, value); }
        }

        public PhoneNumberInput()
        {
            if (PhoneNumber == null)
            {
                PhoneNumber = new PhoneNumber();
            }
            DataContext = PhoneNumber;
            InitializeComponent();
        }

        private void OnPhoneNumberChanged(PhoneNumber phoneNumber) 
        {
            PhoneNumberChanged?.Invoke(this, phoneNumber);
        }
    }
}
