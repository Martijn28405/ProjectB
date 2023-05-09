public class CoWorkerMenu
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
        string[] options = { "Show Movies", "Show Snacks", "Show Reservations", "Log Out", "Back to Main Menu", "Exit App" };
        Menu co_workermenu = new Menu(prompt, options);
        int SelectedIndex = co_workermenu.Run();
        switch (SelectedIndex)
        {
            case 0:
                MoviesLogic showmoviesworker = new MoviesLogic();
                showmoviesworker.ShowMoviesWorker();
                break;
            case 1:
                SnacksLogic viewsnacks = new SnacksLogic();
                viewsnacks.ShowSnacksWorker();
                break;
            case 2:
                ReservationsLogic showreservations = new ReservationsLogic();
                showreservations.ShowReservations();
                break;
            case 3:
                Console.WriteLine("Press any key to confirm");
                Console.ReadKey(true);
                CoWorkerLogin.Co_WorkerEmail = default;
                Program.Main();
                break;
            case 4:
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
