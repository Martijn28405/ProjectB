﻿
public class AccountMenu
{
    public static void Start()
    {
        Console.CursorVisible = false;

        string prompt = @"

                                    _     __  __                  
     /\                            | |   |  \/  |                 
    /  \   ___ ___ ___  _   _ _ __ | |_  | \  / | ___ _ __  _   _ 
   / /\ \ / __/ __/ _ \| | | | '_ \| __| | |\/| |/ _ \ '_ \| | | |
  / ____ \ (_| (_| (_) | |_| | | | | |_  | |  | |  __/ | | | |_| |
 /_/    \_\___\___\___/ \__,_|_| |_|\__| |_|  |_|\___|_| |_|\__,_|
                                                                  
                                                                  

                                                                                                                                
                                                                                                                                
                                                                                                                                
";
        string[] options = { "View Movies Per Week", "View Movie Information", "View Catering", "Buy Snacks", "Back to Main Menu", "Log Out", "Exit App", "Manage Shopping Cart" };
        Menu accountmenu = new Menu(prompt, options);
        int SelectedIndex = accountmenu.Run();
        switch (SelectedIndex)
        {
            case 0:
                MoviesLogic showmovies = new MoviesLogic();
                showmovies.ShowMovies();
                Start();
                break;
            case 1:
                MoviesLogic movieInformation = new MoviesLogic();
                movieInformation.MovieInformation();
                break;
            case 2:
                SnacksLogic viewsnacks = new SnacksLogic();
                viewsnacks.ShowSnacks();
                Start();
                break;
            case 3:
                SnacksLogic buysnacks = new SnacksLogic();
                buysnacks.BuySnacks();
                break;
            case 4:
                Program.Main();
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
            case 7:
                ManageShoppingCart.Start();
                break;

        }

    }
}