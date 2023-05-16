using System.ComponentModel.Design;

public class ManagerLogin
{
    public static string Manager_Email = null;
    static private AccountsLogic _accountsLogic = new AccountsLogic();


    public static void Start()
    {
        Console.CursorVisible = false;
        string prompt = @"

  __  __                                     _                 _       
 |  \/  |                                   | |               (_)      
 | \  / | __ _ _ __   __ _  __ _  ___ _ __  | |     ___   __ _ _ _ __  
 | |\/| |/ _` | '_ \ / _` |/ _` |/ _ \ '__| | |    / _ \ / _` | | '_ \ 
 | |  | | (_| | | | | (_| | (_| |  __/ |    | |___| (_) | (_| | | | | |
 |_|  |_|\__,_|_| |_|\__,_|\__, |\___|_|    |______\___/ \__, |_|_| |_|
                            __/ |                         __/ |        
                           |___/                         |___/         
  

 
          
                                                                                                           
";

        string[] options = { "Login", "Add Account", "Back to Main Menu" };
        Menu loginmenu = new Menu(prompt, options);
        int SelectedIndex = loginmenu.Run();
        switch (SelectedIndex)
        {
            case 0:
                if (Manager_Email == null)
                {
                    Console.WriteLine("Welcome to the login page");
                    Console.WriteLine("Please enter your email address:");
                    string email = Console.ReadLine();
                    Console.WriteLine("Please enter your password:");
                    string password = Console.ReadLine();
                    AccountModel acc = _accountsLogic.CheckLogin(email, password);
                    if (acc != null && acc.AccountType == "Manager")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Login Successful");
                        Console.ResetColor();
                        Console.WriteLine("Welcome back " + acc.FullName);
                        Console.WriteLine("Your e-mail is " + acc.EmailAddress);
                        Manager_Email = acc.EmailAddress;
                        Console.WriteLine("Press any key to continue to the Menu");
                        Console.ReadKey(true);
                        ManagerMenu.Start();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Login Failed");
                        Console.ResetColor();
                        Console.WriteLine("No account found with that email and password or you are not allowed to login here with those details.");
                        Console.WriteLine("Press any key to return to the login screen");
                        Console.ReadKey(true);
                        Start();
                    }
                }
                else
                {
                    ManagerMenu.Start();
                }

                break;
            case 1:
                _accountsLogic.CreateAccount("Manager");
                break;
            case 2:
                Program.Main();
                break;
        }
    }
}