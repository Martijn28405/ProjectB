public static class Program
{
 public static void Main()
 {
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
                                                                                                                                                                                                                              
";

  string[] options = { "Login", "Add Account", "Guest Login", "Manager Login", "Co-Worker Login", "Exit Code", "Show Seats" };
  Menu mymenu = new Menu(prompt, options);
  int SelectedIndex = mymenu.Run();
  switch (SelectedIndex)
  {
   case 0:
    UserLogin.Start();
    break;
   case 1:
    AccountsLogic accountsLogic = new AccountsLogic("accounts.json");
    accountsLogic.CreateAccount();
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
     case 6:
      SeatMenu.Start();
      break;   
  }
 }
}