using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SavingAccount : Customer
    {
        public decimal InterestRate { get; set; }

        public SavingAccount(decimal balance, decimal interestRate)
            : base(balance)
        {
               
            InterestRate = interestRate;
        }
        public void ApplyMonthlyInterest()
        {
            decimal interest = Balance * (InterestRate / 100) / 12;
            Balance += interest;
        }

        public override void ShowAccountDetails()
        {
            base.ShowAccountDetails();
            Console.WriteLine($"Interest Rate: {InterestRate}%");
        }

        public override void CalculateInterest()
        {
            decimal interest = Balance * InterestRate / 100;
            Console.WriteLine($"Calculated Interest: {interest}");
        }
    }
}
