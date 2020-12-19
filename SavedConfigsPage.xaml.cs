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

namespace TeslaCarConfigurator
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
            savedConfigsContainer.Items.Clear();
            for (int i = 0; i < SaveManager.SavedConfigs.Count; i++)
            {
                CarConfiguration savedConfig = SaveManager.SavedConfigs[i];
                UIElement generatedListItem = GenerateSavedItemDisplay(savedConfig, i);
                savedConfigsContainer.Items.Add(generatedListItem);
            }
        }

        private void btnBackToHome_Click(object sender, RoutedEventArgs e)
        {
            Router.ChangeCurrentPage(new LandingPage());
        }

        private UIElement GenerateSavedItemDisplay(CarConfiguration savedConfig, int index)
        {
            WrapPanel panel = new WrapPanel();

            if (savedConfig == null)
            {
                TextBlock errorBox = new TextBlock() { Text = "Hibás mentés.", Foreground = Brushes.Red };
                panel.Children.Add(errorBox);
            }
            else
            {
                Grid grid = new Grid();
                grid.RowDefinitions.Add(new RowDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50) });

                TextBlock nameBox = new TextBlock() 
                { 
                    Text = savedConfig.ConfigName, 
                    Width=225, 
                    TextWrapping=TextWrapping.Wrap ,
                    Margin=new Thickness(0,0,10,0), 
                    VerticalAlignment=VerticalAlignment.Center 
                };

                Button chooseButton = new Button()
                {
                    Width = 50,
                    Height = 50,
                    Name=$"chooseButton{index}",
                    Content = new Image() 
                    {
                        Source = new BitmapImage(new Uri("Assets/arrow-circle-right-solid.png", UriKind.Relative))
                    } 
                };
                chooseButton.Click += chooseButton_Click;

                grid.Children.Add(nameBox);
                grid.Children.Add(chooseButton);

                Grid.SetColumn(nameBox, 0);
                Grid.SetRow(nameBox, 0);
                Grid.SetColumn(chooseButton, 1);
                Grid.SetRow(chooseButton, 1);

                panel.Children.Add(grid);
            }

            return panel;
        }

        private void chooseButton_Click(object sender, RoutedEventArgs e)
        {
            Button chooseButton = (Button)sender;
            int index = int.Parse(chooseButton.Name.Replace("chooseButton", ""));
            Router.SetConfig(SaveManager.SavedConfigs[index]);
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
