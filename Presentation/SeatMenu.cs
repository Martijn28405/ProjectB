using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


public class SeatMenu
{
    // Small cinema
    public static int row = 0;
    public static int col = 0;
    static int selectedSeatIndex = 6; // Initially select the first seat
    static string[,] seats = new string[14, 12]; // 14x142 array of seats
    static bool[,] takenSeats = new bool[14, 12];

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
        string jsonFilePath = "DataSources/Seat_Color.json";
        string jsonText = File.ReadAllText(jsonFilePath);
        JObject jsonObj = JObject.Parse(jsonText);
        JArray seatColorArray = (JArray)jsonObj["Color_Seats_Small_Cinema"];

        for (int i = 0; i < seats.GetLength(0); i++)
        {
            for (int j = 0; j < seats.GetLength(1); j++)
            {
                seats[i, j] = "[" + seatColorArray[i][j].ToString() + "]";
            }
        }


        // Left upper corner (seats[y,x])
        seats[0, 0] = "   ";
        seats[1, 0] = "   ";
        seats[2, 0] = "   ";
        seats[0, 1] = "   ";

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
        seats[11, 0] = "   ";

        // lower right corner
        seats[13, 11] = "   ";
        seats[13, 10] = "   ";
        seats[12, 10] = "   ";
        seats[12, 11] = "   ";
        seats[11, 11] = "   ";
    }

    static void DrawSeats()
    {

        Console.CursorTop = 10;
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
                    Console.Write(seats[i, j] + " ");
                }
                else if (takenSeats[i, j] == true)
                {
                    Console.Write("[X] ");
                }
                else
                {
                    Console.Write("[ ] ");
                }
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

    public static void SelectSeat()
    {
        int row = selectedSeatIndex / seats.GetLength(1);
        int col = selectedSeatIndex % seats.GetLength(1);
        if (seats[row, col] != "[X]")
        {
            takenSeats[row, col] = true;// Mark the seat as taken

            Console.WriteLine("Seat selected!");
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
        Console.WriteLine("[1] Select More Seats \n[2] Go to Checkout ");
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                Console.Clear();
                DrawSeats();
                break;
            case "2":
                ReservationsLogic reservationsLogic = new ReservationsLogic();
                reservationsLogic.CreateReservation();
                break;

        }
    }

    // Hier komt de indx met de verschillende kleuren

    static void ColorIndex()
    {


    }

    // Proberen maken van de clear functie zodat Color index werkt

    private static void CinemaBaseColor()
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;

    }


    private static void CinemaBaseColorYellow()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;

    }

    /*private static void JsonEdditor()
    {
        {
                // Lees de JSON uit het bestand
                string json = System.IO.File.ReadAllText(@"Seat_Color.json");

                // Deserialiseer de JSON in een JObject
                JObject jObject = JObject.Parse(json);

                // Zoek de 'Color_Seats_Small_Cinema'-array op
                JArray seatsArray = (JArray)jObject["Color_Seats_Small_Cinema"];

                // Loop door de array heen en vervang de codes door hun kleuren
                
                
                
                // hier wil je aan passesn dat de kleuren worden veranderd in de scinema seats
                for (int i = 0; i < seatsArray.Count; i++)
                {
                    JArray seatRow = (JArray)seatsArray[i];
                    for (int j = 0; j < seatRow.Count; j++)
                    {
                        string seatCode = seatRow[j].ToString();
                        switch (seatCode)
                        {
                            case "B":
                                seatRow[j] = "Blue";
                                break;
                            case "G":
                                seatRow[j] = "Yellow";
                                break;
                            case "R":
                                seatRow[j] = "Red";
                                break;
                        }
                    }
                }*/

    // De gewijzigde JSON is nu opgeslagen in het jObject, dus je kunt de JSON nu weer wegschrijven naar het bestand als je dat wilt.
    // Laatste stap is het opslaan van het gewijzigde JObject als JSON naar een string, en deze string kan weer worden weggeschreven naar het bestand.
    /*string newJson = jObject.ToString();
    System.IO.File.WriteAllText(@"Seat_Cinema.Json", newJson);*/
}






