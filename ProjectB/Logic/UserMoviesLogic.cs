public class UserMoviesLogic : LogicBase
{
    // ... Other user-specific members and methods here ...

    public override void SortMoviesGenreBase(bool isUser = true, bool isManager = false)
    {
        base.SortMoviesGenreBase(isUser, isManager); // Call the base method with the correct flag for users
        // User-specific sorting logic for genre (if any)
        // For example, you can add additional filters, prompts, or actions for users here.
    }
    public override void ShowMoviesBase(bool isUser = true, bool isManager = false)
    {
        base.ShowMoviesBase(isUser, isManager);
    }
    public override void SortMoviesAgeBase(bool isUser = true, bool isManager = false)
    {
        base.SortMoviesAgeBase(isUser, isManager);
    }
}
