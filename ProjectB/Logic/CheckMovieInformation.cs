public class CheckMovieInformation
{
    private JsonAccessor<MovieModel> _accesor;
    public CheckMovieInformation()
    {
        _accesor = new JsonAccessor<MovieModel>(@"DataSources/movies.json");
        movies = _accesor.LoadAll();
    }
    public List<MovieModel> movies;

    public string MovieInformation(string movie)
    {
        foreach (MovieModel item in movies)
        {
            if (movie == item.MovieTitle)
            {
                return item.Genre;

            }
            else
            {
                return "Movie not found";
            }


        }
        return null;
    }
}