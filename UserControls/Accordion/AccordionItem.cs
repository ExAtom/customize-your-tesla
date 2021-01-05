using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TeslaCarConfigurator.UserControls.Accordion { 

    public class AccordionItem
    {
        public UserControl Content { get; private set; }

        public AccordionHeader Header { get; private set; }

        public AccordionItem(UserControl content, AccordionHeader header)
        {
            Content = content;
            Header = header;
            header.Click += OnHeaderClicked;
            content.Visibility = Visibility.Collapsed;
        }

        private void OnHeaderClicked(object sender, RoutedEventArgs e)
        {
            Content.Visibility = 2 - Content.Visibility;
        }
    }
}
