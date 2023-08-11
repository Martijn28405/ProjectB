using System.Diagnostics;
using System.Xml.XPath;

public class ManagerMenu
{

    // This code wil only be excuted if the ManagerMenu called.
    static public void Start()
    {
        Console.CursorVisible = false;
        string prompt = @"

  __  __                                     __  __                  
 |  \/  |                                   |  \/  |                 
 | \  / | __ _ _ __   __ _  __ _  ___ _ __  | \  / | ___ _ __  _   _ 
 | |\/| |/ _` | '_ \ / _` |/ _` |/ _ \ '__| | |\/| |/ _ \ '_ \| | | |
 | |  | | (_| | | | | (_| | (_| |  __/ |    | |  | |  __/ | | | |_| |
 |_|  |_|\__,_|_| |_|\__,_|\__, |\___|_|    |_|  |_|\___|_| |_|\__,_|
                            __/ |                                    
                           |___/                                     
                                                                                                                                                                                                                                              
";




        string[] options = { "Movie Management", "Snack Management", "View Movies", "View Reservations", "Edit Reservations", "Back to Main Menu", "Log Out", "Exit App" };
        Menu managermenu = new Menu(prompt, options);
        int SelectedIndex = managermenu.Run();
        switch (SelectedIndex)
        {
            case 0:
                MoviesLogic manageMovies = new MoviesLogic();
                manageMovies.ManageMovies();
                break;
            case 1:
                SnacksLogic managesnacks = new SnacksLogic();
                managesnacks.ManageSnacks();
                break;
            case 2:
                LogicBase showMovies = new LogicBase();
                showMovies.ShowMoviesBase(false, true, false);
                showMovies.SortMoviesGenreBase(false, true, false);
                showMovies.SortMoviesAgeBase(false, true, false);
                Start();
                break;
            case 3:
                ReservationsLogic showreservations = new ReservationsLogic();
                showreservations.ShowReservations();
                Console.WriteLine("Press any button to return to the Menu");
                Console.ReadKey(true);
                Start();
                break;
            case 4:
                ReservationsLogic modifyReservations = new ReservationsLogic();
                modifyReservations.modifyReservations();
                break;
            case 5:
                Program.Main();
                break;
            case 6:
                Console.WriteLine("Press any key to confirm");
                Console.ReadKey(true);
                ManagerLogin.Manager_Email = default;
                Program.Main();
                break;
            case 7:
                Console.WriteLine("press any key to exit the app");
                Console.ReadKey(true);
                Environment.Exit(0);
                break;
        }
    }
}
