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
using TeslaCarConfigurator.Services;

namespace TeslaCarConfigurator.UserControls
{

    public partial class FlagDisplay : UserControl
    {
        public CountryInfo Country
        {
            get { return (CountryInfo)GetValue(CountryProperty); }
            set { SetValue(CountryProperty, value); }
        }

        public static readonly DependencyProperty CountryProperty =
            DependencyProperty.Register("Country", typeof(CountryInfo), typeof(FlagDisplay), new PropertyMetadata(null, OnCountryChanged));

        private static void OnCountryChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((FlagDisplay)d).OnCountryChanged();
        }

        public FlagDisplay()
        {
            InitializeComponent();
        }

        private async void OnCountryChanged()
        {
            svgContainer.SvgSource = null;
            if (Country?.Flag == null)
            {
                return;
            }
            try
            {
                string svgData = await CountryService.DownloadFlag(Country);
                svgContainer.SvgSource = svgData;
            }
            catch (Exception)
            {
                svgContainer.SvgSource = null;
            }
        }
    }
}
