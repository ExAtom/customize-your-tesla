using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaCarConfigurator.Data
{
    public class CustomerDetails
    {
        // keresztnév
        public string Firstname { get; set; }

        // vezetéknév
        public string Lastname { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string Country { get; set; }

        public string ZIPCode { get; set; }

        public string Province { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public CreditCardInfo CreditCard { get; set; }

        public CustomerDetails()
        {
            CreditCard = new CreditCardInfo();
        }
    }
}
