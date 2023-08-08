static class GuestMenu
{
    public static string Guest_Email = null;
    public static void Start()
    {
        Console.CursorVisible = false;
        string prompt = (@"

   _____                 _     __  __                  
  / ____|               | |   |  \/  |                 
 | |  __ _   _  ___  ___| |_  | \  / | ___ _ __  _   _ 
 | | |_ | | | |/ _ \/ __| __| | |\/| |/ _ \ '_ \| | | |
 | |__| | |_| |  __/\__ \ |_  | |  | |  __/ | | | |_| |
  \_____|\__,_|\___||___/\__| |_|  |_|\___|_| |_|\__,_|                                                              
        ");
        string[] options = { "Show Movies/Make a Reservation", "View Catering", "View Movie Information", "Back to Main Menu" };
        Menu guestmenu = new Menu(prompt, options);
        int SelectedIndex = guestmenu.Run();

        switch (SelectedIndex)
        {
            case 0:
                Console.WriteLine("Enter your e-mail (we will send you a confirmation here):\n");
                AccountsLogic logic = new AccountsLogic();
                Guest_Email = logic.CreateEmail();
                Console.WriteLine();
                LogicBase showMovies = new LogicBase();
                showMovies.ShowMoviesBase(false, false, true);
                showMovies.SortMoviesGenreBase(false, false, true);
                showMovies.SortMoviesAgeBase(false, false, true);
                showMovies.SelectMovieBase(false, true);
                break;
            case 1:
                LogicBase showSnacks = new LogicBase();
                showSnacks.ShowSnacksBase(false, false, true);
                break;
            case 2:
                LogicBase showInformation = new LogicBase();
                showInformation.MovieInformation(false, true);
                break;
            case 3:
                Program.Main();
                break;
        }

    }
}