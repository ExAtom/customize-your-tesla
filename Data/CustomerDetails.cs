using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TeslaCarConfigurator.Data
{
    public class CustomerDetails : INotifyPropertyChanged
    {
        private string firstname;
        private string lastname;
        private string emailAddress;
        private PhoneNumber phoneNumber;
        private string country;
        private string zipCode;
        private string province;
        private string city;
        private string address;
        private CreditCardInfo creditCard;

        // keresztnév
        public string Firstname
        {
            get => firstname; set
            {
                firstname = value;
                OnPropertyChanged();
            }
        }

        // vezetéknév
        public string Lastname
        {
            get => lastname; set
            {
                lastname = value;
                OnPropertyChanged();
            }
        }

        public string EmailAddress
        {
            get => emailAddress; set
            {
                emailAddress = value;
                OnPropertyChanged();
            }
        }

        public PhoneNumber PhoneNumber
        {
            get => phoneNumber; set
            {
                phoneNumber = value;
                OnPropertyChanged();
            }
        }

        public string Country
        {
            get => country; set
            {
                country = value;
                OnPropertyChanged();
            }
        }

        public string ZipCode
        {
            get => zipCode; set
            {
                zipCode = value;
                OnPropertyChanged();
            }
        }

        public string Province
        {
            get => province; set
            {
                province = value;
                OnPropertyChanged();
            }
        }

        public string City
        {
            get => city; set
            {
                city = value;
                OnPropertyChanged();
            }
        }

        public string Address
        {
            get => address; set
            {
                address = value;
                OnPropertyChanged();
            }
        }

        public CreditCardInfo CreditCard
        {
            get => creditCard; set
            {
                creditCard = value;
                OnPropertyChanged();
            }
        }

        public CustomerDetails()
        {
            CreditCard = new CreditCardInfo();
            PhoneNumber = new PhoneNumber();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
