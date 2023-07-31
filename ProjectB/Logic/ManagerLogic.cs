public class ManagerLogic : LogicBase
{
    // Co-worker-specific members and methods here...
    public override void SortMoviesGenreBase(bool isUser = false, bool isManager = true, bool isGuest = false)
    {
        base.SortMoviesGenreBase(isUser, isManager, isGuest); // Pass the flag for co-worker
        // Co-worker-specific sorting logic for genre (if any)
        // ...
    }
    public override void ShowMoviesBase(bool isUser = false, bool isManager = true, bool isGuest = false)
    {
        base.ShowMoviesBase(isUser, isManager, isGuest);
    }
    public override void SortMoviesAgeBase(bool isUser = false, bool isManager = true, bool isGuest = false)
    {
        base.SortMoviesAgeBase(isUser, isManager, isGuest);
    }
    public override void ShowSnacksBase(bool isUser = false, bool isManager = true, bool isGuest = false)
    {
        base.ShowSnacksBase(isUser, isManager, isGuest);
    }
}