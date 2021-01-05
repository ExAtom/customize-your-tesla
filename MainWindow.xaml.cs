using System;
using System.Collections;
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
using System.Windows.Shapes;
using TeslaCarConfigurator.Data;
using TeslaCarConfigurator.Helpers;
using TeslaCarConfigurator.Pages;

namespace TeslaCarConfigurator
{
    public partial class MainWindow : Window
    {
        private RoutingHelper router;

        public MainWindow()
        {
            Initialized += OnWindowInitialized;
            InitializeComponent();
        }

        private void OnWindowInitialized(object sender, EventArgs e)
        {
            router = new RoutingHelper(Container);
            router.CurrentPageChanged += OnCurrentPageChanged;
            router.ChangeCurrentPage(new LandingPage());
        }

        private void OnCurrentPageChanged()
        {
            UpdateNavbarState();
        }

        private void btnSwitchPage_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            string pageName = btn.Name.Replace("btn", "");

            ChangePage(pageName);
        }

        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            if (router.CurrentPage == null)
            {
                return;
            }
            int buttonIndex = FindNavButtonIndexByPage(router.CurrentPage);
            if (buttonIndex == -1 || buttonIndex >= navigationButtonContainer.Children.Count - 1)
            {
                return;
            }
            Button nextBtn = (Button)navigationButtonContainer.Children[buttonIndex + 1];
            ChangePage(nextBtn.Name.Replace("btn", ""));
        }

        private void ChangePage(string pageName)
        {
            Type pageType = Type.GetType($"{nameof(TeslaCarConfigurator)}.{pageName}") ?? Type.GetType($"{nameof(TeslaCarConfigurator)}.{nameof(Pages)}.{pageName}");
            if (pageType != null)
            {
                PageBase page = (PageBase)Activator.CreateInstance(pageType);
                router.ChangeCurrentPage(page);
            }
        }

        private void UpdateNavbarState()
        {
            int buttonIndex = FindNavButtonIndexByPage(router.CurrentPage);
            IList navButtons = navigationButtonContainer.Children;
            for (int i = 0; i < navButtons.Count; i++)
            {
                Button navButton = (Button)navButtons[i];
                navButton.IsEnabled = i != buttonIndex;
            }

            navBar.Visibility = router.HasConfig ? Visibility.Visible : Visibility.Hidden;
        }

        private int FindNavButtonIndexByPage(PageBase page) {
            int navButtonIndex = -1;
            string pageName = page.GetType().Name;
            IList navButtons = navigationButtonContainer.Children;
            for (int i = 0; i < navButtons.Count; i++)
            {
                Button navButton = (Button)navButtons[i];
                if (navButton.Name.Replace("btn", "") == pageName)
                {
                    navButtonIndex = i;
                    break;
                }
            }
            return navButtonIndex;
        }
    }
}
