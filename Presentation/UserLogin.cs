using System.ComponentModel.Design;

public class UserLogin
{
    public static string user_email = null;
    static private AccountsLogic accountsLogic = new AccountsLogic("accounts.json");


    public static void Start()
    {
        Console.CursorVisible = false;
        string prompt = @"

 ___  ___  ________  _______   ________          ___       ________  ________  ___  ________        
|\  \|\  \|\   ____\|\  ___ \ |\   __  \        |\  \     |\   __  \|\   ____\|\  \|\   ___  \     
\ \  \\\  \ \  \___|\ \   __/|\ \  \|\  \       \ \  \    \ \  \|\  \ \  \___|\ \  \ \  \\ \  \      
 \ \  \\\  \ \_____  \ \  \_|/_\ \   _  _\       \ \  \    \ \  \\\  \ \  \  __\ \  \ \  \\ \  \      
  \ \  \\\  \|____|\  \ \  \_|\ \ \  \\  \|       \ \  \____\ \  \\\  \ \  \|\  \ \  \ \  \\ \  \     
   \ \_______\____\_\  \ \_______\ \__\\ _\        \ \_______\ \_______\ \_______\ \__\ \__\\ \__\    
    \|_______|\_________\|_______|\|__|\|__|        \|_______|\|_______|\|_______|\|__|\|__| \|__|    
             \|_________|                                                                                                                         
                                                                                                         
";
        string[] options = { "Login", "Back to Main Menu" };
        Menu loginmenu = new Menu(prompt, options);
        int SelectedIndex = loginmenu.Run();
        switch (SelectedIndex)
        {
            case 0:
                if (user_email == null)
                {
                    Console.WriteLine("Welcome to the login page");
                    Console.WriteLine("Please enter your email address:");
                    string email = Console.ReadLine();
                    Console.WriteLine("Please enter your password:");
                    string password = Console.ReadLine();
                    AccountModel account = accountsLogic.CheckLogin(email, password);
                    if (account != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Login Successful");
                        Console.ResetColor();
                        Console.WriteLine("Welcome back " + account.FullName);
                        Console.WriteLine("Your e-mail is " + account.EmailAddress);
                        user_email = account.EmailAddress;
                        Console.WriteLine("Press any key to continue to the Menu");
                        Console.ReadKey(true);
                        AccountMenu.Start();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Login Failed");
                        Console.ResetColor();
                        Console.WriteLine("No account found with that email and password");
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