﻿using System;
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
            pageTitle.SetTitle("Vásárló adatai");
            Application.Current.MainWindow.MinWidth = 410;
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

        private void Windows_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            if (Windows.ActualWidth <= 710)
            {
                Menu.Width = Double.NaN;
                Panel col1Parent = (Panel)col1.Parent;
                if (col1Parent != null && col1Parent != MobileContainer)
                {
                    col1Parent.Children.Remove(col1);
                    MobileContainer.Children.Add(col1);
                }

                Panel col2Parent = (Panel)col2.Parent;
                if (col2Parent != null && col2Parent != MobileContainer)
                {
                    col2Parent.Children.Remove(col2);
                    MobileContainer.Children.Add(col2);
                }

                col2.Margin = new Thickness(0);

                pageTitle.SwitchToMobile();
            }
            else
            {
                Panel col1Parent = (Panel)col1.Parent;
                if (col1Parent != null && col1Parent != DesktopContainer)
                {
                    col1Parent.Children.Remove(col1);
                    DesktopContainer.Children.Add(col1);
                }

                Panel col2Parent = (Panel)col2.Parent;
                if (col2Parent != null && col2Parent != DesktopContainer)
                {
                    col2Parent.Children.Remove(col2);
                    DesktopContainer.Children.Add(col2);
                }

                col2.Margin = new Thickness(10, 0, 0, 0);

                pageTitle.SwitchToDesktop();
            }

        }

        private void BuyCar(object sender, RoutedEventArgs e)
        {
            bool isValid = ValidateForm();
            if (isValid)
            {
                MessageBarController.ShowSuccess("Sikeres vásárlás!", 9000);
                WriteReceipt();
            }

        }

        private void WriteReceipt()
        {
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

        private bool ValidateForm()
        {
            bool isValid = true;
            tbFirstnameError.Visibility = Visibility.Collapsed;
            tbLastnameError.Visibility = Visibility.Collapsed;
            tbPhoneNumberError.Visibility = Visibility.Collapsed;
            tbEmailAddressError.Visibility = Visibility.Collapsed;
            tbCountryError.Visibility = Visibility.Collapsed;
            tbZipCodeError.Visibility = Visibility.Collapsed;
            tbProvinceError.Visibility = Visibility.Collapsed;
            tbCityError.Visibility = Visibility.Collapsed;
            tbAddressError.Visibility = Visibility.Collapsed;
            tbCardNumberError.Visibility = Visibility.Collapsed;
            tbSecurityCodeError.Visibility = Visibility.Collapsed;
            tbCardFirstnameError.Visibility = Visibility.Collapsed;
            tbCardLastnameError.Visibility = Visibility.Collapsed;
            tbExpirationDateError.Visibility = Visibility.Collapsed;



            CustomerDetailsViewModel vm = (CustomerDetailsViewModel)DataContext;

            if (string.IsNullOrEmpty(vm.CustomerDetails.Firstname))
            {
                isValid = false;
                tbFirstnameError.Visibility = Visibility.Visible;
            }

            if (string.IsNullOrEmpty(vm.CustomerDetails.Lastname))
            {
                isValid = false;
                tbLastnameError.Visibility = Visibility.Visible;
            }

            if (!vm.CustomerDetails.PhoneNumber.Isvalid)
            {
                isValid = false;
                tbPhoneNumberError.Visibility = Visibility.Visible;
            }


            if (string.IsNullOrEmpty(vm.CustomerDetails.EmailAddress))
            {
                isValid = false;
                tbEmailAddressError.Visibility = Visibility.Visible;
            }

            if (vm.CustomerDetails.Country == null)
            {
                isValid = false;
                tbCountryError.Visibility = Visibility.Visible;
            }

            if (string.IsNullOrEmpty(vm.CustomerDetails.ZipCode))
            {
                isValid = false;
                tbZipCodeError.Visibility = Visibility.Visible;
            }

            if (string.IsNullOrEmpty(vm.CustomerDetails.Province))
            {
                isValid = false;
                tbProvinceError.Visibility = Visibility.Visible;
            }

            if (string.IsNullOrEmpty(vm.CustomerDetails.City))
            {
                isValid = false;
                tbCityError.Visibility = Visibility.Visible;
            }

            if (string.IsNullOrEmpty(vm.CustomerDetails.Address))
            {
                isValid = false;
                tbAddressError.Visibility = Visibility.Visible;
            }

            if (string.IsNullOrEmpty(vm.CustomerDetails.CreditCard.CardNumber))
            {
                isValid = false;
                tbCardNumberError.Visibility = Visibility.Visible;
            }

            if (string.IsNullOrEmpty(vm.CustomerDetails.CreditCard.SecurityCode))
            {
                isValid = false;
                tbSecurityCodeError.Visibility = Visibility.Visible;
            }

            if (string.IsNullOrEmpty(vm.CustomerDetails.CreditCard.Firstname))
            {
                isValid = false;
                tbCardFirstnameError.Visibility = Visibility.Visible;
            }

            if (string.IsNullOrEmpty(vm.CustomerDetails.CreditCard.Lastname))
            {
                isValid = false;
                tbCardLastnameError.Visibility = Visibility.Visible;
            }

            if (string.IsNullOrEmpty(vm.CustomerDetails.CreditCard.ExpirationDate))
            {
                isValid = false;
                tbExpirationDateError.Visibility = Visibility.Visible;
            }

            return isValid;
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
