using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaCarConfigurator.Helpers
{
    public static class Formatting
    {
        public static NumberFormatInfo CurrencyFormat
        {
            get
            {
                return new NumberFormatInfo()
                {
                    CurrencySymbol="Ft",
                    CurrencyPositivePattern=3,
                    CurrencyDecimalDigits=0,
                    CurrencyDecimalSeparator=",",
                    CurrencyGroupSeparator=".",
                };
            }
        }
    }
}
