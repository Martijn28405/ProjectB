public class UserMoviesLogic : LogicBase
{
    // ... Other user-specific members and methods here ...

    public override void SortMoviesGenreBase(bool isUser = true)
    {
        base.SortMoviesGenreBase(isUser); // Call the base method with the correct flag for users
        // User-specific sorting logic for genre (if any)
        // For example, you can add additional filters, prompts, or actions for users here.
    }
    public override void ShowMovies(bool isUser = true)
    {
        base.ShowMovies(isUser);
    }
}
