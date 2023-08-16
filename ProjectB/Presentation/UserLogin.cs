using System.ComponentModel.Design;

public class UserLogin
{
    public static string User_Email = null;
    public static string User_Name = null;
    public static string Account_Type = null;
    static private AccountsLogic accountsLogic = new AccountsLogic();


    public static void Start()
    {
        Console.CursorVisible = false;
        string prompt = @"


  _    _                 _                 _       
 | |  | |               | |               (_)      
 | |  | |___  ___ _ __  | |     ___   __ _ _ _ __  
 | |  | / __|/ _ \ '__| | |    / _ \ / _` | | '_ \ 
 | |__| \__ \  __/ |    | |___| (_) | (_| | | | | |
  \____/|___/\___|_|    |______\___/ \__, |_|_| |_|
                                      __/ |        
                                     |___/         
                                                                                                                     
                                                                                                         
";
        string[] options = { "Login", "Back to Main Menu" };
        Menu loginmenu = new Menu(prompt, options);
        int SelectedIndex = loginmenu.Run();
        switch (SelectedIndex)
        {
            case 0:
                if (User_Email == null)
                {
                    Console.WriteLine("Welcome to the login page");
                    Console.WriteLine("Please enter your email address:");
                    string email = Console.ReadLine();
                    Console.WriteLine("Please enter your password:");
                    string password = Console.ReadLine();
                    AccountModel acc = accountsLogic.CheckLogin(email, password);
                    if (acc != null && acc.AccountType == "User")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Login Successful");
                        Console.ResetColor();
                        Console.WriteLine("Welcome back " + acc.FullName);
                        Console.WriteLine("Your e-mail is " + acc.EmailAddress);
                        User_Email = acc.EmailAddress;
                        User_Name = acc.FullName;
                        Account_Type = acc.AccountType;
                        Console.WriteLine("Press any key to continue to the Menu");
                        Console.ReadKey(true);
                        AccountMenu.Start();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Login Failed");
                        Console.ResetColor();
                        Console.WriteLine("No account found with that email and/or password or you are not allowed to login here with those details.");
                        Console.WriteLine("Press any key to return to the login screen");
                        Console.ReadKey(true);
                        Start();
                    }
                }

                else
                {
                    AccountMenu.Start();
                    
                }

                break;
            case 1:
                Program.Main();
                break;
        }
    }
}