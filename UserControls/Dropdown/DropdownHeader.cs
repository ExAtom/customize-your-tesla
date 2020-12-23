using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace TeslaCarConfigurator.UserControls.Dropdown
{
    public abstract class DropdownHeader:Button
    {
        public DropdownHeader()
        {
            Style = (Style)Application.Current.FindResource("DropdownHeaderStyle");
        }
    }
}
