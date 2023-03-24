using System.Xml.XPath;


public class Co_Worker_menu
{

    // This code wil only be excuted if the Co-worker called.
    public static void Start()
    {
        string prompt = @"
   ____                      __      __                 __                         ____        __      __                           
  /\  _`\                   /\ \  __/\ \               /\ \                       /\  _`\     /\ \  __/\ \__  __                    
  \ \ \/\_\    ___          \ \ \/\ \ \ \    ___   _ __\ \ \/'\      __   _ __    \ \ \L\_\   \_\ \/\_\ \ ,_\/\_\    ___     ___    
   \ \ \/_/_  / __`\  _______\ \ \ \ \ \ \  / __`\/\`'__\ \ , <    /'__`\/\`'__\   \ \  _\L   /'_` \/\ \ \ \/\/\ \  / __`\ /' _ `\  
    \ \ \L\ \/\ \L\ \/\______\\ \ \_/ \_\ \/\ \L\ \ \ \/ \ \ \\`\ /\  __/\ \ \/     \ \ \L\ \/\ \L\ \ \ \ \ \_\ \ \/\ \L\ \/\ \/\ \ 
     \ \____/\ \____/\/______/ \ `\___x___/\ \____/\ \_\  \ \_\ \_\ \____\\ \_\      \ \____/\ \___,_\ \_\ \__\\ \_\ \____/\ \_\ \_\
      \/___/  \/___/            '\/__//__/  \/___/  \/_/   \/_/\/_/\/____/ \/_/       \/___/  \/__,_ /\/_/\/__/ \/_/\/___/  \/_/\/_/
                                                                                                                                                                                                                          
";
        string[] options = { "Login", "Add Account", "Back to Main Menu" };
        Menu co_workermenu = new Menu(prompt, options);
        int SelectedIndex = co_workermenu.Run();
        switch (SelectedIndex)
        {
            case 0:
                UserLogin.Start();
                break;
            case 1:
                break;
            case 2:
                Program.Main();
                break;
            case 3:
                Console.WriteLine("press any key to exit the app");
                Console.ReadKey(true);
                Environment.Exit(0);
                break;



            // if (input == "1")
            // {
            //     UserLogin.Start();
            // }
            // else if (input == "2")
            // {
            //     Console.WriteLine("This feature is not yet implemented");
            //     //add account
            // }
            // else
            // {
            //     Console.WriteLine("Invalid input");
            //     Start();
            // }

        }
    }
}
