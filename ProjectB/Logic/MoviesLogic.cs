using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
public class MoviesLogic
{
    private JsonAccessor<MovieModel> _accesor;
    public List<MovieModel> movies;
    public static string? SelectedMovie = null;
    public static DateTime startTimeInput;
    public static int duration;
    public MoviesLogic()
    {
        _accesor = new JsonAccessor<MovieModel>(@"DataSources/movies.json");
        movies = _accesor.LoadAll();
    }

    public void AddMovie()
    {
        int id = GetNextAvailableId();
        // checking if there is an available Id that is not used by any existing movie
        // If there is, it will be used. Otherwise, it will get the next available Id.

        //Error handeling voor alle input bij het toevoegen van een film
        int week;
        Console.WriteLine("The week in which the movie will play?");
        Console.WriteLine("[1] Current Week\n[2] Next Week");
        while (!int.TryParse(Console.ReadLine(), out week) || (week != 1 && week != 2))
        {
            Console.WriteLine("Invalid input. Please enter a valid week number:");
        }

        Console.WriteLine("Movie Title:");
        string? movietitle = Console.ReadLine();
        while (string.IsNullOrEmpty(movietitle) || int.TryParse(movietitle, out _))
        {
            Console.WriteLine("Invalid input. Movie Title cannot be empty. Please enter a valid title:");
            movietitle = Console.ReadLine();
        }

        Console.WriteLine("Movie Director:");
        string? director = Console.ReadLine();
        while (string.IsNullOrEmpty(director) || int.TryParse(director, out _))
        {
            Console.WriteLine("Invalid input. Director cannot be empty. Please enter a valid name:");
            director = Console.ReadLine();
        }

        Console.WriteLine("Movie Description:");
        string? description = Console.ReadLine();
        while (string.IsNullOrEmpty(description) || int.TryParse(description, out _))
        {
            Console.WriteLine("Invalid input. Description cannot be empty. Please enter a valid description:");
            description = Console.ReadLine();
        }

        Console.WriteLine("Movie Genres (When mulitple divided by a ',' like this: Action, Adventure, Fantasy):");
        string? genre = Console.ReadLine();
        while (string.IsNullOrEmpty(genre) || int.TryParse(genre, out _))
        {
            Console.WriteLine("Invalid input. Genre cannot be empty. Please enter a valid genre:");
            genre = Console.ReadLine();
        }

        Console.WriteLine("Movie Target Audienc (10, 12, 16):");
        string? targetAudience = Console.ReadLine();
        while (string.IsNullOrEmpty(targetAudience))
        {
            Console.WriteLine("Invalid input. Target audience cannot be empty. Please enter a valid number:");
            targetAudience = Console.ReadLine();
        }

        Console.WriteLine("What is the play time in minutes?");
        int playTime;
        while (!int.TryParse(Console.ReadLine(), out playTime) || playTime <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a valid playtime:");
        }

        Console.WriteLine("Start times:");
        List<DateTime> dateTimes = CreateTime();

        //error handeling voor datetime nog teovoegen

        MovieModel movie = new MovieModel(id, week, movietitle, director, description, genre, targetAudience, playTime, dateTimes);
        movies.Add(movie);
        _accesor.WriteAll(movies);
        ManagerMenu.Start();
    }

    private int GetNextAvailableId()
    {
        // If there are no movies, start at 1.
        if (!movies.Any())
        {
            return 1;
        }

        // Find the minimum available Id that doesn't exist in the data.
        int minAvailableId = 1;
        while (movies.Any(snack => snack.Id == minAvailableId))
        {
            minAvailableId++;
        }

        return minAvailableId;
    }


    private List<DateTime> CreateTime()
    {
        List<DateTime> dateTimes = new();
        while (true)
        {
            Console.WriteLine("Input the playing date: (Format: Day-Month-Year For example: '31-01-2023')");
            string date = Console.ReadLine();
            Console.WriteLine("Input the playing Time: (Format: Hour:Minute For example: '15:00')");
            string time = Console.ReadLine();

            try
            {
                DateTime dateTime = DateTime.ParseExact($"{date} {time}", "dd-MM-yyyy HH:mm", null);
                dateTimes.Add(dateTime);
                Console.WriteLine("Add another? [1] Yes, any other key: No");
            }
            catch (FormatException)
            {
                Console.WriteLine("Given format is not valid, would you like to try again? [1] yes, any other key: no");
            }

            if (Console.ReadKey().KeyChar != '1')
            {
                break;
            }
        }
        return dateTimes;
    }


    public void ShowMovies()
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
            ShowMovies();
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
                ShowMovies();
            }
            if (inputWeek != 1 && inputWeek != 2)
            {
                Console.WriteLine("Invalid input");
                ShowMovies();
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
            SelectMovie();
        }
        else if (choice == 2)
        {
            SortMoviesGenre();
        }
        else if (choice == 3)
        {
            SortMoviesAge();
        }
        else
        {
            Console.WriteLine("Invalid input");
            ShowMovies();
        }


        int userChoice = 0;
        try
        {
            Console.WriteLine("Do you want to select a movie?\n[1] Yes\n[2] No");
            userChoice = Convert.ToInt32(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input");
            ShowMovies();
        }

        if (userChoice == 1)
        {
            SelectMovie();
        }
        else if (userChoice == 2)
        {
            Console.WriteLine("Press any key to return to the Account menu");
            Console.ReadKey(true);
            AccountMenu.Start();
        }
        else
        {
            Console.WriteLine("Invalid input");
            ShowMovies();
        }
    }

    public void MovieInformation()
    {
        Console.WriteLine("Of which movie would you like to receive some information?\n");
        foreach (var movie in movies)
        {
            Console.WriteLine($"MOVIETITLE: {movie.MovieTitle}");
        }
        string userInput = string.Empty;
        while (true)
        {
            Console.WriteLine("Enter title:");
            userInput = Console.ReadLine();
            bool valid = false;

            foreach (MovieModel movie in movies)
            {
                if (userInput == movie.MovieTitle)
                {
                    valid = true;
                    MovieInformationOptions(movie);
                    AccountMenu.Start();
                }
            }
            if (valid)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again");
            }
        }
    }

    public void MovieInformationOptions(MovieModel movie)
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

    public void SortMoviesGenre()
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
            SortMoviesGenre();
        }
        if (inputWeek != 1 && inputWeek != 2)
        {
            Console.WriteLine("Invalid input");
            SortMoviesGenre();
        }
        Console.WriteLine("Which genre?(Comedy,Action,Adventure,Sci-Fi,Crime,Thriller,Fantasy,Family,Drama)");
        string inputGenre = Console.ReadLine();
        if (inputGenre != "Comedy" && inputGenre != "Action" && inputGenre != "Adventure" && inputGenre != "Sci-Fi" && inputGenre != "Crime" && inputGenre != "Thriller" && inputGenre != "Fantasy" && inputGenre != "Family" && inputGenre != "Drama")
        {
            Console.WriteLine("Invalid input");
            SortMoviesGenre();
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
        SelectMovie();
    }


    public void SortMoviesAge()
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
            SortMoviesAge();
        }
        if (inputWeek != 1 && inputWeek != 2)
        {
            Console.WriteLine("Invalid input");
            SortMoviesAge();
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
        }
        SelectMovie();
    }

    public void DeleteMovie(int movieId)
    {
        MovieModel movieById = movies.FirstOrDefault(movie => movie.Id == movieId);
        if (movieById == null)
        {
            Console.WriteLine("Movie not found. Please try again.");
            return;
        }

        movies.Remove(movieById);
        _accesor.WriteAll(movies);
        Console.WriteLine("Movie deleted");

        Console.WriteLine("Press any key to return to menu");
        Console.ReadKey(true);
        ManagerMenu.Start();
    }

    public void DeleteMovie(string movieTitle)
    {
        MovieModel movieByTitle = movies.FirstOrDefault(movie => movie.MovieTitle == movieTitle);
        if (movieByTitle == null)
        {
            Console.WriteLine("Movie not found. Please try again.");
            return;
        }

        movies.Remove(movieByTitle);
        _accesor.WriteAll(movies);
        Console.WriteLine("Movie deleted");

        Console.WriteLine("Press any key to return to menu");
        Console.ReadKey(true);
        ManagerMenu.Start();
    }

    public void ManageMovies()
    {
        // Error handeling voor de input van de manager
        Console.WriteLine("[1] Add Movies\n[2] Delete Movies\n[3] Return to Menu");
        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            ManageMovies();
            return;
        }
        if (choice == 1)
        {
            AddMovie();
        }
        else if (choice == 2)
        {
            Console.WriteLine("Do you want to delete a movie based on [1] ID or [2] Title?");
            string userInput = Console.ReadLine();
            while (string.IsNullOrEmpty(userInput) || int.TryParse(userInput, out _))
            {
                Console.WriteLine("Invalid input. Please enter a valid number (1 or 2).");
                userInput = Console.ReadLine();
            }
            if (userInput == "1")
            {
                foreach (var item in movies)
                {
                    Console.WriteLine($"ID: {item.Id}, Title: {item.MovieTitle}");
                }
                Console.WriteLine("Which ID?");
                int movieID = Convert.ToInt32(Console.ReadLine());
                DeleteMovie(movieID);
            }
            else if (userInput == "2")
            {
                foreach (var item in movies)
                {
                    Console.WriteLine($"ID: {item.Id}, Title: {item.MovieTitle}");
                }
                Console.WriteLine("Which title?");
                string movieTitle = Console.ReadLine();
                DeleteMovie(movieTitle);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid choice (1 or 2).");
                ManageMovies();
                return;
            }
        }
        else if (choice == 3)
        {
            ManagerMenu.Start();
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid choice.");
            ManageMovies();
            return;
        }
    }

    public void SelectMovie()
    {
        // in het menu een mogelijkheid om een movie te kiezen per week.
        // de geselecteerde movie wordt dan doorgegeven aan de zaal.

        Console.WriteLine("Do you want to select a movie?");
        Console.WriteLine("[1] Yes\n[2] No");
        var userChoice = Convert.ToInt32(Console.ReadLine());
        if (userChoice == 1)
        {
            Console.WriteLine("Enter a movie ID");
            int itemId = Convert.ToInt32(Console.ReadLine());
            // snacks is the list of available snacks.
            // FirstOrDefault() iterates over each element in the list and checks whether the NameFood property of the element matches the snackName entered by the user.
            MovieModel? movie = movies.FirstOrDefault(movie => movie.Id == itemId);
            if (movie == null)
            {
                Console.WriteLine("Invalid, please try again.");
                SelectMovie();
            }

            SelectedMovie = movie.MovieTitle;
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

            //Let the user choose one of the times and put the selected time in startTimeInput
            int selectedTime = Int32.Parse(Console.ReadLine());
            startTimeInput = startingTimes[selectedTime - 1];
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
            duration = movie.PlayTimeInMinutes;
        }
        else if (userChoice == 2)
        {
            Console.WriteLine("Press any key to return to the Account menu");
            Console.ReadKey(true);
            AccountMenu.Start();
        }
        else if (userChoice.GetType() != typeof(int))
        {
            Console.WriteLine("Invalid input");
            SelectMovie();
        }
    }
}