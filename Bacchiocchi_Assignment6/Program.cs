using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_Account; //links rest of program to the Program.cs

namespace Bacchiocchi_Assignment6
{
    class Program
    {
        static void Main(string[] args)
        {
            Account_Base[] account = new Account_Base[3]; // creates an array
            var again = "y";
            try
            {
                Console.Write("How many accounts would you like to add?: ");
                int numberOfAccounts = Convert.ToInt32(Console.ReadLine());
                if (numberOfAccounts > 3) //makes the array a max of 3
                {
                    numberOfAccounts = 3;
                }
                for (int numAccount = 0; numAccount < numberOfAccounts; numAccount++)
                {
                    Console.Write("Enter a name: ");
                    string userName = Convert.ToString(Console.ReadLine());
                    Console.Write("Enter your balance: ");
                    decimal userBalance = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Savings or Checking account?: ");
                    string accountType = Convert.ToString(Console.ReadLine());
                    if (accountType == "savings") //runs if savings is selected
                    {
                        Console.Write("Enter interest rate: ");
                        decimal userInterest = Convert.ToDecimal(Console.ReadLine());
                        account[numAccount] = new Savings_Account(userName, userBalance, userInterest);
                    }
                    if (accountType == "checking") //runs if checking is selected
                    {
                        Console.Write("Enter fee: ");
                        decimal userFee = Convert.ToDecimal(Console.ReadLine());
                        account[numAccount] = new Checking_Account(userName, userBalance, userFee);
                    }

                }

                while (again == "y")
                {
                    Console.Write("Enter a name to look up: ");
                    string nameOf = Convert.ToString(Console.ReadLine());
                    for (int nameCount = 0; nameCount < numberOfAccounts; nameCount++) //checks if name is in the array
                    {
                        if (account[nameCount].Name == nameOf) //runs if came is in array
                        {
                            int choice = 0; //gives user options

                            Console.WriteLine("1. Credit to account");
                            Console.WriteLine("2. Debit from account");
                            Console.WriteLine("3. Calculate interest");
                            Console.WriteLine("4. Exit");
                            Console.WriteLine("Enter a choice: ");
                            choice = Convert.ToInt32(Console.ReadLine());
                            if (choice == 1) //adds money to account
                            {
                                Console.Write("Enter credit amount: "); 
                                decimal credit = Convert.ToDecimal(Console.ReadLine());
                                account[nameCount].CreditBalance(credit);
                                Console.WriteLine("Current balance is: ${0}", account[nameCount].Balance);
                            }
                            if (choice == 2) //deducts money from account
                            {
                                Console.Write("Enter debit amount: ");
                                decimal debit = Convert.ToDecimal(Console.ReadLine());
                                account[nameCount].DebitBalance(debit);
                                Console.WriteLine("Current balance is: ${0}", account[nameCount].Balance);
                            }
                            if (choice == 3) //calculates interest rate if account is savings and adds it to balance
                            {
                                if (account[nameCount] is Savings_Account)
                                {
                                    Console.WriteLine("Calculated interest rate is: {0}", account[nameCount].CalcInterest());
                                }
                            }
                            if (choice >= 4) //end
                            {
                                Console.WriteLine("Goodbye");
                            }
                        }
                    }

                    Console.WriteLine("Try again? (y/n): "); //runs program again or does not
                    again = Convert.ToString(Console.ReadLine());


                }
            }

            catch (StackOverflowException) //if a number is larger than the maximum decimal value
            {
                Console.WriteLine("ERROR: NUMBER EXCEEDS MAX DECIMAL VALUE");
            }
            catch (IndexOutOfRangeException) //if there are too many accounts
            {
                Console.WriteLine("Unable to process new bank accounts at this time, try again later");
            }
            catch (ArgumentNullException) //if the name is not in the array
            {
                Console.WriteLine("You do not have a bank account at this bank");
            }
            catch (ArgumentException) //if they try to credit a negative amount of money
            {
                Console.WriteLine("ERROR: NUMBER CANNOT BE NEGATIVE");
            }
            Console.ReadLine();
        }
        
    }
}
