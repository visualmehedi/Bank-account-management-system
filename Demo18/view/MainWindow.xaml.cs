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
using Demo18.Service;
using Demo18.Model;
namespace Demo18
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AccountService accountservice;
        public MainWindow()
        {
            InitializeComponent();
            accountservice = new AccountService(new Repository());
        }

        private void btnAdminSaveAccountNr_Click(object sender, RoutedEventArgs e)
        {
            string accountnumber = tbxAdminAcoountNr.Text;
            accountservice.SaveAccount(accountnumber);
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbxMainAccount.ItemsSource = accountservice.GetAccountNumbersForComboBox();
        }

        private void btnMainSaveDeposit_Click(object sender, RoutedEventArgs e)
        {
            string amountAsStream = txbMainDeposit.Text;
            string selectedaccount = cbxMainAccount.SelectedItem.ToString();

            accountservice.SaveDepositToAccount(amountAsStream, selectedaccount);
        }

        private void btnMainSaveUppdate_Click(object sender, RoutedEventArgs e)
        {
            string AccountNumber = cbxMainAccount.SelectedItem.ToString();
            txbMainBalance.Text = accountservice.Balance(AccountNumber).ToString();
        }

        //private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}
    }
}
