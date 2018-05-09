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
using Google.Apis.Gmail.v1.Data;
using VCmail.Models;
using VCmail.ViewModels;
using VCmail.Extensions;
using System.Diagnostics;
using System.IO;

namespace VCmail
{
    /// <summary>
    /// Логика взаимодействия для ViewMessagePane.xaml
    /// </summary>
    public partial class ViewMessagePane : Page
    {
        public ViewMessagePane()
        {
            InitializeComponent();
        }

        public ViewMessagePane(MessageViewModel message)
        {
            InitializeComponent();
            var originalMsg = Messages.Get(message.MessageId);
            AddAttachments(originalMsg);

            this.DataContext = message;

            var body = originalMsg.GetBody();

            if (body.IsEmpty())
            {
                body = "This message does not contain body";
            }

            this.WebBrowserContent.NavigateToString(body);
        }

        private void AddAttachments(Message msg)
        {
            var attachemts = msg.GetAttachments();
            foreach(var attachment in attachemts)
            {
                var attachementView = GetAttachmentButton(attachment);
                AttachmentPanel.Children.Add(attachementView);
            }
            if (AttachmentPanel.Children.Count == 0)
            {
                AttachmentPanel.Visibility = Visibility.Collapsed;
            }
        }

        private Button GetAttachmentButton(MessagePart msg)
        {
            var button = new Button();
            string sizeString = "";
            if (msg.Body.Size.HasValue)
            {
                long size = msg.Body.Size.Value;
                sizeString = size.ToFileSize();
            }
            button.Content = msg.Filename + " (" + sizeString + ")";
            button.Margin = new Thickness(10);

            return button;
        }

    }
}
