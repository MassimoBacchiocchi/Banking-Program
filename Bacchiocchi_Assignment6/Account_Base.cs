using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account
{
    public abstract class Account_Base
    {
        private string name; //instance varables
        private decimal balance;

        public string Name
        {
            get { return name; }
            protected set { name = value; }
        }

        public decimal Balance //properties
        {
            get { return balance; }
            protected set { balance = value; }
        }

        public Account_Base(string nam, decimal bal) //sets instance varables
        {
            Name = nam;
            Balance = bal;
        }

        public abstract decimal CreditBalance(decimal credit); //stores info as an abstract method
        public abstract bool DebitBalance(decimal debit); //stores info as an abstract method
        public abstract decimal CalcInterest();
    }
}
