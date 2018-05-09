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
using Label = Google.Apis.Gmail.v1.Data.Label;
using VCmail.Models;
using VCmail.ViewModels;

namespace VCmail
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Credentials.Login();

            var labels = Labels.GetList();
            LabelsList.ItemsSource = labels.Select((x) => new LabelViewModel(x));
        }

        private void LabelList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LabelsList.SelectedItem is LabelViewModel label)
            {
                LoadMessageList(label.Name);
            }
        }

        private void LoadMessageList(string labelName)
        {
            var msgs = Messages.GetList(labelName);
            MessagesList.ItemsSource = msgs.Select((x) => new MessageViewModel(x));
        }

        private void MessagesList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MessagesList.SelectedItem is MessageViewModel message)
            {
                ContentFrame.Content = new ViewMessagePane(message);
            }
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SearchTextBox.Text)){
                var query = SearchTextBox.Text.ToLower();

                var messages = MessagesList.ItemsSource as IEnumerable<MessageViewModel>;
                if (messages != null)
                {
                    var newList = new List<MessageViewModel>();
                    newList = messages.Where((x) => x.Contains(query)).ToList();
                    MessagesList.ItemsSource = newList;
                }
            }
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            var createWindow = new CreateWindow();
            createWindow.Show();
        }
    }
}
