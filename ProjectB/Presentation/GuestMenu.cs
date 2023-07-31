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
        string[] options = { "Show Movies/Make a Reservation", "Show Catering", "Back to Main Menu" };
        Menu guestmenu = new Menu(prompt, options);
        int SelectedIndex = guestmenu.Run();

        switch (SelectedIndex)
        {
            case 0:
                Console.WriteLine("Enter your e-mail (we will send you a confirmation here");
                string Guest_Email_Input = Console.ReadLine();
                Guest_Email = Guest_Email_Input;
                LogicBase showMovies = new LogicBase();
                showMovies.ShowMoviesBase(true, false);
                showMovies.SortMoviesGenreBase(true, false);
                showMovies.SortMoviesAgeBase(true, false);
                break;
            case 1:
                SnacksLogic showSnacks = new SnacksLogic();
                showSnacks.ShowSnacks();
                break;
            case 2:
                Program.Main();
                break;
        }

    }
}