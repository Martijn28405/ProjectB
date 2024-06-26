﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ProjectB.Logic;

public class AccountsLogic
// this file is used to create an account, have the account consist of certain rules and create ID's for accounts.
{
    private JsonAccessor<AccountModel> _accessor;
    private List<AccountModel> _accounts;
    private readonly ValidationsLogic _validationLogic;
    public static AccountModel? CurrentAccount { get; private set; }

    public AccountsLogic()
    {
        _accessor = new JsonAccessor<AccountModel>("DataSources/accounts.json"); //accounts.json
        _accounts = _accessor.LoadAll();
        _validationLogic = new ValidationsLogic();
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

        if (_validationLogic.ValidateName(fullName))
        {
            return fullName;
        }
        Console.WriteLine("Invalid input");
        return CreateFullName();
    }

    public string CreateEmail()
    {
        Console.WriteLine("E-mailadress:(Must contain an @)");
        string emailAddress = Console.ReadLine();

        if (_validationLogic.ValidateEmail(emailAddress))
        {
            return emailAddress;
        }
        Console.WriteLine("Invalid input");
        return CreateEmail();
    }

    public string CreatePassword()
    {
        Console.WriteLine("Password:(min 8 characters and must contain at least 1 number, 1 upper case and 1 character.)");
        string password = Console.ReadLine();
        if (_validationLogic.ValidatePassword(password))
        {
            return password;
        }
        Console.WriteLine("Invalid input");
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
