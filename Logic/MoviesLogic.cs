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
    public void SortMoviesGenre()
    {
        //sort movies on genre
        System.Console.WriteLine("Which week?");
        int inputWeek = Convert.ToInt32(Console.ReadLine());
        System.Console.WriteLine("Which genre?(Comedy,Action,Adventure)");
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
        System.Console.WriteLine("Which week?");
        int inputWeek = Convert.ToInt32(Console.ReadLine());
        System.Console.WriteLine("Minimum age?(6,12,18)");
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
        Co_Worker_menu.Start();
    }
}