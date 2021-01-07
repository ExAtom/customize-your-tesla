using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Threading;
using SharpVectors.Converters;
using System.Windows.Media.Imaging;

namespace TeslaCarConfigurator.Helpers
{
    public class Message
    {
        private string message;

        private int time;

        private MessageType Type;

        public event Action Clicked;

        public event Action Closed;

        public event Action Dismissed;

        private CancellationTokenSource cancellation = new CancellationTokenSource();

        public Message(string message, int time, MessageType type)
        {
            this.message = message;
            this.time = time;
            Type = type;
        }

        public UIElement Show()
        {
            var container = new Button
            {
                Style = (Style)Application.Current.FindResource($"Popup{Type}MessageContainerStyle")
            };
            container.Click += OnClicked;

            var text = new TextBlock
            {
                Text = message,
                Foreground = Brushes.White,
                FontSize = 20,
                TextWrapping = TextWrapping.Wrap,
                TextAlignment = TextAlignment.Center,
                Padding = new Thickness(0, 10, 0, 10)
            };

            var closeButton = new Button();
            closeButton.Style = (Style)Application.Current.FindResource("PopupCloseButtonStyle");
            closeButton.Click += OnDismissed;

            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(34, GridUnitType.Pixel)
            });

            Grid.SetColumn(text, 0);
            Grid.SetColumn(closeButton, 1);

            grid.Children.Add(closeButton);
            grid.Children.Add(text);

            container.Content = grid;

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

    public enum MessageType
    {
        Error, Success
    }
}
