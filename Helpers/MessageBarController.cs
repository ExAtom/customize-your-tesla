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

        public Task<bool> ShowSuccess(string text, int time, bool showYesNo = false, Action onClick = null, Action onClose = null, Action onDismiss = null)
        {
            return ShowMessage(text, time, MessageType.Success, showYesNo, onClick, onClose, onDismiss);

        }

        public Task<bool> ShowError(string text, int time, bool showYesNo = false, Action onClick = null, Action onClose = null, Action onDismiss = null)
        {
            return ShowMessage(text, time, MessageType.Error, showYesNo, onClick, onClose, onDismiss);
        }

        public Task<bool> ShowWarning(string text, int time, bool showYesNo = false, Action onClick = null, Action onClose = null, Action onDismiss = null)
        {
            return ShowMessage(text, time, MessageType.Warning, showYesNo, onClick, onClose, onDismiss);
        }

        private Task<bool> ShowMessage(string text, int time, MessageType type, bool showYesNo = false, Action onClick = null, Action onClose = null, Action onDismiss = null)
        {
            Message message = new Message(text, time, type);
            message.Clicked += onClick;
            message.Closed += onClose;
            message.Dismissed += onDismiss;

            message.Closed += OnClosed(message);

            messages.Add(message);
            Task<bool> task = GetTaskFromMessage(message);
            container.Children.Add(message.Show());
            return task;
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

        private Task<bool> GetTaskFromMessage(Message m)
        {
            var tcs = new TaskCompletionSource<bool>();
            m.Clicked += () =>
            {
                tcs.SetResult(true);
            };
            m.Dismissed += () =>
            {
                tcs.SetResult(false);
            };
            return tcs.Task;
        }
    }
}
