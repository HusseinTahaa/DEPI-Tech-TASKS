using ConsoleApp1; 
class Program
{
    static void Main()
    {
        Bank bank = new Bank();

        Customer cus = new Customer("Hussein Taha", "12345678910123", 0, "01006863692", "Cairo");
        Customer cus2 = new Customer("Anas Taha", "12345678910123", 0, "01006863692", "Cairo");

        SavingAccount saving = new SavingAccount(5000m, 5m);
        CurrentAccount current = new CurrentAccount(3000m, 2000m);

        bank.Customers.Add(cus);
        bank.Customers.Add(cus2);

        cus.ShowAccountDetails();
        bank.ShowBankReport();
    }
}