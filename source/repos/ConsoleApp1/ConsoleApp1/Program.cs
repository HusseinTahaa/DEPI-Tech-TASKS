class Bank
{
    const string BankCode = "BNK001";
    readonly DateTime CreatedDate;
    private int accountNumber;
    private string fullName;
    private string nationalID;
    private string phoneNumber;
    private string address;
    private decimal balance;
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

    public decimal Balance
    {
        get { return balance; }
        set
        {

            if (balance >= 0)
                balance = value;

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


    public Bank()
    {
        accountNumber = 0;
        fullName = "hussein taha";
        address = "N/a";
        balance = 0;
        nationalID = "1234567891011";
        phoneNumber = "01026573976";
        CreatedDate = DateTime.Now;

    }

    public Bank(string fullName, string nationalID, string phoneNumber, string address, decimal balance)
    {
        CreatedDate = DateTime.Now;
        FullName = fullName;
        NationalID = nationalID;
        PhoneNumber = phoneNumber;
        Address = address;
        Balance = balance;
    }

    public Bank(string fullName, string nationalID, string phoneNumber, string address)
       : this(fullName, nationalID, phoneNumber, address, 0)
    {
    }

    public void ShowAccountDetails()
    {
        Console.WriteLine("----- Account Details -----");
        Console.WriteLine($"Bank Code   : {BankCode}");
        Console.WriteLine($"Name        : {FullName}");
        Console.WriteLine($"National ID : {NationalID}");
        Console.WriteLine($"Phone       : {PhoneNumber}");
        Console.WriteLine($"Address     : {Address}");
        Console.WriteLine($"Balance     : {Balance:$}");
        Console.WriteLine($"Created On  : {CreatedDate}");
        Console.WriteLine();
    }





}




class Program
{
    static void Main()
    {
        {

            Bank account1 = new Bank(
                "Hussein Taha",
                "12345678901234",
                "01012345678",
                "Cairo",
                100000
            );


            Bank account2 = new Bank(
                "Sara Ali",
                "98765432109876",
                "01123456789",
                "Alexandria"
            );

            account1.ShowAccountDetails();
            account2.ShowAccountDetails();
        }





    }
}