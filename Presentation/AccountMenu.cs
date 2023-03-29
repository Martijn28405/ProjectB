public class AccountMenu
{
    public static void Start()
    {
        Console.CursorVisible = false;

        string prompt = @"
 ________  ________  ________  ________  ___  ___  ________   _________        _____ ______   _______   ________   ___  ___     
|\   __  \|\   ____\|\   ____\|\   __  \|\  \|\  \|\   ___  \|\___   ___\     |\   _ \  _   \|\  ___ \ |\   ___  \|\  \|\  \    
\ \  \|\  \ \  \___|\ \  \___|\ \  \|\  \ \  \\\  \ \  \\ \  \|___ \  \_|     \ \  \\\__\ \  \ \   __/|\ \  \\ \  \ \  \\\  \   
 \ \   __  \ \  \    \ \  \    \ \  \\\  \ \  \\\  \ \  \\ \  \   \ \  \       \ \  \\|__| \  \ \  \_|/_\ \  \\ \  \ \  \\\  \  
  \ \  \ \  \ \  \____\ \  \____\ \  \\\  \ \  \\\  \ \  \\ \  \   \ \  \       \ \  \    \ \  \ \  \_|\ \ \  \\ \  \ \  \\\  \ 
   \ \__\ \__\ \_______\ \_______\ \_______\ \_______\ \__\\ \__\   \ \__\       \ \__\    \ \__\ \_______\ \__\\ \__\ \_______\
    \|__|\|__|\|_______|\|_______|\|_______|\|_______|\|__| \|__|    \|__|        \|__|     \|__|\|_______|\|__| \|__|\|_______|
                                                                                                                                
                                                                                                                                
                                                                                                                                
";
        string[] options = { "View Movies", "View Catering", "Buy Snacks", "Back to Main Menu", "Log Out", "Exit App" };
        Menu accountmenu = new Menu(prompt, options);
        int SelectedIndex = accountmenu.Run();
        switch (SelectedIndex)
        {
            case 0:
                MoviesLogic showmovies = new MoviesLogic();
                showmovies.ShowMovies();
                break;
            case 1:
                SnacksLogic viewsnacks = new SnacksLogic();
                viewsnacks.ShowSnacks();
                break;
            case 2:
                SnacksLogic buysnacks = new SnacksLogic();
                buysnacks.BuySnacks();
                break;
            case 3:
                Thread.Sleep(1000);
                Program.Main();
                break;
            case 4:
                Console.WriteLine("Press any key to confirm");
                Console.ReadKey(true);
                Program.FullName = default;
                Program.Email = default;
                Program.Password = default; ;
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