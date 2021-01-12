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
            receiptOut.Add($"Festés: {Config.Painting.Color}\n\t+ {String.Format("{0:n0}", Config.Painting.CalculateAdditionalPrices())} Ft");
            receiptOut.Add($"Kerekek: {Config.Wheels.Type}\n\t+ {String.Format("{0:n0}", Config.Wheels.CalculateAdditionalPrices())} Ft");
            receiptOut.Add($"Váltó: {Config.Transmission.Type}\n\t+ {String.Format("{0:n0}", Config.Transmission.CalculateAdditionalPrices())} Ft");
            receiptOut.Add($"Belső anyag: {Config.Interior.Material}\n\t+ {String.Format("{0:n0}", Interior.MaterialPrices[Config.Interior.MaterialIndex])} Ft");
            receiptOut.Add($"Belső szín: {Config.Interior.InteriorColor}\n\t+ {String.Format("{0:n0}", Interior.ColorPrices[Config.Interior.ColorIndex])} Ft");
            if (Config.Interior.HasSeatHeating)
                receiptOut.Add($"Ülésfűtés\n\t+ {String.Format("{0:n0}", Interior.SeatHeatingPrice)} Ft");
            if (Config.Interior.HasSteeringWheelHeating)
                receiptOut.Add($"Kormányfűtés\n\t+ {String.Format("{0:n0}", Interior.SteeringWheelHeatingPrice)} Ft");
            if (Config.Interior.HasSpineSupport)
                receiptOut.Add($"Gerinctámasz\n\t+ {String.Format("{0:n0}", Interior.SpineSupportPrice)} Ft");
            if (Config.Interior.HasSunlightProtection)
                receiptOut.Add($"Napvédő\n\t+ {String.Format("{0:n0}", Interior.SunlightProtectionPrice)} Ft");
            if (Config.Interior.HasDarkenedWindows)
                receiptOut.Add($"Sötétített ablakok\n\t+ {String.Format("{0:n0}", Interior.DarkenedWindowsPrice)} Ft");
            if (Config.Exterior.HasLinenRoof)
                receiptOut.Add($"Vászontető\n\t+ {String.Format("{0:n0}", Exterior.LinenRoofPrice)} Ft");
            if (Config.Exterior.HasSpoilers)
                receiptOut.Add($"Spoilerek\n\t+ {String.Format("{0:n0}", Exterior.SpoilersPrice)} Ft");
            if (Config.Exterior.HasBottomLights)
                receiptOut.Add($"Alulvilágítás\n\t+ {String.Format("{0:n0}", Exterior.BottomLightsPrice)} Ft");
            if (Config.SoftwareFeatures.HasSelfdriving)
                receiptOut.Add($"Önvezetés\n\t+ {String.Format("{0:n0}", SoftwareFeatures.SelfdrivingPrice)} Ft");
            if (Config.SoftwareFeatures.HasGps)
                receiptOut.Add($"GPS\n\t+ {String.Format("{0:n0}", SoftwareFeatures.GpsPrice)} Ft");
            if (Config.SoftwareFeatures.HasHeadlightAssistant)
                receiptOut.Add($"Távolsági fényszóró asszisztens\n\t+ {String.Format("{0:n0}", SoftwareFeatures.HeadlightAssistantPrice)} Ft");
            if (Config.SoftwareFeatures.HasAdaptiveLights)
                receiptOut.Add($"Adaptív fényszórók\n\t+ {String.Format("{0:n0}", SoftwareFeatures.AdaptiveLightsPrice)} Ft");
            receiptOut.Add($"---");
            receiptOut.Add($"Teljes ár: {String.Format("{0:n0}", Config.TotalPrice)} Ft");
            receiptOut.Add($"----------\n");
            receiptOut.Add($"Vásárló adatai\n");
            receiptOut.Add($"Név: {Config.CustomerDetails.Lastname} {Config.CustomerDetails.Firstname}");
            receiptOut.Add($"Telefonszám: {Config.CustomerDetails.PhoneNumber.CallingCode.Prefix}{Config.CustomerDetails.PhoneNumber.Number}");
            receiptOut.Add($"E-mail cím: {Config.CustomerDetails.EmailAddress}");
            receiptOut.Add($"---\n");
            receiptOut.Add($"Szállítási cím\n");
            receiptOut.Add($"Ország: {Config.CustomerDetails.Country.NativeName}");
            receiptOut.Add($"Irányítószám: {Config.CustomerDetails.ZipCode}");
            receiptOut.Add($"Megye/Régió/Tartomány: {Config.CustomerDetails.Province}");
            receiptOut.Add($"Város: {Config.CustomerDetails.City}");
            receiptOut.Add($"Cím: {Config.CustomerDetails.Address}");
            receiptOut.Add($"---\n");
            receiptOut.Add($"Bankkártya adatok\n");
            receiptOut.Add($"Bankkártyaszám: {Config.CustomerDetails.CreditCard.CardNumber}");
            receiptOut.Add($"Lejárat: {Config.CustomerDetails.CreditCard.ExpirationDate}");
            receiptOut.Add($"Név: {Config.CustomerDetails.CreditCard.Lastname} {Config.CustomerDetails.CreditCard.Firstname}");
            receiptOut.Add($"Biztonsági kód: {Config.CustomerDetails.CreditCard.SecurityCode}");
            receiptOut.Add($"----------\n\nAz autó kiszállítása egy hónapon belül megtörténik.");

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
