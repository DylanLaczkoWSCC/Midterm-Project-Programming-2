using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Project_Programming_2
{
    public class CheckingAccount
    {
        private string accountNumber;
        private decimal balance;

        public CheckingAccount(string accountNumber, decimal balance)
        {
            //variables
            this.accountNumber = accountNumber;
            this.balance = balance;
        }

        //Call function
        public decimal GetBalance()
        {
            return balance;
        }

    }

    public class SavingsAccount
    {
        private string accountNumber;
        private decimal balance;

        public SavingsAccount(string accountNumber, decimal balance)
        {
            //variables
            this.accountNumber = accountNumber;
            this.balance = balance;
        }

        //Call function
        public decimal GetBalance()
        {
            return balance;
        }

    }
}
