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
        _accessor = new JsonAccessor<AccountModel>(@"DataSources/accounts.json");
        _accounts = _accessor.LoadAll();
    }

public void CreateAccount()
    {
        AccountsLogic redoLogin = new AccountsLogic();
        Console.WriteLine("Full name:(Must contain a space)");
        string fullName = Console.ReadLine();

        Console.WriteLine("E-mailadress:(Must contain an @)");
        string emailAddress = Console.ReadLine();

        Console.WriteLine("Password:(8-14 characters and must contain atleast 1 number.)");
        string password = Console.ReadLine();
        string passwordNum = "1234567890";

        bool fullNameCheck = false;
        bool emailAddressCheck = false;
        bool passwordCheck = false;
        bool containsNumber = false;

        foreach (char num in passwordNum)
        {
            if (char.IsDigit(num))
            {
                containsNumber = true;
            }

        }

        if (fullName.Contains(" ") && emailAddress.Contains("@") &&
                    containsNumber == true && password.Length >= 8 && password.Length <= 14)
        {
            fullNameCheck = true;
            emailAddressCheck = true;
            passwordCheck = true;
        }
        else
        {
            System.Console.WriteLine("Invalid input");
            redoLogin.CreateAccount();
        }
        if (fullNameCheck == true && emailAddressCheck == true && passwordCheck == true)
        {
            AccountModel acc = new AccountModel(emailAddress, password, fullName);
            UpdateList(acc);
            Console.WriteLine("Your account has been succesfully created!");
        }
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
            acc.Id = _accounts.Max(account => account.Id) + 1;
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
        // "i" veranderen naar account om de code leesbaarder te maken (dit kan op meerdere punten toegepast worden)
        CurrentAccount = _accounts.Find(account => account.EmailAddress == email && account.Password == password);
        return CurrentAccount;
    }
}




