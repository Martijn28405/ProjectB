using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;



public class ReservationsLogic
{
    private JsonAccessor<ReservationModel> _accesor;
    public List<ReservationModel> _reservations;
    public ReservationsLogic()
    {
        _accesor = new JsonAccessor<ReservationModel>(@"DataSources/reservation.json");
        _reservations = _accesor.LoadAll();
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

    public void modifyReservations()
    {
        Console.WriteLine("From which movie would you like to edit the reservation?\n");
        Console.WriteLine("Enter movie:");
        string? movieInput = Console.ReadLine();
        Console.WriteLine("Enter e-mail:");
        string? EmailInput = Console.ReadLine();
        var filteredReservations = _reservations.Where(r => r.EmailAddress == EmailInput && r.Movie == movieInput);
        foreach (var reservation in filteredReservations)
        {
            Console.WriteLine($"ROW: {reservation.Row}");
            Console.WriteLine($"SEAT: {reservation.Seat}");
            Console.WriteLine($"EMAILADDRESS: {reservation.EmailAddress}");
            Console.WriteLine($"MOVIE: {reservation.Movie}");
            Console.WriteLine($"START TIME: {reservation.StartTime}");
            Console.WriteLine($"DURATION: {reservation.Duration}");

        }

        Console.WriteLine("What would you like to edit?");
        Console.WriteLine("Row, Seat, Email, Movie or Start Time");
        var inputEdit = Console.ReadLine();
        if (inputEdit == "Email")
        {
            Console.WriteLine("Enter the Email");
            string inputEmail = Console.ReadLine();
            foreach (var reservation in _reservations)
            {
                if (inputEmail == reservation.EmailAddress)
                {
                    _reservations.Remove(reservation);
                    _accesor.WriteAll(_reservations);
                    Console.WriteLine("Emailaddress deleted");
                    break;
                }
            }
        }



        // string input = Console.ReadLine();



        // vraag wat je wilt aanpassen
        // dit zoeken in de json
        // dit verwijderen
        // nieuwe vragen
        // dit toevoegen
    }
}


