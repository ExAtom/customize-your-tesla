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
    public partial class PhoneNumberInput : UserControl
    {
        public PhoneNumber PhoneNumber
        {
            get { return (PhoneNumber)GetValue(PhoneNumberProperty); }
            set { SetValue(PhoneNumberProperty, value); }
        }

        public static readonly DependencyProperty PhoneNumberProperty =
            DependencyProperty.Register(nameof(PhoneNumber), typeof(PhoneNumber), typeof(PhoneNumberInput), new PropertyMetadata(null, OnPhoneNumberChanged));

        public List<CallingCode> CallingCodes
        {
            get { return (List<CallingCode>)GetValue(CallingCodesProperty); }
            set { SetValue(CallingCodesProperty, value); }
        }

        public static readonly DependencyProperty CallingCodesProperty =
            DependencyProperty.Register(nameof(CallingCodes), typeof(List<CallingCode>), typeof(PhoneNumberInput), new PropertyMetadata(null, OnCallingCodesChanged));

        public FilterDelegate Filter
        {
            get { return (FilterDelegate)GetValue(FilterProperty); }
            set { SetValue(FilterProperty, value); }
        }

        public static readonly DependencyProperty FilterProperty =
            DependencyProperty.Register(nameof(Filter), typeof(FilterDelegate), typeof(PhoneNumberInput), new PropertyMetadata(null, OnFilterChanged));

        private static void OnPhoneNumberChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((PhoneNumberInput)d).OnPhoneNumberChanged();
        }

        private static void OnCallingCodesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((PhoneNumberInput)d).OnCallingCodesChanged();
        }

        private static void OnFilterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((PhoneNumberInput)d).OnFilterChanged();
        }

        private PhoneNumber previousPhoneNumber;

        public PhoneNumberInput()
        {
            InitializeComponent();
        }

        private void OnPhoneNumberChanged()
        {
            if (dl != null)
            {
                dl.SelectedItem = PhoneNumber?.CallingCode;

            }
            if (tb != null)
            {
                tb.IsEnabled = PhoneNumber?.IsCountrySelected == true;
                tb.Text = PhoneNumber?.Number ?? "";

            }
            UnbindEventHandlers();
            if (PhoneNumber != null)
            {
                PhoneNumber.PropertyChanged += OnPhoneNumberPropertyChanged;
            }
            previousPhoneNumber = PhoneNumber;
        }

        private void UnbindEventHandlers()
        {
            if (previousPhoneNumber != null)
            {
                previousPhoneNumber.PropertyChanged -= OnPhoneNumberPropertyChanged;
            }
        }

        private void OnPhoneNumberPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (dl != null && e.PropertyName == nameof(PhoneNumber.CallingCode))
            {
                dl.SelectedItem = PhoneNumber.CallingCode;
            }
            if (tb != null && e.PropertyName == nameof(PhoneNumber.IsCountrySelected))
            {
                tb.IsEnabled = PhoneNumber.IsCountrySelected;
            }
        }

        private void OnCallingCodesChanged()
        {
            if (dl == null)
            {
                return;
            }
            if (CallingCodes == null)
            {
                dl.Items = null;
            }
            else
            {
                dl.Items = CallingCodes.Select(x => (IDropdownItem)x).ToList();
            }
        }

        private void OnFilterChanged()
        {
            dl.Filter = Filter;
        }

        private void tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PhoneNumber != null)
            {
                PhoneNumber.Number = tb?.Text ?? "";
            }
        }

        private void dl_SelectedItemChanged(IDropdownItem item)
        {
            if (PhoneNumber != null && item != PhoneNumber.CallingCode)
            {
                PhoneNumber.CallingCode = (CallingCode)item;
            }
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            UnbindEventHandlers();
        }
    }
}
