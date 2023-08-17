public class ManagerLogic : LogicBase
// This file is the base for ManagerLogic.
{
    public override void SortMoviesGenreBase(bool isUser = false, bool isManager = true, bool isGuest = false)
    {
        base.SortMoviesGenreBase(isUser, isManager, isGuest);
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
