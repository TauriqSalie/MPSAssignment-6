using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Banking;


namespace BankingApplication
{
    public partial class MainPage : ContentPage
    {
        private BankAccount account;
        private Customer myNewCustomer;
        public MainPage()
        {
            InitializeComponent();

            Bank standardbank = new Bank("Standard Bank", 4324, "Kenilworth");
            myNewCustomer = new Customer("7766445424", "10 me at home", "Bob", "The Builder");
            standardbank.AddCustomer(myNewCustomer);
            account = myNewCustomer.ApplyForBankAccount();
        }

        private void Deposit_Button_Clicked(object sender, EventArgs e)
        {
            decimal depositamount = decimal.Parse(DepositMoneyEntry.Text);
            account.DepositMoney(depositamount, DateTime.Now, "Deposit Money");
  
        }
        

        private void Withdrawal_Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                decimal withdrawalamount = decimal.Parse(WithdrawMoneyEntry.Text);
                account.WithdrawMoney(withdrawalamount, DateTime.Now, "Withdraw Money");
            }
            
            catch
            {
                
            }
           
                
            
        }

        private void Transactions_Button_Clicked(object sender, EventArgs e)
        {
            var history = account.GetTransactionHistory();
            DisplayTransactionsEntry.Text = history; 
            
        }
    }
}
