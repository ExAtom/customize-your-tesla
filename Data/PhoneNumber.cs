using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TeslaCarConfigurator.Services;

namespace TeslaCarConfigurator.Data
{
    public class PhoneNumber : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private CallingCode callingCode;
        private string number;

        public CallingCode CallingCode
        {
            get { return callingCode; }
            set
            {
                callingCode = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsCountrySelected));
            }
        }

        public string Number
        {
            get { return number; }
            set { 
                number = value; 
                OnPropertyChanged(); 
            }
        }

        public bool IsCountrySelected => CallingCode != null;

        public bool Isvalid => IsCountrySelected && !string.IsNullOrEmpty(Number);

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
