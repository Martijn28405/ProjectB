static class GuestMenu
{
    public static void Start()
    {
        Console.Clear();
        Console.WriteLine("Welcome bij:");
        System.Console.WriteLine(@"
 ________  ___  ___  _______   ________  _________        _____ ______   _______   ________   ___  ___     
|\   ____\|\  \|\  \|\  ___ \ |\   ____\|\___   ___\     |\   _ \  _   \|\  ___ \ |\   ___  \|\  \|\  \    
\ \  \___|\ \  \\\  \ \   __/|\ \  \___|\|___ \  \_|     \ \  \\\__\ \  \ \   __/|\ \  \\ \  \ \  \\\  \   
 \ \  \  __\ \  \\\  \ \  \_|/_\ \_____  \   \ \  \       \ \  \\|__| \  \ \  \_|/_\ \  \\ \  \ \  \\\  \  
  \ \  \|\  \ \  \\\  \ \  \_|\ \|____|\  \   \ \  \       \ \  \    \ \  \ \  \_|\ \ \  \\ \  \ \  \\\  \ 
   \ \_______\ \_______\ \_______\____\_\  \   \ \__\       \ \__\    \ \__\ \_______\ \__\\ \__\ \_______\
    \|_______|\|_______|\|_______|\_________\   \|__|        \|__|     \|__|\|_______|\|__| \|__|\|_______|
                                 \|_________|                                                              
        ");
        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------");

        while (true)
        {
            System.Console.WriteLine("Enter [1] to show all the movies");
            System.Console.WriteLine("Enter [2] to show all the items in the shop");
            System.Console.WriteLine("Enter [3] to make a reservation");
            System.Console.WriteLine("Enter [4] to go back to the main menu");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    MoviesLogic showMovies = new MoviesLogic();
                    showMovies.ShowMovies();
                    break;
                case "2":
                    SnacksLogic showSnacks = new SnacksLogic();
                    showSnacks.ShowSnacks();
                    break;
                case "3":
                    System.Console.WriteLine("this function is not yet available");
                    //zorg ervoor dat email ook wordt ingevoerd.
                    break;
                case "4":
                    Console.Clear();
                    // Menu.Start();
                    break;
                default:
                    Console.WriteLine("Unknown input registerd");
                    break;
            }
        }
    }
}
