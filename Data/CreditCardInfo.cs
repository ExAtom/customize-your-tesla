using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TeslaCarConfigurator.Data
{
    public class CreditCardInfo : INotifyPropertyChanged
    {
        private string cardNumber;
        private string securityCode;
        private string firstname;
        private string lastname;
        private string expirationDate;

        public string CardNumber
        {
            get => cardNumber; set
            {
                cardNumber = value;
                OnPropertyChanged();
            }
        }

        public string SecurityCode
        {
            get => securityCode; set
            {
                securityCode = value;
                OnPropertyChanged();
            }
        }

        public string Firstname
        {
            get => firstname; set
            {
                firstname = value;
                OnPropertyChanged();
            }
        }

        public string Lastname
        {
            get => lastname; set
            {
                lastname = value;
                OnPropertyChanged();
            }
        }

        public string ExpirationDate
        {
            get => expirationDate; set
            {
                expirationDate = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
