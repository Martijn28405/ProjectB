// Co-worker menu to log in:
public class CoWorkerLogin
{
    public static string Co_WorkerEmail = null;
    private static AccountsLogic _accountsLogic = new AccountsLogic();
    public static void Start()
    {
        Console.CursorVisible = false;
        string prompt = @"


   _____         __          __        _               _                 _       
  / ____|        \ \        / /       | |             | |               (_)      
 | |     ___ _____\ \  /\  / /__  _ __| | _____ _ __  | |     ___   __ _ _ _ __  
 | |    / _ \______\ \/  \/ / _ \| '__| |/ / _ \ '__| | |    / _ \ / _` | | '_ \ 
 | |___| (_) |      \  /\  / (_) | |  |   <  __/ |    | |___| (_) | (_| | | | | |
  \_____\___/        \/  \/ \___/|_|  |_|\_\___|_|    |______\___/ \__, |_|_| |_|
                                                                    __/ |        
                                                                   |___/         

                                                                                                                                                               
                                                                                                                                                               
                                                                                                                                                               


                                                                                                          
";
        // Choices co-worker to choose from:
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

                    if (acc != null && acc.AccountType == "Co-Worker")
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
                        Console.WriteLine("No account found with that email and/or password or you are not allowed to login here with those details.");
                        Console.WriteLine();
                        Console.WriteLine("Warning: sometimes after creating multiple accounts an error occurs, if this is the case please restart your program.");
                        Console.WriteLine();
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
                _accountsLogic.CreateAccount("Co-Worker");
                break;
            case 2:
                Program.Main();
                break;
        }
    }
}
