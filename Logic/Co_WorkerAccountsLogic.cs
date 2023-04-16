﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


//This class is not static so later on we can use inheritance and interfaces
class Co_WorkerAccountsLogic
{
    private JsonAccessor<Co_WorkerAccountModel> _accessor;
    private List<Co_WorkerAccountModel> _accounts;

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself
    static public Co_WorkerAccountModel? CurrentAccount { get; private set; }

    public Co_WorkerAccountsLogic()
    {
        _accessor = new JsonAccessor<Co_WorkerAccountModel>(@"DataSources/co_workers.json");
        _accounts = _accessor.LoadAll();
    }

    public void CreateAccount()
    {
        Co_WorkerAccountsLogic redoLogin = new Co_WorkerAccountsLogic();
        Console.WriteLine("Full name:(Must contain a space)");
        string fullName = Console.ReadLine();

        Console.WriteLine("E-mailadress:(Must contain an @)");
        string emailAddress = Console.ReadLine();

        Console.WriteLine("Password:(min 8 characters and must contain atleast 1 number, 1 upper case and 1 character.)");
        string password = Console.ReadLine();
        string passwordNum = "1234567890";
        string passwordUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string passwordCharacters = "!@#$%^&*()_+";

        bool fullNameCheck = false;
        bool emailAddressCheck = false;
        bool passwordCheck = false;
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

        if (fullName.Contains(" ") && emailAddress.Contains("@") && password.Length >= 8 &&
                    containsNumber == true && containsUpper == true && containsCharacter == true)
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
            Co_WorkerAccountModel acc = new Co_WorkerAccountModel(emailAddress, password, fullName);
            UpdateList(acc);
            Console.WriteLine("Your account has been succesfully created!");
        }
    }

    public void UpdateList(Co_WorkerAccountModel acc)
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

    public Co_WorkerAccountModel? GetById(int id)
    {
        return _accounts.Find(account => account.Id == id);
    }

    public Co_WorkerAccountModel? CheckLogin(string email, string password)
    {
        if (email == null || password == null)
        {
            return null;
        }
        CurrentAccount = _accounts.Find(account => account.EmailAddress == email && account.Password == password);
        return CurrentAccount;
    }
}




