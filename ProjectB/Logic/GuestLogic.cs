public class GuestLogic : LogicBase
// This file is the base for the GuestLogic.
{
    public override void SortMoviesGenreBase(bool isUser = false, bool isManager = false, bool isGuest = true)
    {
        base.SortMoviesGenreBase(isUser, isManager, isGuest);
    }
    public override void ShowMoviesBase(bool isUser = true, bool isManager = false, bool isGuest = true)
    {
        base.ShowMoviesBase(isUser, isManager, isGuest);
    }
    public override void SortMoviesAgeBase(bool isUser = true, bool isManager = false, bool isGuest = true)
    {
        base.SortMoviesAgeBase(isUser, isManager, isGuest);
    }
    public override void ShowSnacksBase(bool isUser = true, bool isManager = false, bool isGuest = true)
    {
        base.ShowSnacksBase(isUser, isManager, isGuest);
    }
    public override void SelectMovieBase(bool isUser, bool isGuest)
    {
        base.SelectMovieBase(isUser, isGuest);
    }
    public override void MovieInformation(bool isUser = true, bool isGuest = false)
    {
        base.MovieInformation(isUser, isGuest);
    }
}
