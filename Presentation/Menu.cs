using System.Xml.XPath;

static class Menu
{

    //This shows the menu. You can call back to this method to show the menu again
    //after another presentation method is completed.
    //You could edit this to show different menus depending on the user's role
    static public void Start()
    {
        Console.WriteLine("Welcome bij:");
        string text = @"
 ___  ___  _______  _________        ________  ___  ________  ________  ________  ________  ________  ________      ___  _______      
|\  \|\  \|\  ___ \|\___   ___\     |\   __  \|\  \|\   __  \|\   ____\|\   ____\|\   __  \|\   __  \|\   __  \    |\  \|\  ___ \     
\ \  \\\  \ \   __/\|___ \  \_|     \ \  \|\ /\ \  \ \  \|\  \ \  \___|\ \  \___|\ \  \|\  \ \  \|\  \ \  \|\  \   \ \  \ \   __/|    
 \ \   __  \ \  \_|/__  \ \  \       \ \   __  \ \  \ \  \\\  \ \_____  \ \  \    \ \  \\\  \ \  \\\  \ \   ____\__ \ \  \ \  \_|/__  
  \ \  \ \  \ \  \_|\ \  \ \  \       \ \  \|\  \ \  \ \  \\\  \|____|\  \ \  \____\ \  \\\  \ \  \\\  \ \  \___|\  \\_\  \ \  \_|\ \ 
   \ \__\ \__\ \_______\  \ \__\       \ \_______\ \__\ \_______\____\_\  \ \_______\ \_______\ \_______\ \__\  \ \________\ \_______\
    \|__|\|__|\|_______|   \|__|        \|_______|\|__|\|_______|\_________\|_______|\|_______|\|_______|\|__|   \|________|\|_______|
                                                                \|_________|                                                          
                                                                                                                                      
                                                                                                                                      
";
        Console.WriteLine(text);
        Console.WriteLine("Wij zijn gevestigd bij Wijnhaven 107, 3011 WN in Rotterdam");
        Console.WriteLine("Met het openbaar vervoer. Neem dan vanaf Rotterdam Centraal Station metrolijn D richting De Akkers of E richting Slinge. ");
        Console.WriteLine("Stap uit bij metrostation Beurs en loop 400 meter richting de Kamer van Koophandel");
        Console.WriteLine("langs het water richting het zuiden."); ;
        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------");

        while (true)
        {
            Console.WriteLine("Enter [1] too login");
            Console.WriteLine("Enter [2] Login as Manager");
            Console.WriteLine("Enter [3] Login as Co-Worker");
            Console.WriteLine("Enter [4] add an account");
            Console.WriteLine("Enter [5] add an movie");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    UserLogin.Start();
                    break;
                case "2":
                    ManagerMenu.Start();
                    break;
                case "3":
                    Co_Worker_menu.Start();
                    break;
                case "4":
                    AccountsLogic login = new AccountsLogic();
                    login.CreateAccount();
                    break;
                case "5":
                    MoviesLogic addMovie = new MoviesLogic();
                    addMovie.CreateMovie();
                    break;
                default:
                    Console.WriteLine("Unknown input registerd");
                    break;
            }
        }
    }
}
