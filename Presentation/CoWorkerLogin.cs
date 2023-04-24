public class CoWorkerLogin
{
    public static string Co_WorkerEmail = null; 
    private static AccountsLogic _accountsLogic = new AccountsLogic("coworkers.json");


    public static void Start()
    {
        Console.CursorVisible = false;
        string prompt = @"

 ________  ________                 ___       __   ________  ________  ___  __    _______   ________          ___       ________  ________  ___  ________      
|\   ____\|\   __  \               |\  \     |\  \|\   __  \|\   __  \|\  \|\  \ |\  ___ \ |\   __  \        |\  \     |\   __  \|\   ____\|\  \|\   ___  \    
\ \  \___|\ \  \|\  \  ____________\ \  \    \ \  \ \  \|\  \ \  \|\  \ \  \/  /|\ \   __/|\ \  \|\  \       \ \  \    \ \  \|\  \ \  \___|\ \  \ \  \\ \  \   
 \ \  \    \ \  \\\  \|\____________\ \  \  __\ \  \ \  \\\  \ \   _  _\ \   ___  \ \  \_|/_\ \   _  _\       \ \  \    \ \  \\\  \ \  \  __\ \  \ \  \\ \  \  
  \ \  \____\ \  \\\  \|____________|\ \  \|\__\_\  \ \  \\\  \ \  \\  \\ \  \\ \  \ \  \_|\ \ \  \\  \|       \ \  \____\ \  \\\  \ \  \|\  \ \  \ \  \\ \  \ 
   \ \_______\ \_______\              \ \____________\ \_______\ \__\\ _\\ \__\\ \__\ \_______\ \__\\ _\        \ \_______\ \_______\ \_______\ \__\ \__\\ \__\
    \|_______|\|_______|               \|____________|\|_______|\|__|\|__|\|__| \|__|\|_______|\|__|\|__|        \|_______|\|_______|\|_______|\|__|\|__| \|__|
                                                                                                                                                               
                                                                                                                                                               
                                                                                                                                                               


                                                                                                          
";
        string[] options = { "Login", "Add Account", "Back to Main Menu" };
        Menu loginmenu = new Menu(prompt, options);
        int SelectedIndex = loginmenu.Run();
        switch (SelectedIndex)
        {
            case 0:
                if (Co_WorkerEmail == null)
                {
                    Console.WriteLine("Welcome to the login page");
                    Console.WriteLine("Please enter your email address:");
                    string email = Console.ReadLine();
                    Console.WriteLine("Please enter your password:");
                    string password = Console.ReadLine();
                    AccountModel acc = _accountsLogic.CheckLogin(email, password);
                    if (acc != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Login Successful");
                        Console.ResetColor();
                        Console.WriteLine("Welcome back " + acc.FullName);
                        Console.WriteLine("Your e-mail is " + acc.EmailAddress);
                        Co_WorkerEmail = acc.EmailAddress;
                        Console.WriteLine("Press any key to continue to the Menu");
                        Console.ReadKey(true);
                        CoWorkerMenu.Start();
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
                    CoWorkerMenu.Start();
                }

                break;
            case 1:
                _accountsLogic.CreateAccount();
                break;
            case 2:
                Program.Main();
                break;
        }
    }
}