using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account
{
    class Savings_Account : Account_Base //inherits Account_Base class
    {
        private string nam;
        private decimal bal;
        private decimal interestRate;

        public Savings_Account(string nam, decimal bal) : base(nam, bal)
        {
            this.nam = nam;
            this.bal = bal;
        }

        public Savings_Account(string nam, decimal bal, decimal interest) : base(nam, bal)
        {
            interestRate = interest;
        }

        public override decimal CreditBalance(decimal credit)
        {
            Balance += credit;
            Console.WriteLine("New Account Balance After Credit ${0}", Balance);
            return Balance;
        }

        public override bool DebitBalance(decimal debit)
        {
            if (debit > Balance)
            {
                Console.WriteLine("Debit ammount exceeded account balance");
                return false;
            }
            else
            {
                Balance -= debit;
                Console.WriteLine("Debit Deducted Successfully");
                return true;
            }
        }

        public override decimal CalcInterest()
        {
            return (interestRate * Balance) + Balance;
        }
    }
}
