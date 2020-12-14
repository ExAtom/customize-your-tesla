using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TeslaCarConfigurator.Data;

namespace TeslaCarConfigurator.Helpers
{
    public class RoutingHelper
    {
        public PageBase CurrentPage { get; private set; }

        private Frame container;
        private CarConfiguration carConfiguration;
        
        public RoutingHelper(Frame frame)
        {
            container = frame;
        }

        public void ChangeCurrentPage(PageBase page)
        {
            page.Router = this;
            page.Config = carConfiguration;
            CurrentPage = page;
            container.Content = page;
        }

        public void SetConfig(CarConfiguration carConfiguration)
        {
            this.carConfiguration = carConfiguration;

        }
    }
}
