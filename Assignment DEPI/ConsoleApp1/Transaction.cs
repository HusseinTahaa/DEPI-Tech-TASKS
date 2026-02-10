using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Transaction
    {
        public DateTime Date { get; }
        public string Type { get; }
        public decimal Amount { get; }

        public Transaction(string type, decimal amount)
        {
            Date = DateTime.Now;
            Type = type;
            Amount = amount;
        }
    }

}
