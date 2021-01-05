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
                OnPropertyChanged(nameof(CallingCodes));
            }
        }

        private bool isLoading;

        public bool IsLoading
        {
            get { return isLoading; }
            set { isLoading = value; }
        }

        public List<CallingCode> CallingCodes => CallingCode.FromCountryInfos(CountryInfos);

        public DropdownList.FilterDelegate PhoneFilter => PhoneNumberFilterImpl;

        public DropdownList.FilterDelegate CountryFilter => CountryFilterImpl;

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
                IsLoading = false;
            }
            catch (Exception)
            {
                OnLoadingFailed();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void OnLoadingFailed()
        {

        }

        private List<IDropdownItem> PhoneNumberFilterImpl(string filterText, List<IDropdownItem> items)
        {
            if (string.IsNullOrEmpty(filterText) || items == null || items.Count == 0 || filterText == "+")
            {
                return null;
            }
            IEnumerable<CallingCode> callingCodes = items.Select(c => (CallingCode)c);
            IEnumerable<CallingCode> filteredByPrefix = callingCodes.Where(c => c != null && c.Prefix.StartsWith(filterText));
            IEnumerable<CallingCode> filteredByNativeName = callingCodes.Where(c => c != null && c.NativeName.ToLower().StartsWith(filterText.ToLower()));
            IEnumerable<CallingCode> filteredByAlphaCode = callingCodes.Where(c => c != null && c.Alpha3Code.ToLower().StartsWith(filterText.ToLower()));

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

        private List<IDropdownItem> CountryFilterImpl(string filterText, List<IDropdownItem> items)
        {
            if (string.IsNullOrEmpty(filterText) || items == null || items.Count == 0 )
            {
                return null;
            }
            IEnumerable<CountryInfo> countries = items.Select(c => (CountryInfo)c);
            IEnumerable<CountryInfo> filteredByNativeName = countries.Where(c => c != null && c.NativeName.ToLower().StartsWith(filterText.ToLower()));
            IEnumerable<CountryInfo> filteredByAlphaCode = countries.Where(c => c != null && c.Alpha3Code.ToLower().StartsWith(filterText.ToLower()));

            HashSet<CountryInfo> filtered = new HashSet<CountryInfo>();
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
