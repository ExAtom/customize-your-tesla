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

namespace TeslaCarConfigurator.UserControls.Inputs
{

    public partial class DropdownList : UserControl
    {
        public delegate List<IDropdownItem> FilterDelegate(string filterText, List<IDropdownItem> items);

        public List<IDropdownItem> Items
        {
            get { return (List<IDropdownItem>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register(nameof(Items), typeof(List<IDropdownItem>), typeof(DropdownList), new PropertyMetadata(null));

        public FilterDelegate Filter
        {
            get { return (FilterDelegate)GetValue(FilterProperty); }
            set { SetValue(FilterProperty, value); }
        }

        public static readonly DependencyProperty FilterProperty =
            DependencyProperty.Register(nameof(Filter), typeof(FilterDelegate), typeof(DropdownList), new PropertyMetadata(null));

        public DataTemplate ListItemTemplate
        {
            get { return (DataTemplate)GetValue(ListItemTemplateProperty); }
            set { SetValue(ListItemTemplateProperty, value); }
        }

        public static readonly DependencyProperty ListItemTemplateProperty =
            DependencyProperty.Register(nameof(ListItemTemplate), typeof(DataTemplate), typeof(DropdownList), new PropertyMetadata(null, OnListItemTemplateChanged));

        public DataTemplate IconTemplate
        {
            get { return (DataTemplate)GetValue(IconTemplateProperty); }
            set { SetValue(IconTemplateProperty, value); }
        }

        public static readonly DependencyProperty IconTemplateProperty =
            DependencyProperty.Register(nameof(IconTemplate), typeof(DataTemplate), typeof(DropdownList), new PropertyMetadata(null, OnIconTemplateChanged));

        public IDropdownItem SelectedItem
        {
            get { return (IDropdownItem)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(nameof(SelectedItem), typeof(IDropdownItem), typeof(DropdownList), new PropertyMetadata(null, OnSelectedItemChanged));

        private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var owner = (DropdownList)d;
            owner.OnSelectedItemChanged((IDropdownItem)e.NewValue);
        }

        private static void OnListItemTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var owner = (DropdownList)d;
            owner.OnListItemTemplateChanged();
        }

        private static void OnIconTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var owner = (DropdownList)d;
            owner.OnIconTemplateChanged();
        }

        private FrameworkElement icon;

        public event Action<IDropdownItem> SelectedItemChanged;

        public DropdownList()
        {
            InitializeComponent();
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SelectedItem = null;
            List<IDropdownItem> filtered;

            if (Filter == null)
            {
                filtered = Items;
            }
            else
            {
                TextBox tb = (TextBox)sender;
                string filterText = tb.Text;
                filtered = Filter(filterText, Items);
            }
            if (filtered == null || filtered.Count == 0)
            {
                cb.IsDropDownOpen = false;
                return;
            }

            cb.ItemsSource = filtered;
            cb.IsDropDownOpen = true;
        }

        private void OnSelectedItemChanged(IDropdownItem selected)
        {
            
            if (selected != null)
            {
                tb.Text = selected.DropdownText;
            }
            if (icon != null)
            {
                icon.DataContext = selected;
            }
            cb.SelectedItem = selected;
            SelectedItemChanged?.Invoke(selected);

        }

        private void OnListItemTemplateChanged()
        {
            cb.ItemTemplate = ListItemTemplate;
        }

        private void OnIconTemplateChanged()
        {
            iconContainer.Children.Clear();
            if (IconTemplate == null)
            {
                iconContainer.Visibility = Visibility.Hidden;
                return;
            }
            icon = (FrameworkElement)IconTemplate.LoadContent();
            if (icon == null)
            {
                return;
            }
            icon.DataContext = SelectedItem;
            iconContainer.Children.Add(icon);
            iconContainer.Visibility = Visibility.Visible;

        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedItem == cb.SelectedItem)
            {
                return;
            }
            SelectedItem = (IDropdownItem)cb.SelectedItem;
        }
    }
}
