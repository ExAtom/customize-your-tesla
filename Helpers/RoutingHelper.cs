using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using TeslaCarConfigurator.Data;

namespace TeslaCarConfigurator.Helpers
{
    public class RoutingHelper
    {
        public PageBase CurrentPage { get; private set; }

        public bool HasConfig => carConfiguration != null;

        public event Action CurrentPageChanged;

        private Frame container;
        private CarConfiguration carConfiguration;

        public RoutingHelper(Frame frame)
        {
            container = frame;
            container.Navigated += OnFrameNavigation;

        }

        private void OnFrameNavigation(object sender, NavigationEventArgs e)
        {
            container.NavigationService.RemoveBackEntry();
        }

        public void ChangeCurrentPage(PageBase page)
        {
            page.Router = this;
            page.Config = carConfiguration;
            CurrentPage = page;
            container.Content = page;
            page.OnAttachedToFrame();
            CurrentPageChanged?.Invoke();
        }

        public void SetConfig(CarConfiguration carConfiguration)
        {
            this.carConfiguration = carConfiguration;

        }

    }
}
