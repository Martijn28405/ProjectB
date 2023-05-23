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
        string[] options = { "Show Movies", "Show Catering", "Make a Reservation", "Back to Main Menu" };
        Menu guestmenu = new Menu(prompt, options);
        int SelectedIndex = guestmenu.Run();

            switch (SelectedIndex)
            {
                case 0:
                    MoviesLogic showMovies = new MoviesLogic();
                    showMovies.ShowMovies();
                    break;
                case 1:
                    SnacksLogic showSnacks = new SnacksLogic();
                    showSnacks.ShowSnacks();
                    break;
                case 2:
                    Console.WriteLine("Enter your e-mail (we will send you a confirmation here");
                    Guest_Email = Console.ReadLine();
                    MoviesLogic showmovies = new MoviesLogic();
                    showmovies.ShowMovies();
                    break;
                case 3:
                    Program.Main();
                    break;
            }
        
    }
}