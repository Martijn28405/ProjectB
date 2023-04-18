using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
public class MoviesLogic
{
    private JsonAccessor<MovieModel> _accesor;
    public List<MovieModel> movies;
    public MoviesLogic()
    {
        _accesor = new JsonAccessor<MovieModel>(@"DataSources/movies.json");
        movies = _accesor.LoadAll();
    }

    public void AddMovie()
    {
        Console.WriteLine("The week in which the movie will play:");
        int week = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Movie Title:");
        string? movietitle = Console.ReadLine();
        Console.WriteLine("Movie Director:");
        string? director = Console.ReadLine();
        Console.WriteLine("Movie Description:");
        string? description = Console.ReadLine();
        Console.WriteLine("Movie Genre:");
        string? genre = Console.ReadLine();
        Console.WriteLine("Movie Target Audience:");
        string? targetAudience = Console.ReadLine();
        Console.WriteLine("What is the play time in minutes?");
        int playTime = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Start times:");
        List<DateTime> dateTimes = CreateTime();

        MovieModel movie = new MovieModel(week, movietitle, director, description, genre, targetAudience, playTime, dateTimes);
        movies.Add(movie);
        _accesor.WriteAll(movies);
        ManagerMenu.Start();
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
                Console.WriteLine("Add another? [1] yes, any other key: no");
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
        System.Console.WriteLine("[1] Show all movies\n[2] Sort movies on genre\n[3] Sort movies on age");
        int choice = Int32.Parse(Console.ReadLine());
        if (choice == 2)
        {
            SortMoviesGenre();
        }
        else if (choice == 3)
        {
            SortMoviesAge();
        }
        Console.WriteLine("Which week?");
        int inputWeek = Convert.ToInt32(Console.ReadLine());

        foreach (var item in movies)
        {
            if (inputWeek == item.Week)
            {
                Console.WriteLine($"WEEK: {item.Week}");
                Console.WriteLine($"MOVIETITLE: {item.MovieTitle}");
                Console.WriteLine($"DIRECTOR: {item.Director}");
                Console.WriteLine($"INFORMATION: {item.Information}");
                Console.WriteLine($"GENRE:{item.Genre}");
                Console.WriteLine($"TARGET AUDIENCE: {item.TargetAudience}");
            }

        }
        Console.WriteLine("Press any key to return to menu");
        Console.ReadKey(true);
        AccountMenu.Start();
    }

    public void MovieInformation()
    {
        Console.WriteLine("Of which movie would you like to receive some information?");
        string userInput = Console.ReadLine();

        foreach (MovieModel movie in movies)
        {
            if (userInput == movie.MovieTitle)
            {
                Console.WriteLine(@"Which information would you like to look at?
                [1] The synopsis of the movie.
                [2] The target audience of the movie.
                [3] The genres of the movie.
                [4] The times at which the movie is playing.");

                string userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        Console.WriteLine(movie.Information);
                        break;
                    case "2":
                        Console.WriteLine(movie.TargetAudience);
                        break;
                    case "3":
                        Console.WriteLine(movie.Genre);
                        break;
                    case "4":
                        foreach (DateTime time in movie.StartTime)
                        {
                            Console.WriteLine(time.ToString("dd-MM-yyyy HH:mm"));
                        }
                        break;
                    default:
                        Console.WriteLine("Incorrect input, try again:");
                        break;
                }
                Console.WriteLine("Press any key to return to the main menu");
                Console.ReadKey(true);
                AccountMenu.Start();
            }
        }
    }
    public void SortMoviesGenre()
    {
        //sort movies on genre
        Console.WriteLine("Which week?");
        int inputWeek = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Which genre?(Comedy,Action,Adventure)");
        string inputGenre = Console.ReadLine();
        foreach (var item in movies)
        {
            if (inputWeek == item.Week && inputGenre == item.Genre)
            {
                Console.WriteLine($"WEEK: {item.Week}");
                Console.WriteLine($"MOVIETITLE: {item.MovieTitle}");
                Console.WriteLine($"DIRECTOR: {item.Director}");
                Console.WriteLine($"INFORMATION: {item.Information}");
                Console.WriteLine($"GENRE:{item.Genre}");
                Console.WriteLine($"TARGET AUDIENCE: {item.TargetAudience}");
            }
        }
        Console.WriteLine("Press any key to return to menu");
        Console.ReadKey(true);
        AccountMenu.Start();
    }

    public void SortMoviesAge()
    {
        //sort movies on age
        Console.WriteLine("Which week?");
        int inputWeek = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Minimum age?(6,12,18)");
        string inputAge = Console.ReadLine();
        foreach (var item in movies)
        {
            if (inputWeek == item.Week && inputAge == item.TargetAudience)
            {
                Console.WriteLine($"WEEK: {item.Week}");
                Console.WriteLine($"MOVIETITLE: {item.MovieTitle}");
                Console.WriteLine($"DIRECTOR: {item.Director}");
                Console.WriteLine($"INFORMATION: {item.Information}");
                Console.WriteLine($"GENRE:{item.Genre}");
                Console.WriteLine($"TARGET AUDIENCE: {item.TargetAudience}");
            }
        }
        Console.WriteLine("Press any key to return to menu");
        Console.ReadKey(true);
        AccountMenu.Start();
    }

    public void ShowMoviesWorker()
    {
        foreach (var item in movies)
        {
            Console.WriteLine($"WEEK: {item.Week}");
            Console.WriteLine($"MOVIETITLE: {item.MovieTitle}");
            Console.WriteLine($"DIRECTOR: {item.Director}");
            Console.WriteLine($"INFORMATION: {item.Information}");
            Console.WriteLine($"GENRE:{item.Genre}");
            Console.WriteLine($"TARGET AUDIENCE: {item.TargetAudience}\n");
        }
        Console.WriteLine("Press any key to return to menu");
        Console.ReadKey(true);
        CoWorkerMenu.Start();
    }

    public void DeleteMovie()
    {
        foreach (var item in movies)
        {
            Console.WriteLine($"MOVIETITLE: {item.MovieTitle}");
        }

        Console.WriteLine("Which movie do you want to delete?");
        string inputMovie = Console.ReadLine();
        foreach (var item in movies)
        {
            if (inputMovie == item.MovieTitle)
            {
                movies.Remove(item);
                _accesor.WriteAll(movies);
                Console.WriteLine("Movie deleted");
                break;
            }
        }

        Console.WriteLine("Press any key to return to menu");
        Console.ReadKey(true);
        ManagerMenu.Start();
    }

    public void ManageMovies()
    {
        //Add or delete movies ONLY as Admin
        Console.WriteLine("[1] Add Movies\n[2] Delete Movies\n[3] Return to Menu");
        int choice = Int32.Parse(Console.ReadLine());
        if (choice == 1)
        {
            AddMovie();
        }
        else if (choice == 2)
        {
            DeleteMovie();
        }
        else if (choice == 3)
        {
            ManagerMenu.Start();
        }
        else
        {
            Console.WriteLine("Invalid input");
            ManageMovies();
        }
    }
}