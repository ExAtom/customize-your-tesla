using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace TeslaCarConfigurator.Helpers
{
    public class MessageBarController
    {
        private StackPanel container;

        private List<Message> messages = new List<Message>();

        public MessageBarController(StackPanel container)
        {
            this.container = container;
        }

        public void ShowSuccess(string text, int time,Action onClick = null, Action onClose = null, Action onDismiss = null) 
        {
            Message message = new Message(text,time,Color.FromArgb(220,0,255,0));
            message.Clicked += onClick;
            message.Closed += onClose;
            message.Dismissed += onDismiss;

            message.Closed += OnClosed(message);

            messages.Add(message);
            container.Children.Add(message.Show());
        }

        public void ShowError(string text, int time, Action onClick = null, Action onClose = null, Action onDismiss = null)
        {
            Message message = new Message(text, time, Color.FromArgb(220, 255, 0, 0));
            message.Clicked += onClick;
            message.Closed += onClose;
            message.Dismissed += onDismiss;

            message.Closed += OnClosed(message);

            messages.Add(message);
            container.Children.Add(message.Show());

        }


        private Action OnClosed(Message m)
        {
            return () => 
            {
                int i = messages.FindIndex(x => x == m);
                if (i >= 0)
                {
                    messages.RemoveAt(i);
                    container.Children.RemoveAt(i);
                }
            };
        }
    }
}
