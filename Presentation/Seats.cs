static class Seats
{
    // Small cinema
    static int selectedSeatIndex = 6; // Initially select the first seat
    static string[,] seats = new string[14, 12]; // 14x12 array of seats

    public static void Show_Seats()
    {
        Console.CursorVisible = false;
        InitializeSeats(); // Initialize seats with "[ ]"
        DrawSeats(); // Draw initial seats
        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    MoveSelectionUp();
                    break;
                case ConsoleKey.DownArrow:
                    MoveSelectionDown();
                    break;
                case ConsoleKey.LeftArrow:
                    MoveSelectionLeft();
                    break;
                case ConsoleKey.RightArrow:
                    MoveSelectionRight();
                    break;
                case ConsoleKey.Enter:
                    SelectSeat();
                    break;
            }
        }
    }

    static void InitializeSeats()
    {
        for (int i = 0; i < seats.GetLength(0); i++)
        {
            for (int j = 0; j < seats.GetLength(1); j++)
            {
                
                seats[i, j] = "[ ]";
                

            }
            
        }

        // Left upper corner (seats[y,x])
        /*seats[0, 0] = "   ";
        seats[1,0] = "   ";
        seats[2,0] = "   ";
        seats[0,1] = "   ";
        
        // Right upper corner
        seats[0, 11] = "   ";
        seats[1, 11] = "   ";
        seats[2, 11] = "   ";
        seats[0, 10] = "   ";
        
        // Lower left corner
        seats[13, 0] = "   ";
        seats[13, 1] = "   ";
        seats[12, 0] = "   ";
        seats[12, 1] = "   ";
        seats[11,0] = "   ";
        
        // lower right corner
        seats[13, 11] = "   ";
        seats[13, 10] = "   ";
        seats[12, 10] = "   ";
        seats[12, 11] = "   ";
        seats[11,11] = "   ";*/
    }

    static void DrawSeats()
    {
        Console.CursorTop = 10;
        Console.WriteLine("Select a seat:");

        for (int i = 0; i < seats.GetLength(0); i++)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int j = 0; j < seats.GetLength(1); j++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                //Base Color setter in blue

                // Base Color setter for yellow circle 
                // CinemaBaseColorYellow();

                if (i == selectedSeatIndex / seats.GetLength(1) && j == selectedSeatIndex % seats.GetLength(1))
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Highlight selected seat
                }
                Console.Write(seats[i, j] + " ");
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }

    static void MoveSelectionUp()
    {
        if (selectedSeatIndex >= seats.GetLength(1))
        {
            selectedSeatIndex -= seats.GetLength(1);
            DrawSeats();
        }
    }

    static void MoveSelectionDown()
    {
        if (selectedSeatIndex < seats.GetLength(0) * seats.GetLength(1) - seats.GetLength(1))
        {
            selectedSeatIndex += seats.GetLength(1);
            DrawSeats();
        }
    }

    static void MoveSelectionLeft()
    {
        if (selectedSeatIndex % seats.GetLength(1) > 0)
        {
            selectedSeatIndex--;
            DrawSeats();
        }
    }

    static void MoveSelectionRight()
    {
        if (selectedSeatIndex % seats.GetLength(1) < seats.GetLength(1) - 1)
        {
            selectedSeatIndex++;
            DrawSeats();
        }
    }
    

    static void SelectSeat()
    {
        int row = selectedSeatIndex / seats.GetLength(1);
        int col = selectedSeatIndex % seats.GetLength(1);
        if (seats[row, col] == "[ ]")
        {
            seats[row, col] = "[X]"; // Mark the seat as taken
            
            
            Console.WriteLine("Seat selected!");
            Console.WriteLine("[1] Select More seats \n [2] Go to checkout");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    DrawSeats();
                    break;
                case "2":
                    Program.Main();
                    break;
            }


        }
      
        else
        {
            Console.WriteLine("Seat already taken. Please select another seat.");
        }

    }
    
    // Hier komt de indx met de verschillende kleuren

    static void ColorIndex()
    {


    }
    
    // Proberen maken van de clear functie zodat Color index werkt

    /*private static void CinemaBaseColor()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        
    }*/
    
    
    private static  void CinemaBaseColorYellow()
    {


    }
    
}
