using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TeslaCarConfigurator.Data;
using TeslaCarConfigurator.Helpers;
using TeslaCarConfigurator.UserControls.Summary;
using System.Globalization;

namespace TeslaCarConfigurator.Pages
{
    public partial class CustomerDetailsPage : PageBase
    {
        public CustomerDetailsPage()
        {
            InitializeComponent();
        }

        public override void OnAttachedToFrame()
        {
            if (Config == null)
            {
                return;
            }

            CustomerDetailsViewModel vm = new CustomerDetailsViewModel(Config);
            DataContext = vm;
            vm.LoadingFailed += OnLoadingFailed;
            vm.Init();
        }

        private void BuyCar(object sender, RoutedEventArgs e)
        {
            MessageBarController.ShowSuccess("Sikeres vásárlás!", 9000);

            var receiptOut = new List<string>();

            receiptOut.Add("Tesla Autó Konfigurátor\nSzámla\n\nKöszönjük, hogy nálunk vásárolt!\n----------\n");
            receiptOut.Add($"Model: {Config.CarModel.ModelName}\n\t+ {String.Format("{0:n0}", Config.CarModel.CalculateAdditionalPrices())} Ft");
            receiptOut.Add($"Akkumulátor: {Config.Battery.Capacity} kWh\n\t+ {String.Format("{0:n0}", Config.Battery.CalculateAdditionalPrices())} Ft");
            receiptOut.Add($"Festés: {Config.Painting.Color}\n\t+ {Config.Painting.CalculateAdditionalPrices()} Ft");
            receiptOut.Add($"Kerekek: {Config.Wheels.Type}\n\t+ {Config.Wheels.CalculateAdditionalPrices()} Ft");
            receiptOut.Add($"Váltó: {Config.Transmission.Type}\n\t+ {Config.Transmission.CalculateAdditionalPrices()}");
            receiptOut.Add($"Belső anyag: {Config.Interior.Material}\n\t+ {Config.Interior.MaterialPrices}");
            receiptOut.Add($"");
            receiptOut.Add($"");
            receiptOut.Add($"");
            receiptOut.Add($"");
            receiptOut.Add($"");
            receiptOut.Add($"");
            receiptOut.Add($"Teljes ár: {String.Format("{0:n0}", Config.TotalPrice)} Ft");
            receiptOut.Add($"");

            File.WriteAllLines("számla.txt", receiptOut);
        }

        private void OnLoadingFailed()
        {
            MessageBarController.ShowError("Országinformációk betöltése sikertelen. Kattintson ide az újrapróbálkozáshoz.",
                                           -1,
                                           onClick: (result) =>
                                           {
                                               var vm = (CustomerDetailsViewModel)DataContext;
                                               vm.LoadCountryInfos();
                                           });
        }

        private void Windows_Unloaded(object sender, RoutedEventArgs e)
        {
            if (DataContext != null && DataContext is CustomerDetailsViewModel vm)
            {
                vm.UnbindEventHandlers();
            }
        }
    }
}
