using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CurrentAccount : Customer
    {
        public decimal OverdraftLimit { get; set; }

        public CurrentAccount(decimal balance, decimal overdraftLimit)
            : base(balance)
        {
            OverdraftLimit = overdraftLimit;
        }
       
        public override void ShowAccountDetails()
        {
            Console.WriteLine("----- Account Details -----");

            Console.WriteLine($"Balance     : ${Balance}");
            Console.WriteLine($"Overdraft Limit: {OverdraftLimit}");
        }

        public override void CalculateInterest()
        {
            Console.WriteLine("Current account does not earn interest.");
        }
    }
}
