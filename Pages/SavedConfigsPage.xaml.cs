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
using TeslaCarConfigurator.Data;
using TeslaCarConfigurator.Helpers;
using TeslaCarConfigurator.UserControls;

namespace TeslaCarConfigurator.Pages
{
    public partial class SavedConfigsPage : PageBase
    {
        private CarConfiguration TokenConfig;

        public SavedConfigsPage()
        {
            InitializeComponent();
            pageTitle.SetTitle("Mentett konfigurációk");

        }

        private void Windows_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            if (Windows.ActualWidth <= 710)
            {
                Menu.Width = double.NaN;
                Panel menuParent = (Panel)Menu.Parent;
                if (menuParent != null && menuParent != MobileContainer)
                {
                    menuParent.Children.Remove(Menu);
                    MobileContainer.Children.Add(Menu);
                }

                Panel loadConfigPanelParent = (Panel)loadConfigPanel.Parent;
                if (menuParent != null && loadConfigPanelParent != MobileContainer)
                {
                    loadConfigPanelParent.Children.Remove(loadConfigPanel);
                    MobileContainer.Children.Add(loadConfigPanel);
                }
                loadConfigPanel.HorizontalAlignment = HorizontalAlignment.Center;
                pageTitle.SwitchToMobile();
            }
            else
            {
                Menu.Width = 400;
                Panel menuParent = (Panel)Menu.Parent;
                if (menuParent != null && menuParent != DesktopContainer)
                {
                    menuParent.Children.Remove(Menu);
                    DesktopContainer.Children.Add(Menu);
                }

                Panel loadConfigPanelParent = (Panel)loadConfigPanel.Parent;
                if (menuParent != null && loadConfigPanelParent != DesktopContainer)
                {
                    loadConfigPanelParent.Children.Remove(loadConfigPanel);
                    DesktopContainer.Children.Add(loadConfigPanel);
                }
                loadConfigPanel.HorizontalAlignment = HorizontalAlignment.Right;

                pageTitle.SwitchToDesktop();
            }

        }

        public override void OnAttachedToFrame()
        {
            overrideWarning.Visibility = Router.HasConfig ? Visibility.Visible : Visibility.Collapsed;
            UpdateSavedConfigList();

        }

        private void UpdateSavedConfigList()
        {
            SaveManager.LoadSavedConfigs();
            loadingSaveFailedWarning.Visibility = SaveManager.FileLoadingFailed ? Visibility.Visible : Visibility.Collapsed;
            savedConfigsContainer.Children.Clear();

            foreach (var item in SaveManager.SavedConfigs)
            {
                UIElement generatedListItem = GenerateSavedItemDisplay(item.Key, item.Value);
                savedConfigsContainer.Children.Add(generatedListItem);
            }
        }

        private void btnBackToHome_Click(object sender, RoutedEventArgs e)
        {
            Router.ChangeCurrentPage(new LandingPage());
        }

        private UIElement GenerateSavedItemDisplay(Guid id, CarConfiguration savedConfig)
        {
            SavedConfigCard card = new SavedConfigCard(savedConfig?.ConfigName, savedConfig == null);

            card.LoadConfigClick += () => { ChooseConfig(savedConfig); };
            card.DeleteConfigClick += () => { DeleteConfig(id); };

            card.Margin = new Thickness(0, 0, 0, 20);

            return card;
        }

        private void DeleteConfig(Guid id)
        {
            try
            {
                SaveManager.DeleteConfig(id);
                MessageBarController.ShowSuccess("Konfig törölve.", 2000);
            }
            catch (Exception)
            {
                MessageBarController.ShowError("Konfig törlése sikertelen.", 2000);
            }
            UpdateSavedConfigList();
        }

        private void ChooseConfig(CarConfiguration cfg)
        {

            Router.SetConfig(cfg);
            Router.ChangeCurrentPage(new ModelConfiguration());
        }

        private void tbToken_TextChanged(object sender, TextChangedEventArgs e)
        {
            string token = tbToken.Text;
            invalidTokenWarning.Visibility = Visibility.Hidden;
            btnLoadFromToken.IsEnabled = false;
            try
            {
                TokenConfig = null;
                TokenConfig = new CarConfiguration(token);
            }
            catch (Exception)
            {
                invalidTokenWarning.Visibility = Visibility.Visible;
            }
            btnLoadFromToken.IsEnabled = TokenConfig != null;
        }

        private void btnLoadFromToken_Click(object sender, RoutedEventArgs e)
        {
            if (TokenConfig != null)
            {
                Router.SetConfig(TokenConfig);
                Router.ChangeCurrentPage(new ModelConfiguration());
            }
        }
    }
}
