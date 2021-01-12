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
    public partial class AccordionItem : UserControl
    {
        public bool IsOpened { get; private set; }

        public UIElement AccordionHeader
        {
            get { return (UIElement)GetValue(AccordionHeaderProperty); }
            set { SetValue(AccordionHeaderProperty, value); }
        }

        public static readonly DependencyProperty AccordionHeaderProperty =
            DependencyProperty.Register(nameof(AccordionHeader), typeof(UIElement), typeof(AccordionItem), new PropertyMetadata(null,OnHeaderChanged));


        public UIElement AccordionContent
        {
            get { return (UIElement)GetValue(AccordionContentProperty); }
            set { SetValue(AccordionContentProperty, value); }
        }

        public static readonly DependencyProperty AccordionContentProperty =
            DependencyProperty.Register(nameof(AccordionContent), typeof(UIElement), typeof(AccordionItem), new PropertyMetadata(null,OnContentChanged));

        private static void OnHeaderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AccordionItem)d).OnHeaderChanged();
        }

        private static void OnContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AccordionItem)d).OnContentChanged();
        }

        public AccordionItem()
        {
            InitializeComponent();
        }

        private void OnHeaderChanged()
        {
            headerContainer.Content = AccordionHeader;
        }

        private void OnHeaderClick(object sender, RoutedEventArgs e)
        {
            IsOpened = !IsOpened;
            contentContainer.Visibility = IsOpened ? Visibility.Visible : Visibility.Collapsed;
            separator.Visibility = IsOpened ? Visibility.Visible : Visibility.Collapsed;

            headerContainer.Style = (Style)Application.Current.FindResource($"Accordion{(IsOpened ? "Opened" : "Closed")}HeaderStyle");
        }

        private void OnContentChanged()
        {
            contentContainer.Content = AccordionContent;
        }
    }
}
