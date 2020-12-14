using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TeslaCarConfigurator.Data;

namespace TeslaCarConfigurator.Helpers
{
    public class RoutingHelper
    {
        public PageBase CurrentPage { get; private set; }

        private UIElementCollection container;
        private CarConfiguration carConfiguration;
        

        public RoutingHelper(UIElementCollection container, CarConfiguration carConfiguration)
        {
            this.container = container;
            this.carConfiguration = carConfiguration;
        }

        public void ChangeCurrentPage(PageBase page)
        {
            container.Clear();
            page.Router = this;
            page.Config = carConfiguration;
            CurrentPage = page;
            container.Add(page);
        }
    }
}
