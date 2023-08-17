public class CoWorkerMenu
{
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
        string[] options = { "Show Movies", "Show Snacks", "View Reservations", "Edit Reservations", "Log Out", "Back to Main Menu", "Exit App" };
        Menu co_workermenu = new Menu(prompt, options);
        int SelectedIndex = co_workermenu.Run();
        switch (SelectedIndex)
        {
            case 0:
                LogicBase showmoviesworker = new LogicBase();
                showmoviesworker.ShowMoviesBase(false, false, false);
                showmoviesworker.SortMoviesGenreBase(false, false, false);
                showmoviesworker.SortMoviesAgeBase(false, false, false);
                CoWorkerMenu.Start();
                break;
            case 1:
                LogicBase viewsnacks = new LogicBase();
                viewsnacks.ShowSnacksBase(false, false, false);
                break;
            case 2:
                ReservationsLogic showreservations = new ReservationsLogic();
                showreservations.ShowReservations();
                Console.WriteLine("Press any button to return to the Menu");
                Console.ReadKey(true);
                Start();
                break;
            case 3:
                ReservationsLogic modifyReservations = new ReservationsLogic();
                modifyReservations.modifyReservations();
                break;
            case 4:
                Console.WriteLine("Press any key to confirm");
                Console.ReadKey(true);
                CoWorkerLogin.Co_WorkerEmail = default;
                Program.Main();
                break;
            case 5:
                Program.Main();
                break;
            case 6:
                Console.WriteLine("press any key to exit the app");
                Console.ReadKey(true);
                Environment.Exit(0);
                break;
        }
    }
}
