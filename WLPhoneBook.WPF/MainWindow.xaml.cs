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
using WLPhoneBook.Library;

namespace WLPhoneBook.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PhoneBook PhoneBookInstance;

        public MainWindow()
        {
            InitializeComponent();
            PhoneBookInstance = new PhoneBook();
            PhoneBookRecordsListView.ItemsSource = PhoneBookInstance.Records;
            SearchTextBox.Focus();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PhoneBookRecordsListView.ItemsSource = PhoneBookInstance.SearchRecords(((TextBox)sender).Text.ToString());
        }
    }
}
