using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
   public class Customer
    {
        DateTime CreatedDate;
     static int count = 0;
        private int accountNumber;
        private string fullName;
        private string nationalID;
        private string phoneNumber;
        private string address;
        private decimal balance;
        public List<Bank> Accounts { get; } = new List<Bank>();
        public decimal Balance {  get; set; }
        public string FullName
        {
            get { return fullName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    Console.WriteLine("Full Name cannot be empty");
                else
                    fullName = value;
            }
        }
        public string NationalID
        {
            get { return nationalID; }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length == 14 && value.All(char.IsDigit))
                    nationalID = value;
                else
                    Console.WriteLine("National ID must be exactly 14 digits");
            }
        }
     
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                if (value == null || value.Length != 11 || !value.StartsWith("01") || !value.All(char.IsDigit))
                { Console.WriteLine("Invalid Number"); }

                phoneNumber = value;

            }


        }
        public string Address
        {
            get { return address; }
            set
            {

                address = value;

            }
        }
        public int ID
        { get; }

        public Customer(string full, string naid, decimal bal, string phone, string addr)
        { 
            FullName = full;
            NationalID = naid;
            balance = bal;
            PhoneNumber = phone;
            Address = addr;
            ID = ++count;
        }
      public  Customer() { ID = ++count;
            CreatedDate = DateTime.Now;
        }

        

    public Customer(decimal bal)
        {
            accountNumber = ++count;
            balance = bal;
            ID = ++count;
        }
        public virtual void CalculateInterest()
        {
            Console.WriteLine("No interest calculation for base account.");
        }
        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid deposit amount");
                return;
            }

            balance += amount;
            Console.WriteLine($"Deposited {amount}. New balance: {balance}");
        }

        public virtual bool Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid withdrawal amount");
                return false;
            }

            if (amount > balance)
            {
                Console.WriteLine("Insufficient balance");
                return false;
            }

            balance -= amount;
            Console.WriteLine($"Withdrawn {amount}. New balance: {balance}");
            return true;
        }

        public decimal GetTotalBalance()
        {
            return Accounts.Sum(a => a.Balance);
        }

        public virtual void ShowAccountDetails()
        {
            Console.WriteLine("----- Account Details -----");
            Console.WriteLine($"ID          : {ID}");
            Console.WriteLine($"Name        : {FullName}");
            Console.WriteLine($"National ID : {NationalID}");
            Console.WriteLine($"Phone       : {PhoneNumber}");
            Console.WriteLine($"Address     : {Address}");
            Console.WriteLine($"Total Balance: {GetTotalBalance()}");
        Console.WriteLine($"Created On  : {CreatedDate}");
            foreach (var acc in Accounts)
            {
                Console.WriteLine($"  Account #{acc.AccountNumber} - Balance: {acc.Balance}");
            }
            Console.WriteLine("-----------------------");
        }
    }
}
