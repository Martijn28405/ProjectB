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

    public void CreateMovie()
    {
        int week = Convert.ToInt32(Console.ReadLine());
        string? movietitle = Console.ReadLine();
        string? director = Console.ReadLine();
        string? information = Console.ReadLine();
        string? genre = Console.ReadLine();
        string? targetAudience = Console.ReadLine();
        MovieModel movie = new MovieModel(week, movietitle, director, information, genre, targetAudience);
        movies.Add(movie);
        _accesor.WriteAll(movies);
    }
}