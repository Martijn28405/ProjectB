using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


public class SeatMenu2
{
    // Small cinema
    public static int row = 0;
    public static int col = 0;
    static int selectedSeatIndex = 6; // Initially select the first seat
    static string[,] seats = new string[19, 18]; // 14x142 array of seats
    static bool[,] takenSeats = new bool[19, 18];
    public static List<string> selectedSeats = new List<string>();
    public static List<string> selectedSeatsColor = new List<string>();
    public static void Reset()
    {
        selectedSeatIndex = 6; // Initially select the first seat
        seats = new string[19, 18]; // 14x142 array of seats
        takenSeats = new bool[19, 18];
        selectedSeats = new List<string>();
        selectedSeatsColor = new List<string>();
    }

    public static void Start()
    {
        Console.Clear();
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
        string jsonFilePath = "DataSources/Seat_Color_Medium_Cinema.json";
        string jsonText = File.ReadAllText(jsonFilePath);
        JObject jsonObj = JObject.Parse(jsonText);
        JArray seatColorArray = (JArray)jsonObj["Seat_Color_medium_cinema"];

        for (int i = 0; i < seats.GetLength(0); i++)
        {
            for (int j = 0; j < seats.GetLength(1); j++)
            {
                seats[i, j] = "[" + seatColorArray[i][j].ToString() + "]";
            }
        }


        seats[0, 0] = "   ";
        seats[1, 0] = "   ";
        seats[2, 0] = "   ";
        seats[3, 0] = "   ";
        seats[4, 0] = "   ";
        seats[5, 0] = "   ";


        // right upper corner
        seats[0, 17] = "   ";
        seats[1, 17] = "   ";
        seats[2, 17] = "   ";
        seats[3, 17] = "   ";
        seats[4, 17] = "   ";
        seats[5, 17] = "   ";

        // left lower corner
        seats[18, 0] = "   ";
        seats[17, 0] = "   ";
        seats[16, 0] = "   ";
        seats[15, 0] = "   ";
        seats[14, 0] = "   ";
        seats[13, 0] = "   ";
        seats[12, 0] = "   ";
        seats[11, 0] = "   ";

        seats[18, 1] = "   ";
        seats[17, 1] = "   ";
        seats[16, 1] = "   ";
        seats[15, 1] = "   ";
        seats[14, 1] = "   ";

        seats[18, 2] = "   ";
        seats[17, 2] = "   ";


        // right lower corner
        seats[18, 17] = "   ";
        seats[17, 17] = "   ";
        seats[16, 17] = "   ";
        seats[15, 17] = "   ";
        seats[14, 17] = "   ";
        seats[13, 17] = "   ";
        seats[12, 17] = "   ";
        seats[11, 17] = "   ";

        seats[18, 16] = "   ";
        seats[17, 16] = "   ";
        seats[16, 16] = "   ";
        seats[15, 16] = "   ";
        seats[14, 16] = "   ";

        seats[18, 15] = "   ";
        seats[17, 15] = "   ";
    }

    static void DrawSeats()
    {

        Console.CursorTop = 10;
        Console.WriteLine("The blue seats are our standard seats, which are great and comfortable.\n" +
                  "Our yellow seats are handwoven and have a better position for the screen.\n" +
                  "Our red seats are the best seats we have to offer.\n" +
                  "The acoustics are excellent, and your position is ideal for enjoying the film.");
        Console.WriteLine("Prices: \n");
        Console.WriteLine("Blue: $10");
        Console.WriteLine("Yellow: $15");
        Console.WriteLine("Red: $20");
        Console.WriteLine("Select a seat:");

        for (int i = 0; i < seats.GetLength(0); i++)
        {
            for (int j = 0; j < seats.GetLength(1); j++)
            {
                char colorChar = seats[i, j][1];
                ConsoleColor seatColor = ConsoleColor.Blue;

                if (colorChar == 'G') seatColor = ConsoleColor.Yellow;
                else if (colorChar == 'R') seatColor = ConsoleColor.Red;

                Console.ForegroundColor = seatColor;
                if (i == selectedSeatIndex / seats.GetLength(1) && j == selectedSeatIndex % seats.GetLength(1))
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }

                if (seats[i, j] == "   ")
                {
                    Console.Write(seats[i, j]);
                }
                else if (takenSeats[i, j] == true)
                {
                    Console.Write("[X]");
                }
                else
                {
                    Console.Write("[ ]");
                }
                Console.ResetColor();
                Console.Write(" ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("                                 Screen");
        Console.WriteLine("-------------------------------------------------------------------------------");

    }

    static void MoveSelectionUp()
    {
        if (selectedSeatIndex >= seats.GetLength(1))
        {
            var wantedseat = selectedSeatIndex - seats.GetLength(1);
            if (seats[(wantedseat) / seats.GetLength(1), (wantedseat) % seats.GetLength(1)] != "   ")
            {
                selectedSeatIndex -= seats.GetLength(1);
                DrawSeats();

            }
        }
    }

    static void MoveSelectionDown()
    {
        if (selectedSeatIndex < seats.GetLength(0) * seats.GetLength(1) - seats.GetLength(1))
        {
            var wantedseat = selectedSeatIndex + seats.GetLength(1);
            if (seats[(wantedseat) / seats.GetLength(1), (wantedseat) % seats.GetLength(1)] != "   ")
            {
                selectedSeatIndex += seats.GetLength(1);
                DrawSeats();

            }


        }
    }

    static void MoveSelectionLeft()
    {
        if (selectedSeatIndex % seats.GetLength(1) > 0)
        {
            var wantedseat = selectedSeatIndex - 1;
            if (seats[(wantedseat) / seats.GetLength(1), (wantedseat) % seats.GetLength(1)] != "   ")
            {
                selectedSeatIndex--;
                DrawSeats();

            }
        }
    }

    static void MoveSelectionRight()
    {
        if (selectedSeatIndex % seats.GetLength(1) < seats.GetLength(1) - 1)
        {
            var wantedseat = selectedSeatIndex + 1;
            if (seats[(wantedseat) / seats.GetLength(1), (wantedseat) % seats.GetLength(1)] != "   ")
            {
                selectedSeatIndex++;
                DrawSeats();

            }

        }
    }

    public static void SelectSeat()
    {
        row = selectedSeatIndex / seats.GetLength(1);
        col = selectedSeatIndex % seats.GetLength(1);

        if (takenSeats[row, col] != true)
        {
            takenSeats[row, col] = true;// Mark the seat as taken

            Console.WriteLine("Seat selected!");
            Console.WriteLine($"Row: {row}");
            Console.WriteLine($"Seat: {col}");
            selectedSeats.Add($"Row: {row} Seat: {col}");
            selectedSeatsColor.Add(seats[row, col]);
            Choice();
        }
        else if (takenSeats[row, col] == true)
        {
            takenSeats[row, col] = false;
            selectedSeats.Remove($"Row: {row} Seat: {col}");
            selectedSeatsColor.Remove(seats[row, col]);
            Console.WriteLine("Seat deselected!");
            Console.WriteLine($"Row: {row}");
            Console.WriteLine($"Seat: {col}");
            Choice();
        }
        else
        {
            Console.WriteLine("Seat already taken. Please select another seat.");
        }


    }

    static void Choice()
    {
        foreach (var seat in selectedSeats)
        {
            Console.WriteLine(seat);
        }
        Console.WriteLine("Would you like to select more seats, buy some snacks or continue to checkout?");
        string choice = "1";
        if (selectedSeats.Any())
        {
            Console.WriteLine("[1] Select More Seats or Deselect Seats (Use the arrow keys and enter to decide which seat to select or deselect) \n[2] Buy Snacks \n[3] Go to Checkout ");
            choice = Console.ReadLine();
        }
        SnacksLogic snacksLogic = new SnacksLogic();
        ReservationsLogic reservationsLogic = new ReservationsLogic();
        while (string.IsNullOrEmpty(choice) || !IsValidChoice(choice))
        {
            Console.WriteLine("Invalid input. Please select a valid option:");
            choice = Console.ReadLine();
        }
        switch (choice)
        {
            case "1":
                Console.Clear();
                DrawSeats();
                break;
            case "2":
                snacksLogic.BuySnacks();
                reservationsLogic.CreateReservation2(snacksLogic.shoppingCart ?? new List<ShoppingCartModel>());
                break;
            case "3":
                reservationsLogic.CreateReservation2(snacksLogic.shoppingCart ?? new List<ShoppingCartModel>());
                break;

        }
    }
    static bool IsValidChoice(string input)
    {
        return input == "1" || input == "2" || input == "3";
    }

}

