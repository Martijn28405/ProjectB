static class GuestMenu
{
    public static void Start()
    {
        Console.CursorVisible = false;
        string prompt = (@"
 ________  ___  ___  _______   ________  _________        _____ ______   _______   ________   ___  ___     
|\   ____\|\  \|\  \|\  ___ \ |\   ____\|\___   ___\     |\   _ \  _   \|\  ___ \ |\   ___  \|\  \|\  \    
\ \  \___|\ \  \\\  \ \   __/|\ \  \___|\|___ \  \_|     \ \  \\\__\ \  \ \   __/|\ \  \\ \  \ \  \\\  \   
 \ \  \  __\ \  \\\  \ \  \_|/_\ \_____  \   \ \  \       \ \  \\|__| \  \ \  \_|/_\ \  \\ \  \ \  \\\  \  
  \ \  \|\  \ \  \\\  \ \  \_|\ \|____|\  \   \ \  \       \ \  \    \ \  \ \  \_|\ \ \  \\ \  \ \  \\\  \ 
   \ \_______\ \_______\ \_______\____\_\  \   \ \__\       \ \__\    \ \__\ \_______\ \__\\ \__\ \_______\
    \|_______|\|_______|\|_______|\_________\   \|__|        \|__|     \|__|\|_______|\|__| \|__|\|_______|
                                 \|_________|                                                              
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
                    System.Console.WriteLine("this function is not yet available");
                    Thread.Sleep(1000);
                    Start();
                    //zorg ervoor dat email ook wordt ingevoerd.
                    break;
                case 3:
                    Program.Main();
                    break;
            }
        
    }
}