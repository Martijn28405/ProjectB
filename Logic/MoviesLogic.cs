using System;
using System.Collections.Generic;
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
        MovieModel movie = new MovieModel(week, movietitle, director, description, genre, targetAudience);
        movies.Add(movie);
        _accesor.WriteAll(movies);
        AccountMenu.Start();
    }
    public void ShowMovies()
    {
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
}