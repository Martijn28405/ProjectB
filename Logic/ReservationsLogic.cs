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
    public DateTime startTimeInput;
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
        Console.WriteLine("1. Row");
        Console.WriteLine("2. Seat");
        Console.WriteLine("3. Email");
        Console.WriteLine("4. Movie");
        Console.WriteLine("5. Start time");
        Console.WriteLine("6. Duration");
        Console.WriteLine("7. Exit");
        string? input = Console.ReadLine();
        switch (input)
        {
            case "1":
                Console.WriteLine("Enter new row:");
                int rowInput = Int32.Parse(Console.ReadLine());
                foreach (var reservation in filteredReservations)
                {
                    reservation.Row = rowInput;
                }
                break;
            case "2":
                Console.WriteLine("Enter new seat:");
                int seatInput = Int32.Parse(Console.ReadLine());
                foreach (var reservation in filteredReservations)
                {
                    reservation.Seat = seatInput;
                }
                break;
            case "3":
                Console.WriteLine("Enter new email:");
                string? emailInput = Console.ReadLine();
                foreach (var reservation in filteredReservations)
                {
                    reservation.EmailAddress = emailInput;
                }
                break;
            case "4":
                Console.WriteLine("Enter new movie:");
                string? movieInput2 = Console.ReadLine();
                foreach (var reservation in filteredReservations)
                {
                    reservation.Movie = movieInput2;
                }
                break;
            case "5":

                break;
            case "6":
                Console.WriteLine("Enter new duration:");
                int durationInput = Int32.Parse(Console.ReadLine());
                foreach (var reservation in filteredReservations)
                {
                    reservation.Duration = durationInput;
                }
                break;
            case "7":
                break;
            default:
                Console.WriteLine("Invalid input");
                break;
        }
        System.Console.WriteLine("Dop you want to change another reservation? (y/n)");
        string? input2 = Console.ReadLine();
        if (input2 == "y")
        {
            modifyReservations();
        }
        else
        {
            _accesor.WriteAll(_reservations);
            ManagerMenu.Start();
        }

        // string input = Console.ReadLine();



        // vraag wat je wilt aanpassen
        // dit zoeken in de json
        // dit verwijderen
        // nieuwe vragen
        // dit toevoegen
    }

    public void CreateReservation()
    {
        //get the row from the seatmenu
        SeatMenu seatMenu = new SeatMenu();
        int row = SeatMenu.row;
        //get the seat from the seatmenu
        int seat = SeatMenu.col;
        //get the emailaddress from the user
        var email = UserLogin.User_Email;
        // get the selected movie from movieslogic
        MoviesLogic moviesLogic = new MoviesLogic();
        string selectedMovie = MoviesLogic.SelectedMovie;
        Console.WriteLine(selectedMovie);
        // get the start time and duration from the selected movie out of the json
        int durationInput = 1;
        foreach (var movie in moviesLogic.movies)
        {
            if (movie.MovieTitle == selectedMovie)
            {
                //create a list of starting times and let the user select one
                List<DateTime> startingTimes = new List<DateTime>();
                foreach (var time in movie.StartTime)
                {
                    startingTimes.Add(time);
                }
                // int selectedTime = Int32.Parse(Console.ReadLine());
                // startTimeInput = selectedTime;
                //get the duration of the movie
                Console.WriteLine("Which time would you like to reserve?");
                int y = 1;
                foreach (var x in startingTimes)
                {
                    Console.WriteLine($"[{y}]. {x}");
                    y++;
                }
                //Let the user choose one of the times and put the selected time in startTimeInput
                int selectedTime = Int32.Parse(Console.ReadLine());
                startTimeInput = startingTimes[selectedTime - -1];

                durationInput = movie.PlayTimeInMinutes;
            }
        }
        ReservationModel newReservation = new ReservationModel(row, seat, email, selectedMovie, startTimeInput, durationInput);
        _reservations.Add(newReservation);
        _accesor.WriteAll(_reservations);
        Console.WriteLine("Reservation created");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        Program.Main();
    }
}


