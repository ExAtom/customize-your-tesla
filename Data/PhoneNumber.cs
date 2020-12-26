using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TeslaCarConfigurator.Data
{
    public class PhoneNumber : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string callingCode;
        private string number;

        public string CallingCode
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

        public bool IsCountrySelected => CallingCode?.Length > 0;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
