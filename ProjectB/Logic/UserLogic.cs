public class UserLogic : LogicBase
{
    // ... Other user-specific members and methods here ...

    public override void SortMoviesGenreBase(bool isUser = true, bool isManager = false, bool isGuest = false)
    {
        base.SortMoviesGenreBase(isUser, isManager, isGuest); // Call the base method with the correct flag for users
        // User-specific sorting logic for genre (if any)
        // For example, you can add additional filters, prompts, or actions for users here.
    }
    public override void ShowMoviesBase(bool isUser = true, bool isManager = false, bool isGuest = false)
    {
        base.ShowMoviesBase(isUser, isManager, isGuest);
    }
    public override void SortMoviesAgeBase(bool isUser = true, bool isManager = false, bool isGuest = false)
    {
        base.SortMoviesAgeBase(isUser, isManager, isGuest);
    }
    public override void ShowSnacksBase(bool isUser = true, bool isManager = false, bool isGuest = false)
    {
        base.ShowSnacksBase(isUser, isManager, isGuest);
    }
    public override void SelectMovieBase(bool isUser = true, bool isGuest = false)
    {
        base.SelectMovieBase(isUser, isGuest);
    }
    public override void MovieInformation(bool isUser = true, bool isGuest = false)
    {
        base.MovieInformation(isUser, isGuest);
    }
}
