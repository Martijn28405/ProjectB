public class CoWorkerMoviesLogic : LogicBase
{
    // Co-worker-specific members and methods here...
    public override void SortMoviesGenreBase(bool isUser = false, bool isManager = false)
    {
        base.SortMoviesGenreBase(isUser, isManager); // Pass the flag for co-worker
        // Co-worker-specific sorting logic for genre (if any)
        // ...
    }
    public override void ShowMoviesBase(bool isUser = false, bool isManager = false)
    {
        base.ShowMoviesBase(isUser, isManager);
    }
    public override void SortMoviesAgeBase(bool isUser = false, bool isManager = false)
    {
        base.SortMoviesAgeBase(isUser, isManager);
    }
    public override void ShowSnacksBase(bool isUser = false, bool isManager = false)
    {
        base.ShowSnacksBase(isUser, isManager);
    }
}