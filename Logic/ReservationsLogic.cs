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
        accesor = new JsonAccessor<ReservationModel>(@"DataSources/reservations.json");
        _reservations = accesor.LoadAll();
    }

    public void ShowReservations()
    {
        foreach (var reservation in _reservations)
        {
            Console.WriteLine($"WEEK: {reservation.Week}");
        }

    }

}