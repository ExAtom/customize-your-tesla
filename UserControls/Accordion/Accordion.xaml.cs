using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TeslaCarConfigurator.UserControls.Accordion
{
    
    public partial class Accordion : UserControl
    {
        public Accordion()
        {
            InitializeComponent();
        }

        public void AddAccordionItem(AccordionItem item)
        {
            container.Children.Add(item.Header);
            container.Children.Add(item.Content);
        }

        

        
    }
}
