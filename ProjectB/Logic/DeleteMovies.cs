namespace ProjectB.Logic;

public class DeleteMoviesLogic
{
    private JsonAccessor<MovieModel> _accesor;
    public DeleteMoviesLogic()
    {
        _accesor = new JsonAccessor<MovieModel>(@"DataSources/movies.json");
        movies = _accesor.LoadAll();
    }
    public List<MovieModel> movies;

    public void DeleteMovies(string movie)
    {
        foreach (var item in movies)
        {
            if (movie == item.MovieTitle)
            {
                movies.Remove(item);
                _accesor.WriteAll(movies);
                Console.WriteLine("Movie deleted");
                break;
            }
            else
            {
                Console.WriteLine("Movie not found");
            }

        }
    }
}