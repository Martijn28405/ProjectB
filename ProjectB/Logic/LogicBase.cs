public class LogicBase
{
    private JsonAccessor<SnackModel> _productAccesor;
    private JsonAccessor<MovieModel> _accesor;
    protected List<MovieModel> movies;
    public List<SnackModel> snacks;
    public LogicBase()
    {
        _accesor = new JsonAccessor<MovieModel>(@"DataSources/movies.json");
        movies = _accesor.LoadAll();

        _productAccesor = new JsonAccessor<SnackModel>(@"DataSources/snacks.json");
        snacks = _productAccesor.LoadAll();
    }

    public virtual void ShowMoviesBase(bool isUser, bool isManager)
    {
        int choice = 0;
        try
        {
            Console.WriteLine("[1] Show all movies\n[2] Sort movies on genre\n[3] Sort movies on age");
            choice = Convert.ToInt32(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input");
            ShowMoviesBase(isUser, isManager);
            return;
        }

        if (choice == 1)
        {
            int inputWeek = 0;
            try
            {
                Console.WriteLine("Would you like to see:\n[1] Current week\n[2] Next week");
                inputWeek = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input");
                ShowMoviesBase(isUser, isManager);
                return;
            }
            if (inputWeek != 1 && inputWeek != 2)
            {
                Console.WriteLine("Invalid input");
                ShowMoviesBase(isUser, isManager);
                return;
            }
            Console.WriteLine();

            foreach (var item in movies)
            {
                if (inputWeek == item.Week)
                {
                    Console.WriteLine($"ID: {item.Id}");
                    Console.WriteLine($"Week: {item.Week}");
                    Console.WriteLine($"TITLE: {item.MovieTitle}");
                    Console.WriteLine($"GENRE: {item.Genre}");
                    Console.WriteLine("INFO:" + item.Information);
                    Console.WriteLine();
                }

            }
            if (isUser)
            {
                MoviesLogic send = new MoviesLogic();
                send.SelectMovie(); // Call SelectMovie() only for users
            }
            else if (isManager)
            {
                Console.WriteLine("Search for movies by genre completed for manager.");
                Console.WriteLine("Press any key to return to the Main Menu.");
                Console.ReadKey(true);
                ManagerMenu.Start();

            }
            else
            {
                Console.WriteLine("Search for movies by genre completed for co-worker.");
                Console.WriteLine("Press any key to return to the Main Menu.");
                Console.ReadKey(true);
                CoWorkerMenu.Start();

            }

            // SelectMovie();
        }
        else if (choice == 2)
        {
            SortMoviesGenreBase(isUser, isManager);
        }
        // else
        // {
        //     Console.WriteLine("Invalid input");
        //     ShowMovies(isUser);
        // }

        // int userChoice = 0;
        // if (isUser)
        // {
        //     try
        //     {
        //         Console.WriteLine("Do you want to select a movie?\n[1] Yes\n[2] No");
        //         userChoice = Convert.ToInt32(Console.ReadLine());
        //     }
        //     catch (FormatException)
        //     {
        //         Console.WriteLine("Invalid input");
        //         ShowMovies(isUser);
        //     }
        // }

        // if (userChoice == 1)
        // {
        //     if (isUser)
        //     {
        //         MoviesLogic send = new MoviesLogic();
        //         send.SelectMovie(); // Call SelectMovie() only for users
        //     }
        //     else
        //     {
        //         Console.WriteLine("Search for movies by genre completed for co-worker.");
        //         Console.WriteLine("Press any key to return to the Main Menu.");
        //         Console.ReadKey(true);
        //     }

        // }
        // else if (userChoice == 2)
        // {
        //     if (isUser)
        //     {
        //         Console.WriteLine("Press any key to return to the Account menu");
        //         Console.ReadKey(true);
        //         AccountMenu.Start();
        //     }
        //     else
        //     {
        //         Console.WriteLine("Press any key to return to the Co-Worker menu");
        //         Console.ReadKey(true);
        //         CoWorkerMenu.Start();
        //     }
        // }
        // Optie 3 word niet gezien:
        else if (choice == 3)
        {
            SortMoviesAgeBase(isUser, isManager);
        }
        else
        {
            Console.WriteLine("Invalid input");
            ShowMoviesBase(isUser, isManager);
            return;
        }

    }



    public virtual void SortMoviesGenreBase(bool isUser, bool isManager)
    {
        //sort movies on genre
        int inputWeek = 0;
        try
        {
            Console.WriteLine("Current week or next week?\n[1] Current week\n[2] Next week");
            inputWeek = Convert.ToInt32(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input");
            SortMoviesGenreBase(isUser, isManager);
        }
        if (inputWeek != 1 && inputWeek != 2)
        {
            Console.WriteLine("Invalid input");
            SortMoviesGenreBase(isUser, isManager);
        }
        Console.WriteLine("Which genre?(Comedy,Action,Adventure,Sci-Fi,Crime,Thriller,Fantasy,Family,Drama)");
        string inputGenre = Console.ReadLine();
        // Error handeling nog op:
        if (inputGenre != "Comedy" && inputGenre != "Action" && inputGenre != "Adventure" && inputGenre != "Sci-Fi" && inputGenre != "Crime" && inputGenre != "Thriller" && inputGenre != "Fantasy" && inputGenre != "Family" && inputGenre != "Drama")
        {
            Console.WriteLine("Invalid input");
            inputGenre = Console.ReadLine();
        }
        foreach (var movie in movies)
        {
            if (inputWeek == movie.Week && movie.Genre.Contains(inputGenre))
            {
                Console.WriteLine($"ID: {movie.Id}");
                Console.WriteLine($"Week: {movie.Week}");
                Console.WriteLine($"TITLE: {movie.MovieTitle}");
                Console.WriteLine($"GENRE: {movie.Genre}");
                Console.WriteLine("INFO:" + movie.Information);
                Console.WriteLine();
            }

        }
        if (isUser)
        {
            MoviesLogic send = new MoviesLogic();
            send.SelectMovie(); // Call SelectMovie() only for users
        }
        else if (isManager)
        {
            Console.WriteLine("Search for movies by genre completed for manager.");
            Console.WriteLine("Press any key to return to the Main Menu.");
            Console.ReadKey(true);
            ManagerMenu.Start();

        }
        else
        {
            Console.WriteLine("Search for movies by genre completed for co-worker.");
            Console.WriteLine("Press any key to return to the Main Menu.");
            Console.ReadKey(true);
            CoWorkerMenu.Start(); // Uncomment this line if you want to return to the CoWorkerMenu.
        }

    }

    // Andere methods nog toevoegen die co worker, user, manager gebruiken:
    public virtual void SortMoviesAgeBase(bool isUser, bool isManager)
    {
        //sort movies on age
        int inputWeek = 0;
        try
        {
            Console.WriteLine("Current week or next week?\n[1] Current week\n[2] Next week");
            inputWeek = Convert.ToInt32(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input");
            SortMoviesAgeBase(isUser, isManager);
        }
        if (inputWeek != 1 && inputWeek != 2)
        {
            Console.WriteLine("Invalid input");
            SortMoviesAgeBase(isUser, isManager);
        }

        Console.WriteLine("Minimum age?(10, 12, 16)");
        string inputAge = Console.ReadLine();
        int age;
        while (string.IsNullOrEmpty(inputAge) || !int.TryParse(inputAge, out age) || (age != 10 && age != 12 && age != 16))
        {
            Console.WriteLine("Invalid input. Please try again:");
            inputAge = Console.ReadLine();
        }
        foreach (var movie in movies)
        {
            if (inputWeek == movie.Week && inputAge == movie.TargetAudience)
            {
                Console.WriteLine($"ID: {movie.Id}");
                Console.WriteLine($"Week: {movie.Week}");
                Console.WriteLine($"TITLE: {movie.MovieTitle}");
                Console.WriteLine($"GENRE: {movie.Genre}");
                Console.WriteLine("INFO:" + movie.Information);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"We do not have any movies for the age {age} years old in week {inputWeek}\n");
                break;
            }
        }
        if (isUser)
        {
            MoviesLogic send = new MoviesLogic();
            send.SelectMovie();
        }
        else if (isManager)
        {
            Console.WriteLine("Search for movies by age completed for manager.");
            Console.WriteLine("Press any key to return to the Main Menu.");
            Console.ReadKey(true);
            ManagerMenu.Start();

        }
        else
        {

            Console.WriteLine("Search for movies by age completed for co-worker.");
            Console.WriteLine("Press any key to return to the Main Menu.");
            Console.ReadKey(true);
            CoWorkerMenu.Start();

        }

    }
    public virtual void ShowSnacksBase(bool isUser, bool isManager)
    {
        List<SnackModel> food = new List<SnackModel>();
        foreach (var item in snacks)
        {
            Console.WriteLine($"SNACK: {item.NameFood}");
            Console.WriteLine($"PRICE: {item.PriceFood}");
            Console.WriteLine();
        }
        if (isUser)
        {
            Console.WriteLine("Press any key to return to the menu");
            Console.ReadKey(true);
            AccountMenu.Start();

        }
        else if (isManager)
        {
            Console.WriteLine("Press any key to return to the menu");
            Console.ReadKey(true);
            ManagerMenu.Start();
        }
        else
        {
            Console.WriteLine("Press any key to return to the menu");
            Console.ReadKey(true);
            CoWorkerMenu.Start();
        }

    }
}