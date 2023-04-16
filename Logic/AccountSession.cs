public static class AccountSession
{
    public static AccountModel LoggedInAccount { get; set; }
    public static UserType Type { get; set; }
    public static bool IsLoggedIn
    {
        get
        {
            return LoggedInAccount != null;
        }
    }
}