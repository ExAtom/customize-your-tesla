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

namespace TeslaCarConfigurator.UserControls
{
    
    public partial class LoadingContainer : UserControl
    {
        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }

        public static readonly DependencyProperty IsLoadingProperty =
            DependencyProperty.Register(nameof(IsLoading)  , typeof(bool), typeof(LoadingContainer), new PropertyMetadata(true, OnLoadingChanged));



        public UIElement RealContent
        {
            get { return (UIElement)GetValue(RealContentProperty); }
            set { SetValue(RealContentProperty, value); }
        }

        public static readonly DependencyProperty RealContentProperty =
            DependencyProperty.Register(nameof(RealContent), typeof(UIElement), typeof(LoadingContainer), new PropertyMetadata(null,OnContentChanged));



        private static void OnLoadingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((LoadingContainer)d).OnLoadingChanged();
        }

        private static void OnContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((LoadingContainer)d).OnContentChanged();
        }

        public LoadingContainer()
        {
            InitializeComponent();
        }

        private void OnLoadingChanged()
        {
            loadingImage.Visibility = IsLoading == true ? Visibility.Visible : Visibility.Collapsed;
            contentContainer.Visibility = IsLoading != true ? Visibility.Visible : Visibility.Collapsed;
        }

        private void OnContentChanged()
        {
            contentContainer.Children.Clear();
            if (Content != null)
            {
                contentContainer.Children.Add(RealContent);
            }
        }
    }
}
