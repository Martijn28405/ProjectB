using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
public class ReservationsLogic
{
    private JsonAccessor<ReservationModel> accesor;
    public List<ReservationModel> _reservations;
    public ReservationsLogic()
    {
        accesor = new JsonAccessor<ReservationModel>(@"DataSources/reservation.json");
        _reservations = accesor.LoadAll();
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

}