
public class AccountMenu
{
    public static void Start()
    {
        Console.CursorVisible = false;
        ResetSeats();
        string prompt = @"

                                    _     __  __                  
     /\                            | |   |  \/  |                 
    /  \   ___ ___ ___  _   _ _ __ | |_  | \  / | ___ _ __  _   _ 
   / /\ \ / __/ __/ _ \| | | | '_ \| __| | |\/| |/ _ \ '_ \| | | |
  / ____ \ (_| (_| (_) | |_| | | | | |_  | |  | |  __/ | | | |_| |
 /_/    \_\___\___\___/ \__,_|_| |_|\__| |_|  |_|\___|_| |_|\__,_|
                                                                  
                                                                  

                                                                                                                                
                                                                                                                                
                                                                                                                                
";
        string[] options = { "Make A Reservation/Show Movies", "View Movie Information", "View Catering", "Back to Main Menu", "Manage Shopping Cart", "Log Out", "Exit App" };
        Menu accountmenu = new Menu(prompt, options);
        int SelectedIndex = accountmenu.Run();
        switch (SelectedIndex)
        {
            case 0:
                LogicBase showmovies = new LogicBase();
                showmovies.ShowMoviesBase(true, false, false);
                showmovies.SortMoviesGenreBase(true, false, false);
                showmovies.SortMoviesAgeBase(true, false, false);
                showmovies.SelectMovieBase(true, false);
                break;
            case 1:
                LogicBase showInformation = new LogicBase();
                showInformation.MovieInformation(true, false);
                break;
            case 2:
                LogicBase viewsnacks = new LogicBase();
                viewsnacks.ShowSnacksBase(true, false, false);
                Start();
                break;
            case 3:
                Program.Main();
                break;
            case 4:
                ManageShoppingCart.Start();
                break;
            case 5:
                Console.WriteLine("Press any key to confirm");
                Console.ReadKey(true);
                UserLogin.User_Email = default;
                Program.Main();
                break;
            case 6:
                Console.WriteLine("press any key to exit the app");
                Console.ReadKey(true);
                Environment.Exit(0);
                break;
        }
    }

    public static void ResetSeats()
    {
        SeatMenu.Reset();
        SeatMenu2.Reset();
        SeatMenu3.Reset();
    }
}
