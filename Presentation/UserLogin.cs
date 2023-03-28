using System.ComponentModel.Design;

public class UserLogin
{
    static private AccountsLogic accountsLogic = new AccountsLogic();


    public static void Start()
    {
        string prompt = @"

 ___  ___  ________  _______   ________          ___       ________  ________  ___  ________           ________  ________  ________  _______      
|\  \|\  \|\   ____\|\  ___ \ |\   __  \        |\  \     |\   __  \|\   ____\|\  \|\   ___  \        |\   __  \|\   __  \|\   ____\|\  ___ \     
\ \  \\\  \ \  \___|\ \   __/|\ \  \|\  \       \ \  \    \ \  \|\  \ \  \___|\ \  \ \  \\ \  \       \ \  \|\  \ \  \|\  \ \  \___|\ \   __/|    
 \ \  \\\  \ \_____  \ \  \_|/_\ \   _  _\       \ \  \    \ \  \\\  \ \  \  __\ \  \ \  \\ \  \       \ \   ____\ \   __  \ \  \  __\ \  \_|/__  
  \ \  \\\  \|____|\  \ \  \_|\ \ \  \\  \|       \ \  \____\ \  \\\  \ \  \|\  \ \  \ \  \\ \  \       \ \  \___|\ \  \ \  \ \  \|\  \ \  \_|\ \ 
   \ \_______\____\_\  \ \_______\ \__\\ _\        \ \_______\ \_______\ \_______\ \__\ \__\\ \__\       \ \__\    \ \__\ \__\ \_______\ \_______\
    \|_______|\_________\|_______|\|__|\|__|        \|_______|\|_______|\|_______|\|__|\|__| \|__|        \|__|     \|__|\|__|\|_______|\|_______|
             \|_________|                                                                                                                         
                                                                                                                                                  
                                                                                                                                                  
   
                                                                                                            
                                                                                                            
                                                                                                            
";
        string[] options = { "Login" };
        Menu loginmenu = new Menu(prompt, options);
        int SelectedIndex = loginmenu.Run();
        switch (SelectedIndex)
        {
            case 0:
                if (Program.Email == null)
                {
                    Console.WriteLine("Welcome to the login page");
                    Console.WriteLine("Please enter your email address:");
                    string email = Console.ReadLine();
                    Console.WriteLine("Please enter your password:");
                    string password = Console.ReadLine();
                    AccountModel acc = accountsLogic.CheckLogin(email, password);
                    if (acc != null)
                    {
                        Console.WriteLine("Welcome back " + acc.FullName);
                        Console.WriteLine("Your e-mail is " + acc.EmailAddress);
                        Program.FullName = acc.FullName;
                        Program.Email = acc.EmailAddress;
                        Program.Password = acc.Password;
                        Console.WriteLine("Press any key to continue to the Menu");
                        Console.ReadKey(true);
                        AccountMenu.Start();
                    }
                    else
                    {
                        Console.WriteLine("No account found with that email and password");
                        Console.WriteLine("Press any key to return to the login screen");
                        Console.ReadKey(true);

                    }

                }

                else if (Program.Email != null)
            {
                Console.WriteLine("Welcome back " + Program.FullName);
                AccountMenu.Start();
            }

                break;
        }      
        }
    }