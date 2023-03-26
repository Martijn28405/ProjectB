using System.Xml.XPath;

public class ManagerMenu
{

    // This code wil only be excuted if the ManagerMenu called.
    static public void Start()
    {
        string prompt = @"

                                                                ____        __      __                           
   /'\_/`\                                                     /\  _`\     /\ \  __/\ \__  __                    
  /\      \     __      ___      __       __      __   _ __    \ \ \L\_\   \_\ \/\_\ \ ,_\/\_\    ___     ___    
  \ \ \__\ \  /'__`\  /' _ `\  /'__`\   /'_ `\  /'__`\/\`'__\   \ \  _\L   /'_` \/\ \ \ \/\/\ \  / __`\ /' _ `\  
   \ \ \_/\ \/\ \L\.\_/\ \/\ \/\ \L\.\_/\ \L\ \/\  __/\ \ \/     \ \ \L\ \/\ \L\ \ \ \ \ \_\ \ \/\ \L\ \/\ \/\ \ 
    \ \_\\ \_\ \__/.\_\ \_\ \_\ \__/.\_\ \____ \ \____\\ \_\      \ \____/\ \___,_\ \_\ \__\\ \_\ \____/\ \_\ \_\
     \/_/ \/_/\/__/\/_/\/_/\/_/\/__/\/_/\/___L\ \/____/ \/_/       \/___/  \/__,_ /\/_/\/__/ \/_/\/___/  \/_/\/_/
                                          /\____/                                                                
                                          \_/__/                                                                 
                                                                                                                               
";
        string[] options = { "Login", "Add Account", "Add Movie", "Back to Main Menu", "Exit App"};
        Menu managermenu = new Menu(prompt, options);
        int SelectedIndex = managermenu.Run();
        switch (SelectedIndex)
        {
            case 0:
                UserLogin.Start();
                break;
            case 1:
                Console.WriteLine("Not Implemented Yet");
                Thread.Sleep(1000);
                Start();
                break;
            case 2:
                MoviesLogic addmovie = new MoviesLogic();
                addmovie.CreateMovie();
                break;
            case 3:
                Program.Main();
                break;
            case 4:
                Console.WriteLine("press any key to exit the app");
                Console.ReadKey(true);
                Environment.Exit(0);
                break;
        }
    }
}
