public class CoWorkerMoviesLogic : LogicBase
{
    // Co-worker-specific members and methods here...
    public override void SortMoviesGenreBase(bool isUser = false)
    {
        base.SortMoviesGenreBase(isUser); // Pass the flag for co-worker
        // Co-worker-specific sorting logic for genre (if any)
        // ...
    }
    public override void ShowMovies(bool isUser = false)
    {
        base.ShowMovies(isUser);
    }
}