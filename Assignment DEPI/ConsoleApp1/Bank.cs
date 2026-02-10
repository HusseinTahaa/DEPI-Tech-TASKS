using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Bank
    {

        const string BankCode = "BNK001";
        public DateTime CreatedDate;
        private string branch;
        private string bankname;
        public decimal Balance;
        public int AccountNumber;
        public List<Customer> Customers { get; } = new List<Customer>();

        public Bank()
        {

            CreatedDate = DateTime.Now;
            branch = "N/A";
            bankname = "N/A";
            Balance= 0;
            AccountNumber= 0;
            Customers = new List<Customer>();
        }
        public void ShowBankReport()
        {
            Console.WriteLine("===== BANK REPORT =====");

            foreach (var customer in Customers)
            {
                Console.WriteLine($"Customer: {customer.FullName}");
                Console.WriteLine($"Total Balance: {customer.GetTotalBalance()}");



                foreach (var acc in customer.Accounts)
                {
                    Console.WriteLine($"  Account #{acc.AccountNumber} - Balance: {acc.Balance}");
                }

                Console.WriteLine("----------------------");
            }
        }
        public virtual void CalculateInterest()
        {
            Console.WriteLine("No interest calculation for base account.");
        }
    }
}
