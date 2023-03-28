using System.Xml.XPath;


public class Co_Worker_menu
{
    // This code wil only be excuted if the Co-worker called.
    public static void Start()
    {
        Console.CursorVisible = false;
        string prompt = @"

 ________  ________                 ___       __   ________  ________  ___  __    _______   ________          _____ ______   _______   ________   ___  ___     
|\   ____\|\   __  \               |\  \     |\  \|\   __  \|\   __  \|\  \|\  \ |\  ___ \ |\   __  \        |\   _ \  _   \|\  ___ \ |\   ___  \|\  \|\  \    
\ \  \___|\ \  \|\  \  ____________\ \  \    \ \  \ \  \|\  \ \  \|\  \ \  \/  /|\ \   __/|\ \  \|\  \       \ \  \\\__\ \  \ \   __/|\ \  \\ \  \ \  \\\  \   
 \ \  \    \ \  \\\  \|\____________\ \  \  __\ \  \ \  \\\  \ \   _  _\ \   ___  \ \  \_|/_\ \   _  _\       \ \  \\|__| \  \ \  \_|/_\ \  \\ \  \ \  \\\  \  
  \ \  \____\ \  \\\  \|____________|\ \  \|\__\_\  \ \  \\\  \ \  \\  \\ \  \\ \  \ \  \_|\ \ \  \\  \|       \ \  \    \ \  \ \  \_|\ \ \  \\ \  \ \  \\\  \ 
   \ \_______\ \_______\              \ \____________\ \_______\ \__\\ _\\ \__\\ \__\ \_______\ \__\\ _\        \ \__\    \ \__\ \_______\ \__\\ \__\ \_______\
    \|_______|\|_______|               \|____________|\|_______|\|__|\|__|\|__| \|__|\|_______|\|__|\|__|        \|__|     \|__|\|_______|\|__| \|__|\|_______|
                                                                                                                                                               
                                                                                                                                                               
                                                                                                                                                               

                                                                                                                                                                                                                          
";
        string[] options = { "Login", "Add Account", "Back to Main Menu", "Exit App" };
        Menu co_workermenu = new Menu(prompt, options);
        int SelectedIndex = co_workermenu.Run();
        switch (SelectedIndex)
        {
            case 0:
                UserLogin.Start();
                break;
            case 1:
                break;
            case 2:
                Program.Main();
                break;
            case 3:
                Console.WriteLine("press any key to exit the app");
                Console.ReadKey(true);
                Environment.Exit(0);
                break;



            // if (input == "1")
            // {
            //     UserLogin.Start();
            // }
            // else if (input == "2")
            // {
            //     Console.WriteLine("This feature is not yet implemented");
            //     //add account
            // }
            // else
            // {
            //     Console.WriteLine("Invalid input");
            //     Start();
            // }

        }
    }
}
