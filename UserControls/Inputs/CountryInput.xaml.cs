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
using static TeslaCarConfigurator.UserControls.Inputs.DropdownList;

namespace TeslaCarConfigurator.UserControls.Inputs
{
    public partial class CountryInput : UserControl
    {
        public CustomerDetails CustomerDetails
        {
            get { return (CustomerDetails)GetValue(CustomerDetailsProperty); }
            set { SetValue(CustomerDetailsProperty, value); }
        }

        public static readonly DependencyProperty CustomerDetailsProperty =
            DependencyProperty.Register(nameof(CustomerDetails), typeof(CustomerDetails), typeof(CountryInput), new PropertyMetadata(null, OnCustomerDetailsChanged));

        public List<CountryInfo> CountryInfos
        {
            get { return (List<CountryInfo>)GetValue(CountryInfosProperty); }
            set { SetValue(CountryInfosProperty, value); }
        }

        public static readonly DependencyProperty CountryInfosProperty =
            DependencyProperty.Register(nameof(CountryInfos), typeof(List<CountryInfo>), typeof(CountryInput), new PropertyMetadata(null, OnCountryInfosChanged));

        public FilterDelegate Filter
        {
            get { return (FilterDelegate)GetValue(FilterProperty); }
            set { SetValue(FilterProperty, value); }
        }

        public static readonly DependencyProperty FilterProperty =
            DependencyProperty.Register(nameof(Filter), typeof(FilterDelegate), typeof(CountryInput), new PropertyMetadata(null, OnFilterChanged));

        private static void OnCustomerDetailsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CountryInput)d).OnCustomerDetailsChanged();
        }

        private static void OnCountryInfosChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CountryInput)d).OnCountryInfosChanged();
        }

        private static void OnFilterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CountryInput)d).OnFilterChanged();
        }

        private CustomerDetails previousDetails;

        public CountryInput()
        {
            InitializeComponent();
        }

        private void OnCustomerDetailsChanged()
        {
            if (dl != null)
            {
                dl.SelectedItem = CustomerDetails?.Country;

            }
            UnbindEventHandlers();
            if (CustomerDetails != null)
            {
                CustomerDetails.PropertyChanged += OnCustomerDetailsPropertyChanged;
            }
            previousDetails = CustomerDetails;
        }

        private void UnbindEventHandlers()
        {
            if (previousDetails != null)
            {
                previousDetails.PropertyChanged -= OnCustomerDetailsPropertyChanged;
            }
        }

        private void OnCustomerDetailsPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (dl != null && e.PropertyName == nameof(CustomerDetails.Country))
            {
                dl.SelectedItem = CustomerDetails?.Country;
            }
        }

        private void OnCountryInfosChanged()
        {
            if (dl == null)
            {
                return;
            }
            if (CountryInfos == null)
            {
                dl.Items = null;
            }
            else
            {
                dl.Items = CountryInfos.Select(x => (IDropdownItem)x).ToList();
            }
        }

        private void OnFilterChanged()
        {
            dl.Filter = Filter;
        }

        private void dl_SelectedItemChanged(IDropdownItem item)
        {
            if (CustomerDetails != null && item != CustomerDetails.Country)
            {
                CustomerDetails.Country = (CountryInfo)item;
            }
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            UnbindEventHandlers();
        }
    }
}
