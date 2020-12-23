using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TeslaCarConfigurator.UserControls.Dropdown
{
    public class DropdownItem
    {
        public UserControl Content { get; private set; }

        public DropdownHeader Header { get; private set; }

        public DropdownItem(UserControl content, DropdownHeader header)
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
