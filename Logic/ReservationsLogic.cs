using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;



public class ReservationsLogic
{
    private JsonAccessor<ReservationModel> accesor;
    public List<ReservationModel> _reservations;
    public ReservationsLogic()
    {
        accesor = new JsonAccessor<ReservationModel>(@"DataSources/reservation.json");
        _reservations = accesor.LoadAll();

        string jsonFilePath = "reservation.json";
        string json = File.ReadAllText(jsonFilePath);

    }

    public void ShowReservations()
    {
        foreach (var reservation in _reservations)
        {
            Console.WriteLine($"ROW: {reservation.Row}");
            Console.WriteLine($"SEAT: {reservation.Seat}");
            Console.WriteLine($"EMAILADDRESS: {reservation.EmailAddress}");
            Console.WriteLine($"MOVIE: {reservation.Movie}");
            Console.WriteLine($"START TIME: {reservation.StartTime}");
            Console.WriteLine($"DURATION: {reservation.Duration}");
        }
        

    }

    public void ModifyReservations()
    {
        accesor = new JsonAccessor<ReservationModel>(@"DataSources/reservation.json");
        _reservations = accesor.LoadAll();

        string jsonFilePath = "reservation.json";
        string json = File.ReadAllText(jsonFilePath);
        dynamic data = JsonSerializer.Deserialize<dynamic>(json);

        int row = Convert.ToInt32(Console.ReadLine());
        data["Row"] = row;

        string updatedJson = JsonSerializer.Serialize(data, new JsonSerializerOptions
        {
            WriteIndented = true,
            IgnoreNullValues = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        File.WriteAllText(jsonFilePath, updatedJson);



        // accesor = new JsonAccessor<ReservationModel>(@"DataSources/reservation.json");
        // _reservations = accesor.LoadAll();

        // string jsonFilePath = "reservation.json";
        // string json = File.ReadAllText(jsonFilePath);
        // MyClass data = JsonSerializer.Deserialize<MyClass>(json);

        // Console.WriteLine("Would you like to edit the full reservation?\nOr just a single thing?");
        // Console.WriteLine("Enter: everything/single");
        // string input = Console.ReadLine();
        // if (input == "single")
        // {
        //     Console.WriteLine("Would you like to modify: row, seat, emailaddress or movie?");
        //     string choice = Console.ReadLine();
        //     if (choice == "row")
        //     {
        //         Console.WriteLine("Enter new row:");
        //         int row = Convert.ToInt32(Console.ReadLine());
        //         File.WriteAllText("reservation.json", JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true }));
        //     }

        // }
    }

}

