using Google.Apis.Gmail.v1.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
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
using VCmail.Extensions;
using VCmail.Models;

namespace VCmail
{
    /// <summary>
    /// Логика взаимодействия для CreateWindow.xaml
    /// </summary>
    public partial class CreateWindow : Window
    {
        public CreateWindow()
        {
            InitializeComponent();
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            if (!IsValidMessage())
            {
                return;
            }

            var rawMessage = ConstructRawMessage();
            Messages.Send(rawMessage);

        }

        private string ConstructRawMessage()
        {
            var msg = new AE.Net.Mail.MailMessage
            {
                Subject = TextBoxSubject.Text,
                Body = MsgTextBox.Text,
                From = new MailAddress(Credentials.Email)
            };
            msg.To.Add(new MailAddress(TextBoxTo.Text));
            msg.ReplyTo.Add(msg.From); // Bounces without this!!
            ContructRawAttacments(msg);
            var msgStr = new StringWriter();
            msg.Save(msgStr);

            return AppCode.Encoding.Base64UrlEncode(msgStr.ToString());
        }

        private void ContructRawAttacments(AE.Net.Mail.MailMessage msg)
        {
            foreach (var child in StackPanelAttachments.Children)
            {
                if (child is TextBlock txtBlock)
                {
                    var fullPath = txtBlock.DataContext as string;
                    var fileName = txtBlock.Text;
                    if (fileName.IsNotEmpty() && fullPath.IsNotEmpty())
                    {
                        try
                        {
                            var bytes = File.ReadAllBytes(fullPath);

                            var attachment = new AE.Net.Mail.Attachment(
                                bytes,
                                System.Web.MimeMapping.GetMimeMapping(fileName),
                                fileName,
                                true);

                            msg.Attachments.Add(attachment);
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e.Message);
                        }
                    }
                }
            }
        }


        private bool IsValidMessage()
        {
            if (TextBoxTo.Text.IsEmpty())
            {
                return ShowWarning("Invalid recepients, please specify them in field To, Copy, Hidden Copy");
            }

            return true;
        }

        private bool ShowWarning(string msg)
        {
            MessageBox.Show("Error sending the message", msg,
            MessageBoxButton.OK, MessageBoxImage.Warning);

            return false;
        }

        private void BtnAddAttachment_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            bool? result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;

                var textBlock = new TextBlock();
                textBlock.Text = System.IO.Path.GetFileName(filename);
                textBlock.DataContext = filename;

                StackPanelAttachments.Children.Add(textBlock);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (TextBoxTo.Text.IsNotEmpty() ||
                TextBoxCopy.Text.IsNotEmpty() ||
                TextBoxHiddenCopy.Text.IsNotEmpty() ||
                TextBoxSubject.Text.IsNotEmpty() ||
                MsgTextBox.Text.IsNotEmpty())
            {
                var result = MessageBox.Show("Do you want to save this message to drafts?", "Save to Drafts", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var rawMessage = ConstructRawMessage();
                    Messages.SaveToDrafts(rawMessage);
                }
            }
        }
    }
}
