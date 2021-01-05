using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using TeslaCarConfigurator.Data;
using System.Runtime.CompilerServices;
using TeslaCarConfigurator.Services;
using TeslaCarConfigurator.UserControls.Inputs;

namespace TeslaCarConfigurator.Pages
{
    public class CustomerDetailsViewModel : INotifyPropertyChanged
    {
        private CustomerDetails customerDetails;

        public CustomerDetails CustomerDetails
        {
            get => customerDetails; set
            {
                customerDetails = value;
                OnPropertyChanged();
            }
        }

        private List<CountryInfo> countryInfos;

        public List<CountryInfo> CountryInfos
        {
            get => countryInfos;
            set
            {
                countryInfos = value;
                OnPropertyChanged();
            }
        }

        private bool isLoading;

        public bool IsLoading
        {
            get { return isLoading; }
            set { isLoading = value; }
        }

        private List<CallingCode> callingCodes;

        public List<CallingCode> CallingCodes
        {
            get => callingCodes; set
            {
                callingCodes = value;
                OnPropertyChanged();
            }
        }

        public DropdownList.FilterDelegate Filter => PhoneNumberFilter;

        public event PropertyChangedEventHandler PropertyChanged;

        public CustomerDetailsViewModel(CustomerDetails customerDetails)
        {
            CustomerDetails = customerDetails;
        }

        public CustomerDetailsViewModel()
        {

        }

        public void Init()
        {
            if ((CountryService.CachedCountryInfos?.Count ?? 0) == 0)
            {
                LoadCountryInfos();
            }
            else
            {
                CountryInfos = CountryService.CachedCountryInfos;
            }
        }

        private async void LoadCountryInfos()
        {
            try
            {
                IsLoading = true;
                CountryInfos = await CountryService.FetchCountryInfos();
                IsLoading = true;
            }
            catch (Exception)
            {
                OnLoadingFailed();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            if (name == nameof(CountryInfos))
            {
                CallingCodes = CallingCode.FromCountryInfos(CountryInfos);
            }
        }

        private void OnLoadingFailed()
        {

        }

        private List<IDropdownItem> PhoneNumberFilter(string filterText, List<IDropdownItem> items)
        {
            if (string.IsNullOrEmpty(filterText) || items == null || items.Count == 0 || filterText == "+")
            {
                return null;
            }
            IEnumerable<CallingCode> callingCodes = items.Select(c => (CallingCode)c);
            IEnumerable<CallingCode> filteredByPrefix = callingCodes.Where(c => c != null && c.Prefix.StartsWith(filterText));
            IEnumerable<CallingCode> filteredByNativeName = callingCodes.Where(c => c != null && c.NativeName.StartsWith(filterText));
            IEnumerable<CallingCode> filteredByAlphaCode = callingCodes.Where(c => c != null && c.Alpha3Code.StartsWith(filterText));

            HashSet<CallingCode> filtered = new HashSet<CallingCode>();
            foreach (var item in filteredByPrefix)
            {
                filtered.Add(item);
            }
            foreach (var item in filteredByNativeName)
            {
                filtered.Add(item);
            }
            foreach (var item in filteredByAlphaCode)
            {
                filtered.Add(item);
            }

            List<IDropdownItem> list = filtered.Select(f => (IDropdownItem)f).ToList();
            return list;
        }
    }
}
