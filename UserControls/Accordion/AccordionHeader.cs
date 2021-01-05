using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace TeslaCarConfigurator.UserControls.Accordion
{
    public abstract class AccordionHeader:Button
    {
        public AccordionHeader()
        {
            Style = (Style)Application.Current.FindResource("AccordionHeaderStyle");
        }
    }
}
