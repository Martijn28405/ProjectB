using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class SeatMenu3
{
    // Small cinema
    public static int row = 0;
    public static int col = 0;
    static int selectedSeatIndex = 6; // Initially select the first seat
    static string[,] seats = new string[20, 30]; // 14x142 array of seats
    static bool[,] takenSeats = new bool[20, 30];
    public static List<string> selectedSeats = new List<string>();
    public static List<string> selectedSeatsColor = new List<string>();

    public static void Reset()
    {
        selectedSeatIndex = 6; // Initially select the first seat
        seats = new string[20, 30]; // 14x142 array of seats
        takenSeats = new bool[20, 30];
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
        string jsonFilePath = "DataSources/Seat_Color_Big_Cinema.json";
        string jsonText = File.ReadAllText(jsonFilePath);
        JObject jsonObj = JObject.Parse(jsonText);
        JArray seatColorArray = (JArray)jsonObj["Seat_Color_Big_cinema"];

        for (int i = 0; i < seats.GetLength(0); i++)
        {
            for (int j = 0; j < seats.GetLength(1); j++)
            {
                seats[i, j] = "[" + seatColorArray[i][j].ToString() + "]";
            }
        }


        seats[0, 0] = "   ";
        seats[0, 1] = "   ";
        seats[0, 2] = "   ";
        seats[0, 3] = "   ";

        seats[1, 0] = "   ";
        seats[1, 1] = "   ";
        seats[1, 2] = "   ";

        seats[2, 0] = "   ";
        seats[2, 1] = "   ";
        seats[2, 2] = "   ";

        seats[3, 0] = "   ";
        seats[3, 1] = "   ";
        seats[3, 2] = "   ";

        seats[4, 0] = "   ";
        seats[4, 1] = "   ";
        seats[4, 2] = "   ";

        seats[5, 0] = "   ";
        seats[5, 1] = "   ";

        seats[6, 0] = "   ";


        // right upper corner
        seats[0, 29] = "   ";
        seats[0, 28] = "   ";
        seats[0, 27] = "   ";
        seats[0, 26] = "   ";

        seats[1, 29] = "   ";
        seats[1, 28] = "   ";
        seats[1, 27] = "   ";

        seats[2, 29] = "   ";
        seats[2, 28] = "   ";
        seats[2, 27] = "   ";

        seats[3, 29] = "   ";
        seats[3, 28] = "   ";
        seats[3, 27] = "   ";

        seats[4, 29] = "   ";
        seats[4, 28] = "   ";
        seats[4, 27] = "   ";

        seats[5, 29] = "   ";
        seats[5, 28] = "   ";

        seats[6, 29] = "   ";

        // right lower corner

        seats[19, 0] = "   ";
        seats[19, 1] = "   ";
        seats[19, 2] = "   ";
        seats[19, 3] = "   ";
        seats[19, 4] = "   ";
        seats[19, 5] = "   ";
        seats[19, 6] = "   ";
        seats[19, 7] = "   ";

        seats[18, 0] = "   ";
        seats[18, 1] = "   ";
        seats[18, 2] = "   ";
        seats[18, 3] = "   ";
        seats[18, 4] = "   ";
        seats[18, 5] = "   ";
        seats[18, 6] = "   ";

        seats[17, 0] = "   ";
        seats[17, 1] = "   ";
        seats[17, 2] = "   ";
        seats[17, 3] = "   ";
        seats[17, 4] = "   ";

        seats[16, 0] = "   ";
        seats[16, 1] = "   ";
        seats[16, 2] = "   ";

        seats[15, 0] = "   ";
        seats[15, 1] = "   ";
        seats[15, 2] = "   ";

        seats[14, 0] = "   ";
        seats[14, 1] = "   ";

        seats[13, 0] = "   ";
        seats[13, 1] = "   ";

        seats[12, 0] = "   ";


        // right lower corner

        seats[19, 29] = "   ";
        seats[19, 28] = "   ";
        seats[19, 27] = "   ";
        seats[19, 26] = "   ";
        seats[19, 25] = "   ";
        seats[19, 24] = "   ";
        seats[19, 23] = "   ";
        seats[19, 22] = "   ";

        seats[18, 29] = "   ";
        seats[18, 28] = "   ";
        seats[18, 27] = "   ";
        seats[18, 26] = "   ";
        seats[18, 25] = "   ";
        seats[18, 24] = "   ";
        seats[18, 23] = "   ";

        seats[17, 29] = "   ";
        seats[17, 28] = "   ";
        seats[17, 27] = "   ";
        seats[17, 26] = "   ";
        seats[17, 25] = "   ";

        seats[16, 29] = "   ";
        seats[16, 28] = "   ";
        seats[16, 27] = "   ";

        seats[15, 29] = "   ";
        seats[15, 28] = "   ";
        seats[15, 27] = "   ";

        seats[14, 29] = "   ";
        seats[14, 28] = "   ";

        seats[13, 29] = "   ";
        seats[13, 28] = "   ";

        seats[12, 29] = "   ";
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
        Console.WriteLine("                                                     Screen");
        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
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
            if (seats[(selectedSeatIndex + 1) / seats.GetLength(1), (selectedSeatIndex + 1) % seats.GetLength(1)] != "   ")
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
                reservationsLogic.CreateReservation3(snacksLogic.shoppingCart ?? new List<ShoppingCartModel>());
                break;
            case "3":
                reservationsLogic.CreateReservation3(snacksLogic.shoppingCart ?? new List<ShoppingCartModel>());
                break;
        }
    }
    static bool IsValidChoice(string input)
    {
        return input == "1" || input == "2" || input == "3";
    }
}
