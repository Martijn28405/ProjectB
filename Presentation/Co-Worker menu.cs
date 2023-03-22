using System.Xml.XPath;


public class Co_Worker_menu
{

    // This code wil only be excuted if the Co-worker called.
    static public void Start()
    {
        Console.Clear();
        Console.WriteLine("Welcome bij:");
        string text = @"
   ____                      __      __                 __                         ____        __      __                           
  /\  _`\                   /\ \  __/\ \               /\ \                       /\  _`\     /\ \  __/\ \__  __                    
  \ \ \/\_\    ___          \ \ \/\ \ \ \    ___   _ __\ \ \/'\      __   _ __    \ \ \L\_\   \_\ \/\_\ \ ,_\/\_\    ___     ___    
   \ \ \/_/_  / __`\  _______\ \ \ \ \ \ \  / __`\/\`'__\ \ , <    /'__`\/\`'__\   \ \  _\L   /'_` \/\ \ \ \/\/\ \  / __`\ /' _ `\  
    \ \ \L\ \/\ \L\ \/\______\\ \ \_/ \_\ \/\ \L\ \ \ \/ \ \ \\`\ /\  __/\ \ \/     \ \ \L\ \/\ \L\ \ \ \ \ \_\ \ \/\ \L\ \/\ \/\ \ 
     \ \____/\ \____/\/______/ \ `\___x___/\ \____/\ \_\  \ \_\ \_\ \____\\ \_\      \ \____/\ \___,_\ \_\ \__\\ \_\ \____/\ \_\ \_\
      \/___/  \/___/            '\/__//__/  \/___/  \/_/   \/_/\/_/\/____/ \/_/       \/___/  \/__,_ /\/_/\/__/ \/_/\/___/  \/_/\/_/
                                                                                                                                                                                                                          
";
        Console.WriteLine(text);
        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------");
        
        while (true)
        {
            Console.WriteLine("Enter [1] too remove or add movies");
            Console.WriteLine("Enter [2] too show inventory of the shop");
            Console.WriteLine("Enter [3] too remove or add items too the shop");
            Console.WriteLine("Enter [4] too show all the reservations");
            Console.WriteLine("Enter [5] too remove reservations");
            Console.WriteLine("Enter [6] go back to main menu");
            string input = Console.ReadLine();
            
            switch (input)
            {
                case "1":
                    Console.WriteLine("function is not implemented yet");
                    break;
                case "2":
                    Console.WriteLine("function is not implemented yet");
                    break;
                case "3":
                    Console.WriteLine("function is not implemented yet ");
                    break;
                case "4":
                    Console.WriteLine("function is not implemented yet");
                    break;
                case "5":
                    Console.WriteLine("function is not implemented yet");
                    break;
                case "6":
                    Console.Clear();
                    Menu.Start();
                    break;
                default: 
                    Console.WriteLine("Unknown input registerd");
                    break;
            }
        }



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
