public class Co_WorkerLogin
{
    static private Co_WorkerAccountsLogic coWorkerAccountsLogic = new Co_WorkerAccountsLogic();


    public static void Start()
    {
        Console.CursorVisible = false;
        string prompt = @"


 _____ ______   ________  ________   ________  ________  _______   ________          ___       ________  ________  ___  ________      
|\   _ \  _   \|\   __  \|\   ___  \|\   __  \|\   ____\|\  ___ \ |\   __  \        |\  \     |\   __  \|\   ____\|\  \|\   ___  \    
\ \  \\\__\ \  \ \  \|\  \ \  \\ \  \ \  \|\  \ \  \___|\ \   __/|\ \  \|\  \       \ \  \    \ \  \|\  \ \  \___|\ \  \ \  \\ \  \   
 \ \  \\|__| \  \ \   __  \ \  \\ \  \ \   __  \ \  \  __\ \  \_|/_\ \   _  _\       \ \  \    \ \  \\\  \ \  \  __\ \  \ \  \\ \  \  
  \ \  \    \ \  \ \  \ \  \ \  \\ \  \ \  \ \  \ \  \|\  \ \  \_|\ \ \  \\  \|       \ \  \____\ \  \\\  \ \  \|\  \ \  \ \  \\ \  \ 
   \ \__\    \ \__\ \__\ \__\ \__\\ \__\ \__\ \__\ \_______\ \_______\ \__\\ _\        \ \_______\ \_______\ \_______\ \__\ \__\\ \__\
    \|__|     \|__|\|__|\|__|\|__| \|__|\|__|\|__|\|_______|\|_______|\|__|\|__|        \|_______|\|_______|\|_______|\|__|\|__| \|___                                                                                                           
";
        string[] options = { "Login", "Add Account", "Back to Main Menu" };
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
                    Co_WorkerAccountModel acc = coWorkerAccountsLogic.CheckLogin(email, password);
                    if (acc != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Login Successful");
                        Console.ResetColor();
                        Console.WriteLine("Welcome back " + acc.FullName);
                        Console.WriteLine("Your e-mail is " + acc.EmailAddress);
                        Program.co_worker_fullname = acc.FullName;
                        Program.co_worker_email = acc.EmailAddress;
                        Program.co_worker_password = acc.Password;
                        Console.WriteLine("Press any key to continue to the Menu");
                        Console.ReadKey(true);
                        Co_Worker_menu.Start();
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

                else if (Program.Email != null)
                {
                    Co_Worker_menu.Start();
                }

                break;
            case 1:
                Co_WorkerAccountsLogic add_account = new Co_WorkerAccountsLogic();
                add_account.CreateAccount();
                break;
            case 2:
                Program.Main();
                break;
        }
    }
}