using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


//This class is not static so later on we can use inheritance and interfaces
class AccountsLogic
{
    private JsonAccessor<AccountModel> _accessor;
    private List<AccountModel> _accounts;

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself
    static public AccountModel? CurrentAccount { get; private set; }

    public AccountsLogic()
    {
        _accessor = new JsonAccessor<AccountModel>("DataSources/accounts.json"); //accounts.json
        _accounts = _accessor.LoadAll();
    }

    public void CreateAccount(string accountType)
    {
        string fullName = CreateFullName();
        string emailAddress = CreateEmail();
        string password = CreatePassword();
        
        AccountModel acc = new AccountModel()
        {
            EmailAddress = emailAddress,
            Password = password,
            FullName = fullName,
            AccountType = accountType
        };

        UpdateList(acc);
        Console.WriteLine("Your account has been succesfully created!");
        Console.WriteLine("Press any key to return to the main menu");
        Console.ReadKey(true);
        Program.Main();

    }
    public string CreateFullName()
    {
        Console.WriteLine("Full name:(Must contain a space)");
        string fullName = Console.ReadLine();

        if (fullName.Contains(" "))
        {
            return fullName;
        }
        System.Console.WriteLine("Invalid input");
        return CreateFullName();
    }

    public string CreateEmail()
    {
        Console.WriteLine("E-mailadress:(Must contain an @)");
        string emailAddress = Console.ReadLine();

        if (emailAddress.Contains("@"))
        {
            return emailAddress;
        }
        System.Console.WriteLine("Invalid input");
        return CreateEmail();
    }

    public string CreatePassword()
    {
        Console.WriteLine("Password:(min 8 characters and must contain at least 1 number, 1 upper case and 1 character.)");
        string password = Console.ReadLine();
        string passwordNum = "1234567890";
        string passwordUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string passwordCharacters = "!@#$%^&*()_+";

        bool containsNumber = false;
        bool containsUpper = false;
        bool containsCharacter = false;

        foreach (char c in password)
        {
            if (passwordNum.Contains(c))
            {
                containsNumber = true;
            }
            if (passwordCharacters.Contains(c))
            {
                containsCharacter = true;
            }
            if (passwordUpper.Contains(c))
            {
                containsUpper = true;
            }
        }

        if (password.Length >= 8 && containsNumber == true && containsUpper == true && containsCharacter == true)
        {
            return password;
        }
        System.Console.WriteLine("Invalid input");
        return CreatePassword();
    }

    public void UpdateList(AccountModel acc)
    {
        // Check if there is already an account with the same id
        // If the account is already in the list grab the index and update the account, else add a new account.
        int index = _accounts.FindIndex(account => account.Id == acc.Id);

        if (index != -1)
        {
            _accounts[index] = acc;
        }
        else
        {
            // Check if there is any account present in the accounts list. 
            acc.Id = _accounts.Any() ? _accounts.Max(account => account.Id) + 1 : 1;
            _accounts.Add(acc);
        }
        _accessor.WriteAll(_accounts);
    }

    public AccountModel GetById(int id)
    {
        return _accounts.Find(account => account.Id == id);
    }

    public AccountModel CheckLogin(string email, string password)
    {
        if (email == null || password == null)
        {
            return null;
        }
        CurrentAccount = _accounts.Find(account => account.EmailAddress == email && account.Password == password);
        return CurrentAccount;
    }
}




