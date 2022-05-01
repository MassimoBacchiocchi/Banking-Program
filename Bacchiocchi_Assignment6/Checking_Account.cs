using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account
{
    class Checking_Account : Savings_Account  //inherits Savings_Account
    {
        private decimal fee;

        public Checking_Account(string nam, decimal bal, decimal fees) : base(nam, bal)
        {
            fee = fees;
        }

        public override decimal CreditBalance(decimal credit) //subtracts fee
        {
            return Balance += credit;
        }

        public override bool DebitBalance(decimal debit) //subtracts fee and returns true or false
        {
            if (debit + fee > Balance)
            {
                Console.WriteLine("Debit ammount exceeded account balance");
                return false;
            }
            else
            {
                Console.WriteLine("Debit ammount excedeed account balance");
                Balance -= fee + debit;
                return true;
            }
        }
    }
}
