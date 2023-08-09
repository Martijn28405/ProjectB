public class LogicBase
{
    private JsonAccessor<SnackModel> _productAccesor;
    private JsonAccessor<MovieModel> _accesor;
    protected List<MovieModel> movies;
    public List<SnackModel> snacks;
    public static string? SelectedMovie = null;
    public static int duration;
    public static DateTime startTimeInput;
    public LogicBase()
    {
        _accesor = new JsonAccessor<MovieModel>(@"DataSources/movies.json");
        movies = _accesor.LoadAll();

        _productAccesor = new JsonAccessor<SnackModel>(@"DataSources/snacks.json");
        snacks = _productAccesor.LoadAll();
    }

    public virtual void ShowMoviesBase(bool isUser, bool isManager, bool isGuest)
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
            ShowMoviesBase(isUser, isManager, isGuest);
            return;
        }

        if (choice == 1)
        {
            int inputWeek = 0;
            Console.WriteLine("Would you like to see:\n[1] Current week\n[2] Next week");
            while (!int.TryParse(Console.ReadLine(), out inputWeek) || (inputWeek != 1 && inputWeek != 2))
            {
                Console.WriteLine("Invalid input. Please enter a valid week number:");
            }
            foreach (var item in movies)
            {
                if (inputWeek == item.Week)
                {
                    Console.WriteLine($"ID: {item.Id}");
                    Console.WriteLine($"Week: {item.Week}");
                    Console.WriteLine($"TITLE: {item.MovieTitle}");
                    Console.WriteLine($"DIRECTOR: {item.Director}");
                    Console.WriteLine("DESCRIPTION:" + item.Information);
                    Console.WriteLine($"GENRE: {item.Genre}");
                    Console.WriteLine($"TARGET AUDIENCE: {item.TargetAudience}");
                    Console.WriteLine($"PLAY TIME: {item.PlayTimeInMinutes}");
                    Console.WriteLine();
                }

            }
            if (isUser)
            {
                SelectMovieBase(true, false); // Call SelectMovie() only for users
            }
            else if (isGuest)
            {
                SelectMovieBase(false, true);
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
        }
        else if (choice == 2)
        {
            SortMoviesGenreBase(isUser, isManager, isGuest);
        }
        else if (choice == 3)
        {
            SortMoviesAgeBase(isUser, isManager, isGuest);
        }
        else
        {
            Console.WriteLine("Invalid input");
            ShowMoviesBase(isUser, isManager, isGuest);
            return;
        }

    }



    public virtual void SortMoviesGenreBase(bool isUser, bool isManager, bool isGuest)
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
            SortMoviesGenreBase(isUser, isManager, isGuest);
        }
        if (inputWeek != 1 && inputWeek != 2)
        {
            Console.WriteLine("Invalid input");
            SortMoviesGenreBase(isUser, isManager, isGuest);
        }
        Console.WriteLine("Which genre?(Comedy,Action,Adventure,Sci-Fi,Crime,Thriller,Fantasy,Family,Drama)");
        string inputGenre = Console.ReadLine();
        // Error handeling nog op:
        if (string.IsNullOrEmpty(inputGenre) || int.TryParse(inputGenre, out _) || inputGenre != "Comedy" && inputGenre != "Action" && inputGenre != "Adventure" && inputGenre != "Sci-Fi" && inputGenre != "Crime" && inputGenre != "Thriller" && inputGenre != "Fantasy" && inputGenre != "Family" && inputGenre != "Drama")
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
            SelectMovieBase(true, false); // Call SelectMovie() only for users
        }
        else if (isGuest)
        {
            SelectMovieBase(false, true);
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
    public virtual void SortMoviesAgeBase(bool isUser, bool isManager, bool isGuest)
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
            SortMoviesAgeBase(isUser, isManager, isGuest);
        }
        if (inputWeek != 1 && inputWeek != 2)
        {
            Console.WriteLine("Invalid input");
            SortMoviesAgeBase(isUser, isManager, isGuest);
        }

        Console.WriteLine("Minimum age?(10, 12, 16)");
        string inputAge = Console.ReadLine();
        int age;
        while (string.IsNullOrEmpty(inputAge) || !int.TryParse(inputAge, out age) || (age != 10 && age != 12 && age != 16))
        {
            Console.WriteLine("Invalid input. Please try again:");
            inputAge = Console.ReadLine();
        }
        bool foundMovies = false;
        foreach (var movie in movies)
        {
            if (inputWeek == movie.Week && inputAge == movie.TargetAudience)
            {
                foundMovies = true;
                Console.WriteLine($"ID: {movie.Id}");
                Console.WriteLine($"Week: {movie.Week}");
                Console.WriteLine($"TITLE: {movie.MovieTitle}");
                Console.WriteLine($"AGE: {movie.TargetAudience}");
                Console.WriteLine($"GENRE: {movie.Genre}");
                Console.WriteLine("INFO:" + movie.Information);
                Console.WriteLine();
            }
        }
        if (!foundMovies)
        {
            Console.WriteLine($"We do not have any movies for the age {age} in week {inputWeek}\n");
        }
        if (isUser)
        {
            SelectMovieBase(true, false);
        }
        else if (isGuest)
        {
            SelectMovieBase(false, true);
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
    public virtual void ShowSnacksBase(bool isUser, bool isManager, bool isGuest)
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
        else if (isGuest)
        {
            Console.WriteLine("Press any key to return to the menu");
            Console.ReadKey(true);
            GuestMenu.Start();
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
    public virtual void SelectMovieBase(bool isUser, bool isGuest)
    {
        // in het menu een mogelijkheid om een movie te kiezen per week.
        // de geselecteerde movie wordt dan doorgegeven aan de zaal.


        int userChoice;
        Console.WriteLine("Do you want to select a movie?");
        Console.WriteLine("[1] Yes\n[2] No");
        while (!int.TryParse(Console.ReadLine(), out userChoice) || (userChoice != 1 && userChoice != 2))
        {
            Console.WriteLine("Invalid input. Please enter a valid week number:");
        }
        if (userChoice == 1)
        {

            // snacks is the list of available snacks.
            // FirstOrDefault() iterates over each element in the list and checks whether the NameFood property of the element matches the snackName entered by the user.
            Console.WriteLine("Enter a movie ID");
            int itemId;
            int minId = movies.Min(movie => movie.Id);
            int maxId = movies.Max(movie => movie.Id);
            while (!int.TryParse(Console.ReadLine(), out itemId) || itemId < minId || itemId > maxId)
            {
                Console.WriteLine("Invalid ID, please try again.");
            }

            MovieModel? movie = movies.FirstOrDefault(movie => movie.Id == itemId);
            if (movie == null)
            {
                Console.WriteLine("Invalid, please try again.");
                SelectMovieBase(isUser, isGuest);
            }

            SelectedMovie = movie.MovieTitle;
            duration = movie.PlayTimeInMinutes;
            Console.WriteLine($"{SelectedMovie} Selected!");
            List<DateTime> startingTimes = new List<DateTime>();
            foreach (var time in movie.StartTime)
            {
                startingTimes.Add(time);
            }

            Console.WriteLine("Which time would you like to reserve?");
            int y = 1;
            foreach (var x in startingTimes)
            {
                Console.WriteLine($"[{y}]. {x}");
                y++;
            }

            int selectedTime;
            while (!int.TryParse(Console.ReadLine(), out selectedTime) || selectedTime < 1 || selectedTime > startingTimes.Count)
            {
                Console.WriteLine("Invalid time selection, please try again.");
            }
            startTimeInput = startingTimes[selectedTime - 1];
            Console.WriteLine($"You selected: {startTimeInput.ToString("HH:mm")}");

            //Let the user choose one of the times and put the selected time in startTimeInput
            // int selectedTime = Int32.Parse(Console.ReadLine());
            // startTimeInput = startingTimes[selectedTime - 1];
            Console.WriteLine("Press any key to select seats");
            Console.ReadKey(true);
            if (itemId <= 6)
            {
                SeatMenu.Start();
            }
            else if (itemId > 6 && itemId <= 12)
            {
                SeatMenu2.Start();
            }
            else if (itemId > 12 && itemId <= 17)
            {
                SeatMenu3.Start();
            }
            else
            {
                Console.WriteLine("invalid input");
            }
        }
        else if (userChoice == 2)
        {
            if (isUser)
            {
                Console.WriteLine("Press any key to return to the Account menu");
                Console.ReadKey(true);
                AccountMenu.Start();
            }
            else if (isGuest)
            {
                Console.WriteLine("Press any key to return to the Guest menu");
                Console.ReadKey(true);
                GuestMenu.Start();
            }
        }
        else if (userChoice.GetType() != typeof(int))
        {
            Console.WriteLine("Invalid input");
            SelectMovieBase(isUser, isGuest);
        }
    }
    public virtual void MovieInformation(bool isUser, bool isGuest)
    {
        Console.WriteLine("Of which movie would you like to receive some information?\n");
        foreach (var movie in movies.OrderBy(movie => movie.Id))
        {
            Console.WriteLine($"{movie.Id}: {movie.MovieTitle}");
        }

        Console.WriteLine("Enter ID:");
        int userInput;
        int maxId = movies.Max(movie => movie.Id);
        while (!int.TryParse(Console.ReadLine(), out userInput) || userInput <= 0 || userInput > maxId)
        {
            Console.WriteLine("Invalid input. Please enter a valid playtime:");
        }
        foreach (MovieModel movie in movies)
        {
            if (userInput == movie.Id)
            {

                MovieInformationOptionsBase(movie);
                if (isGuest)
                {
                    GuestMenu.Start();
                }
                else if (isUser)
                {
                    AccountMenu.Start();
                }
                else
                {
                    CoWorkerMenu.Start();
                }
            }


        }
    }

    public void MovieInformationOptionsBase(MovieModel movie)
    {
        while (true)
        {
            Console.WriteLine(@"
[1] The synopsis of the movie.
[2] The target audience of the movie.
[3] The genres of the movie.
[4] The times at which the movie is playing.
[5] Exit Information Menu");

            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    Console.WriteLine($"Synopsis: {movie.Information}");
                    break;
                case "2":
                    Console.WriteLine($"Target Audience: {movie.TargetAudience}");
                    break;
                case "3":
                    Console.WriteLine($"Genre(s): {movie.Genre}");
                    break;
                case "4":
                    foreach (DateTime time in movie.StartTime)
                    {
                        string dateAndTime = time.ToString("dd-MM-yyyy HH:mm");
                        Console.WriteLine($"Dates and Times: {dateAndTime}");
                    }
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Incorrect input, try again:");
                    break;
            }
        }
    }
}
