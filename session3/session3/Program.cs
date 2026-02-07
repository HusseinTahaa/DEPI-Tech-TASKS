namespace session3
{
    public class BankAccount
    {
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public BankAccount(int accountNumber, decimal balance)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public virtual void ShowAccountDetails()
        {
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Balance: {Balance}");
        }

        public virtual void CalculateInterest()
        {
            Console.WriteLine("No interest calculation for base account.");
        }
    }

    public class SavingAccount : BankAccount
    {
        public decimal InterestRate { get; set; }

        public SavingAccount(int accountNumber, decimal balance, decimal interestRate)
            : base(accountNumber, balance)
        {
            InterestRate = interestRate;
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


    public class CurrentAccount : BankAccount
    {
        public decimal OverdraftLimit { get; set; }

        public CurrentAccount(int accountNumber, decimal balance, decimal overdraftLimit)
            : base(accountNumber, balance)
        {
            OverdraftLimit = overdraftLimit;
        }

        public override void ShowAccountDetails()
        {
            base.ShowAccountDetails();
            Console.WriteLine($"Overdraft Limit: {OverdraftLimit}");
        }

        public override void CalculateInterest()
        {
            Console.WriteLine("Current account does not earn interest.");
        }
    }

    internal class Program
    {
        static void Main()
        {
            SavingAccount saving = new SavingAccount(101, 5000m, 5m);
            CurrentAccount current = new CurrentAccount(202, 3000m, 2000m);

            List<BankAccount> accounts = new List<BankAccount>();
            accounts.Add(saving);
            accounts.Add(current);

            foreach (BankAccount account in accounts)
            {
                Console.WriteLine("================");
                account.ShowAccountDetails();
                account.CalculateInterest();
                Console.WriteLine("================");
            }
        }
    }

}