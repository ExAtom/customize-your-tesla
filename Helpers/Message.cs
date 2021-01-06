using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Threading;

namespace TeslaCarConfigurator.Helpers
{
    public class Message
    {
        private string message;

        private int time;

        private Color backgroundColor;

        public event Action Clicked;

        public event Action Closed;

        public event Action Dismissed;

        private CancellationTokenSource cancellation = new CancellationTokenSource();

        public Message(string message, int time, Color backgroundColor)
        {
            this.message = message;
            this.time = time;
            this.backgroundColor = backgroundColor;
        }

        public UIElement Show()
        {
            var container = new Button();
            container.Margin = new Thickness(5, 10, 5, 10);
            container.Style = (Style)Application.Current.FindResource("EmptyButtonStyle");
            container.Click += OnClicked;

            var text = new TextBlock();
            text.Text = message;
            text.Foreground = Brushes.White;
            text.FontSize = 30;


            var closeButton = new Button();
            closeButton.Style = (Style)Application.Current.FindResource("EmptyButtonStyle");
            closeButton.Content = new TextBlock() {Text="Bezárás", Foreground=Brushes.White };
            DockPanel.SetDock(closeButton, Dock.Top);
            closeButton.HorizontalAlignment = HorizontalAlignment.Right;
            closeButton.Click += OnDismissed;

            DockPanel dockPanel = new DockPanel();

            dockPanel.Children.Add(closeButton);
            dockPanel.Children.Add(text);
            dockPanel.Background = new SolidColorBrush(backgroundColor);

            container.Content = dockPanel;

            if (time != -1)
            {
                Wait();
            }
            return container;
        }

        private void OnDismissed(object sender, RoutedEventArgs e)
        {
            Dismissed?.Invoke();
            Dismissed = null;
            Closed?.Invoke();
            Closed = null;
            cancellation.Cancel();
        }

        private void OnClicked(object sender, RoutedEventArgs e)
        {
            Clicked?.Invoke();
            Clicked = null;
            Closed?.Invoke();
            Closed = null;
            cancellation.Cancel();
        }

        private async void Wait()
        {
            await Task.Delay(time);
            if (!cancellation.IsCancellationRequested)
            {
                Dismissed?.Invoke();
                Dismissed = null;
                Closed?.Invoke();
                Closed = null;
            }
        }

        
    }
}
