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

namespace TeslaCarConfigurator.Pages
{
    public partial class SavedConfigsPage : PageBase
    {
        private CarConfiguration TokenConfig;

        public SavedConfigsPage()
        {
            InitializeComponent();


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
            DockPanel container = new DockPanel();


            TextBlock nameBox = new TextBlock()
            {
                Text = savedConfig?.ConfigName ?? "Hibás mentés.",
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(0, 0, 10, 0),
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = savedConfig == null ? Brushes.Red : Brushes.Black
            };

            StackPanel buttonContainer = new StackPanel() { Orientation = Orientation.Horizontal };

            Button deleteButton = new Button()
            {
                Width = 50,
                Height = 50,
                Content = new Image()
                {
                    Source = new BitmapImage(new Uri("../Assets/close.png", UriKind.Relative))
                },
                Style = (Style)Application.Current.FindResource("EmptyButtonStyle")
            };
            deleteButton.Click += (sender, e) =>
            {
                DeleteConfig(id);
            };

            buttonContainer.Children.Add(deleteButton);

            if (savedConfig != null)
            {
                Button chooseButton = new Button()
                {
                    Width = 50,
                    Height = 50,
                    Content = new Image()
                    {
                        Source = new BitmapImage(new Uri("../Assets/arrow-circle-right-solid.png", UriKind.Relative))
                    },
                    Style = (Style)Application.Current.FindResource("EmptyButtonStyle")
                };
                chooseButton.Click += (sender, e) =>
                {
                    ChooseConfig(savedConfig);
                };
                buttonContainer.Children.Add(chooseButton);
            }

            DockPanel.SetDock(buttonContainer, Dock.Right);
            container.Children.Add(buttonContainer);
            container.Children.Add(nameBox);
            return container;
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
