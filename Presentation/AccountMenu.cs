public class AccountMenu
{
    public static void Start()
    {

        string prompt = "Account Menu";
        string[] options = { "View Movies", "View Catering",  "Back to Main Menu", "Exit Code" };
        Menu accountmenu = new Menu(prompt, options);
        int SelectedIndex = accountmenu.Run();
        switch (SelectedIndex)
        {
            case 0:
                MoviesLogic showmovies = new MoviesLogic();
                showmovies.ShowMovies();
                break;
            case 1:
                SnacksLogic viewsnacks = new SnacksLogic();
                viewsnacks.ShowSnacks();
                break;
            case 2:
                Program.Main();
                break;
            case 3:
                Console.WriteLine("press any key to exit the app");
                Console.ReadKey(true);
                Environment.Exit(0);
                break;
        }

    }
}