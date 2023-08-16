using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
public class MoviesLogic
{
    private JsonAccessor<MovieModel> _accesor;
    public List<MovieModel> movies;
    public static string? SelectedMovie;

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
            Console.WriteLine("Invalid input. Please enter a valid title:");
            movietitle = Console.ReadLine();
        }

        Console.WriteLine("Movie Director:");
        string? director = Console.ReadLine();
        while (string.IsNullOrEmpty(director) || int.TryParse(director, out _))
        {
            Console.WriteLine("Invalid input. Please enter a valid name:");
            director = Console.ReadLine();
        }

        Console.WriteLine("Movie Description:");
        string? description = Console.ReadLine();
        while (string.IsNullOrEmpty(description) || int.TryParse(description, out _))
        {
            Console.WriteLine("Invalid input. Please enter a valid description:");
            description = Console.ReadLine();
        }

        Console.WriteLine("Movie Genres (When mulitple divided by a ',' like this: Action, Adventure, Fantasy):");
        string? genre = Console.ReadLine();
        string[] validGenres = { "Comedy", "Action", "Adventure", "Sci-Fi", "Crime", "Thriller", "Fantasy", "Family", "Drama" };

        while (string.IsNullOrEmpty(genre) || !AreValidGenres(genre, validGenres))
        {
            Console.WriteLine("Invalid input. Please enter valid genres:");
            genre = Console.ReadLine();
        }

        Console.WriteLine("Movie Target Audience (10, 12, 16):");
        string? targetAudience = Console.ReadLine();
        while (string.IsNullOrEmpty(targetAudience) || (targetAudience != "10" && targetAudience != "12" && targetAudience != "16"))
        {
            Console.WriteLine("Invalid input. Please enter a valid number:");
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
    static bool AreValidGenres(string input, string[] validGenres)
    {
        string[] genres = input.Split(", ");
        foreach (string genre in genres)
        {
            if (!Array.Exists(validGenres, validGenre => validGenre == genre))
            {
                return false;
            }
        }
        return true;
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

            {
                var orderedMovies = movies.OrderBy(movie => movie.Id);
                foreach (var item in orderedMovies)
                {
                    Console.WriteLine($"ID: {item.Id}, Title: {item.MovieTitle}");
                }
                int movieID;
                while (true)
                {
                    Console.WriteLine("Please enter the ID of the movie you want to delete:");
                    if (int.TryParse(Console.ReadLine(), out movieID))
                    {
                        var maxMovieId = movies.Max(x => x.Id);
                        if (movieID > 0 && movieID <= maxMovieId)
                        {
                            DeleteMovie(movieID);
                            Console.WriteLine("Movie deleted successfully.");
                            break;
                        }
                    }
                    Console.WriteLine("Invalid input.");
                }

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
}