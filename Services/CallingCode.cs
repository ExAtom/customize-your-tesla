using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaCarConfigurator.UserControls.Inputs;

namespace TeslaCarConfigurator.Services
{
    public class CallingCode : IDropdownItem,IFlag
    {
        public string Prefix { get; set; }

        public string Flag { get; set; }

        public string NativeName { get; set; }

        public string Alpha3Code { get; set; }

        public string DropdownText => NativeName;

        public CallingCode(string prefix, string flag, string nativeName, string alpha3Code)
        {
            Prefix = prefix;
            Flag = flag;
            NativeName = nativeName;
            Alpha3Code = alpha3Code;
        }

        public static List<CallingCode> FromCountryInfos(IEnumerable<CountryInfo> countryInfos)
        {
            return countryInfos.Aggregate(new List<CallingCode>(), (callingCodes, countryInfo) =>
            {
                callingCodes.AddRange(countryInfo.CallingCodes.Select(code => new CallingCode(code, countryInfo.Flag, countryInfo.NativeName, countryInfo.Alpha3Code)));
                return callingCodes;
            });
        }
    }
}
