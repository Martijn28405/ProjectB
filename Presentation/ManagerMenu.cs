using System.Diagnostics;
using System.Xml.XPath;

public class ManagerMenu
{

    // This code wil only be excuted if the ManagerMenu called.
    static public void Start()
    {
        Console.CursorVisible = false;
        string prompt = @"

                                                                                          

 _____ ______   ________  ________   ________  ________  _______   ________          _____ ______   _______   ________   ___  ___     
|\   _ \  _   \|\   __  \|\   ___  \|\   __  \|\   ____\|\  ___ \ |\   __  \        |\   _ \  _   \|\  ___ \ |\   ___  \|\  \|\  \    
\ \  \\\__\ \  \ \  \|\  \ \  \\ \  \ \  \|\  \ \  \___|\ \   __/|\ \  \|\  \       \ \  \\\__\ \  \ \   __/|\ \  \\ \  \ \  \\\  \   
 \ \  \\|__| \  \ \   __  \ \  \\ \  \ \   __  \ \  \  __\ \  \_|/_\ \   _  _\       \ \  \\|__| \  \ \  \_|/_\ \  \\ \  \ \  \\\  \  
  \ \  \    \ \  \ \  \ \  \ \  \\ \  \ \  \ \  \ \  \|\  \ \  \_|\ \ \  \\  \|       \ \  \    \ \  \ \  \_|\ \ \  \\ \  \ \  \\\  \ 
   \ \__\    \ \__\ \__\ \__\ \__\\ \__\ \__\ \__\ \_______\ \_______\ \__\\ _\        \ \__\    \ \__\ \_______\ \__\\ \__\ \_______\
    \|__|     \|__|\|__|\|__|\|__| \|__|\|__|\|__|\|_______|\|_______|\|__|\|__|        \|__|     \|__|\|_______|\|__| \|__|\|_______|
                                                                                                                                      
                                                                                                                                      
                                                                                                                                      
                                                               
                                                                                                                               
";
        
   
        
        
        string[] options = {"Movie Management", "Add Snack", "View Movies", "Back to Main Menu", "Log Out", "Exit App" };
        Menu managermenu = new Menu(prompt, options);
        int SelectedIndex = managermenu.Run();
        switch (SelectedIndex)
        {
            case 0:
                MoviesLogic manageMovies = new MoviesLogic();
                manageMovies.ManageMovies();
                break;
            case 1:
                SnacksLogic addsnack = new SnacksLogic();
                addsnack.AddSnacks();
                break;
            case 2:
                MoviesLogic showmoviesworker = new MoviesLogic();
                showmoviesworker.ShowMoviesWorker();
                break;
            case 3:
                Program.Main();
                break;
            case 4:
                Program.Manager_Email = default;
                Program.Manager_Password = default;
                Program.Manager_FullName = default;
                Program.Main();
                break;
            case 5:
                Console.WriteLine("press any key to exit the app");
                Console.ReadKey(true);
                Environment.Exit(0);
                break;
        }
    }
}
