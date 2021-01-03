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
using TeslaCarConfigurator.Services;
using System.ComponentModel;

namespace TeslaCarConfigurator.UserControls.Inputs
{
    public partial class PhoneNumberInput : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty PhoneNumberProperty =
            DependencyProperty.Register(nameof(PhoneNumber),
                                        typeof(PhoneNumber),
                                        typeof(PhoneNumberInput),
                                        new PropertyMetadata(null, OnPhoneNumberChanged));

        public List<CountryInfo> AvailableCountries
        {
            get { return (List<CountryInfo>)GetValue(AvailableCountriesProperty); }
            set { SetValue(AvailableCountriesProperty, value); }
        }

        public static readonly DependencyProperty AvailableCountriesProperty =
            DependencyProperty.Register(nameof(AvailableCountries), typeof(List<CountryInfo>), typeof(PhoneNumberInput), new PropertyMetadata(null, OnAvailableCountriesChanged));

        private static void OnPhoneNumberChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PhoneNumberInput phoneNumberInput = (PhoneNumberInput)d;
            phoneNumberInput.OnPhoneNumberChanged((PhoneNumber)e.NewValue);
        }

        private static void OnAvailableCountriesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((PhoneNumberInput)d).OnAvailableCountriesChanged();
        }

        public delegate void PhoneNumberChangedEventHandler(object sender, PhoneNumber p);

        public event PhoneNumberChangedEventHandler PhoneNumberChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public PhoneNumber PhoneNumber
        {
            get { return (PhoneNumber)GetValue(PhoneNumberProperty); }
            set { SetValue(PhoneNumberProperty, value); }
        }

        public List<IDropdownItem> CallingCodes => CallingCode.FromCountryInfos(AvailableCountries ?? new List<CountryInfo>())
                                                              .Select(callingCode => (IDropdownItem)callingCode)
                                                              .ToList();

        public PhoneNumberInput()
        {
            if (PhoneNumber == null)
            {
                PhoneNumber = new PhoneNumber();
            }
            DataContext = this;
            InitializeComponent();
        }

        private void OnPhoneNumberChanged(PhoneNumber phoneNumber)
        {
            PhoneNumberChanged?.Invoke(this, phoneNumber);
        }

        private void OnAvailableCountriesChanged()
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("AvailableCountries"));
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("CallingCodes"));

        }
    }
}
