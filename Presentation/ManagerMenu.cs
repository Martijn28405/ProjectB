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
        string[] options = {"Add Movie", "Add Snack", "View Movies", "Back to Main Menu", "Exit App" };
        Menu managermenu = new Menu(prompt, options);
        int SelectedIndex = managermenu.Run();
        switch (SelectedIndex)
        {
            case 0:
                MoviesLogic addmovie = new MoviesLogic();
                addmovie.AddMovie();
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
                Console.WriteLine("press any key to exit the app");
                Console.ReadKey(true);
                Environment.Exit(0);
                break;
        }
    }
}
