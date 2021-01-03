using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaCarConfigurator.UserControls.Inputs;
using System.ComponentModel;

namespace TeslaCarConfigurator.Services
{
    public class CountryInfo:IDropdownItem,IFlag
    {
        public string[] CallingCodes { get; set; }

        public string Flag { get; set; }

        public string NativeName { get; set; }

        public string Alpha3Code { get; set; }

        public string DropdownText => NativeName;
    }
}
