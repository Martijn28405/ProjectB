public class Program
{
 public static void Main()
 {
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
    accountsLogic.CreateAccount();
    break;
   case 2:
    Console.WriteLine("Not implemented");
    Thread.Sleep(1000);
    Main();
    break;
   case 3:
    Console.WriteLine("Not implemented");
    Thread.Sleep(1000);
    ManagerMenu.Start();
    break;
    case 4:
     Console.WriteLine("Not implemeted yet");
     Thread.Sleep(1000);
     Main();
     break;
     case 5:
      Console.WriteLine("Press any button to exit the app");
      Environment.Exit(0);
      Console.ReadKey(true);
      break;
  }
 }
}