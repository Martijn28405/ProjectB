using ProjectB.DataModels;
// Main starting page where you can be send to different user pages:
public static class Program
{
    public static void Main()
    {
        InitializeState(); //empties seatcart when starting application
        Console.CursorVisible = false;
        string prompt = @"
 ___  ___  _______  _________        ________  ___  ________  ________  ________  ________  ________  ________      ___  _______      
|\  \|\  \|\  ___ \|\___   ___\     |\   __  \|\  \|\   __  \|\   ____\|\   ____\|\   __  \|\   __  \|\   __  \    |\  \|\  ___ \     
\ \  \\\  \ \   __/\|___ \  \_|     \ \  \|\ /\ \  \ \  \|\  \ \  \___|\ \  \___|\ \  \|\  \ \  \|\  \ \  \|\  \   \ \  \ \   __/|    
 \ \   __  \ \  \_|/__  \ \  \       \ \   __  \ \  \ \  \\\  \ \_____  \ \  \    \ \  \\\  \ \  \\\  \ \   ____\__ \ \  \ \  \_|/__  
  \ \  \ \  \ \  \_|\ \  \ \  \       \ \  \|\  \ \  \ \  \\\  \|____|\  \ \  \____\ \  \\\  \ \  \\\  \ \  \___|\  \\_\  \ \  \_|\ \ 
   \ \__\ \__\ \_______\  \ \__\       \ \_______\ \__\ \_______\____\_\  \ \_______\ \_______\ \_______\ \__\  \ \________\ \_______\
    \|__|\|__|\|_______|   \|__|        \|_______|\|__|\|_______|\_________\|_______|\|_______|\|_______|\|__|   \|________|\|_______|
                                                                \|_________|             
    Locatie: Wijnhaven 107, 3011 WN Rotterdam
                                                                                                                                                                                                                                 
";
        // The options to choose from:
        string[] options = { "Login", "Add Account", "Guest Login", "Manager Login", "Co-Worker Login", "Exit Code" };
        Menu mymenu = new Menu(prompt, options);
        int SelectedIndex = mymenu.Run();
        switch (SelectedIndex)
        {
            case 0:
                UserLogin.Start();

                break;
            case 1:
                AccountsLogic accountsLogic = new AccountsLogic();
                accountsLogic.CreateAccount("User");
                break;
            case 2:
                GuestMenu.Start();
                break;
            case 3:
                ManagerLogin.Start();
                break;
            case 4:
                CoWorkerLogin.Start();
                break;
            case 5:
                Console.WriteLine("Press any button to exit the app");
                Console.ReadKey(true);
                Environment.Exit(0);
                break;
        }
    }
    // Everytime a new terminal is made al the JSON files are emptied:
    public static void InitializeState()
    {
        JsonAccessor<SeatsCartModel> cartAccesor = new JsonAccessor<SeatsCartModel>(@"DataSources/SeatsCart.json");
        cartAccesor.WriteAll(new());
        JsonAccessor<ShoppingCartModel> shopAccesor = new JsonAccessor<ShoppingCartModel>(@"DataSources/shoppingcart.json");
        shopAccesor.WriteAll(new());
    }
}
