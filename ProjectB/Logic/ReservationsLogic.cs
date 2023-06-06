using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using ProjectB.DataModels;

public class ReservationsLogic
{
    private JsonAccessor<ReservationModel> _accesor;
    private JsonAccessor<SeatsCartModel> _cartAccesor;
    public List<SeatsCartModel> _carts;
    public List<ReservationModel> _reservations;
    public DateTime startTimeInput;
    public int TotalPrice;
    public ReservationsLogic()
    {
        _accesor = new JsonAccessor<ReservationModel>(@"DataSources/reservation.json");
        _reservations = _accesor.LoadAll();
        _carts = _cartAccesor.LoadAll();
    }
    public void ShowReservations()
    {
        foreach (var reservation in _reservations)
        {
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
            Console.WriteLine($"SEAT: {reservation.Seat}");
            Console.WriteLine($"EMAILADDRESS: {reservation.EmailAddress}");
            Console.WriteLine($"MOVIE: {reservation.Movie}");
            Console.WriteLine($"START TIME: {reservation.StartTime}");
            Console.WriteLine($"DURATION: {reservation.Duration}");
        }

        Console.WriteLine("What would you like to edit?");
        Console.WriteLine("1. Seat");
        Console.WriteLine("2. Email");
        Console.WriteLine("3. Movie");
        Console.WriteLine("4. Start time");
        Console.WriteLine("5. Duration");
        Console.WriteLine("6. Exit");
        string? input = Console.ReadLine();
        switch (input)
        {
            case "1":
                Console.WriteLine("Enter new seat:");
                List<string> seatInput = new List<string>();
                seatInput.Add(Console.ReadLine());
                foreach (var reservation in filteredReservations)
                {
                    reservation.Seat = seatInput;
                }
                break;
            case "2":
                Console.WriteLine("Enter new email:");
                string? emailInput = Console.ReadLine();
                foreach (var reservation in filteredReservations)
                {
                    reservation.EmailAddress = emailInput;
                }
                break;
            case "3":
                Console.WriteLine("Enter new movie:");
                string? movieInput2 = Console.ReadLine();
                foreach (var reservation in filteredReservations)
                {
                    reservation.Movie = movieInput2;
                }
                break;
            case "4":
                Console.WriteLine("Enter new start time:");
                DateTime startTimeInput = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                foreach (var reservation in filteredReservations)
                {
                    reservation.StartTime = startTimeInput;
                }

                break;
            case "5":
                Console.WriteLine("Enter new duration:");
                int durationInput = Int32.Parse(Console.ReadLine());
                foreach (var reservation in filteredReservations)
                {
                    reservation.Duration = durationInput;
                }
                break;
            case "6":
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
        List<string> seat = SeatMenu.selectedSeats;
        var email = UserLogin.User_Email;
        MoviesLogic moviesLogic = new MoviesLogic();
        string selectedMovie = MoviesLogic.SelectedMovie;
        Console.WriteLine(selectedMovie);
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
                startTimeInput = startingTimes[selectedTime - 1];

                durationInput = movie.PlayTimeInMinutes;
            }
        }
        ReservationModel newReservation = new ReservationModel(seat, email, selectedMovie, startTimeInput, durationInput);
        _reservations.Add(newReservation);
        _accesor.WriteAll(_reservations);
        Console.WriteLine("Reservation created");
        SeatPricing();
        EmailLogic sendemail = new EmailLogic();
        try
        {
            sendemail.SendReservationEmail(UserLogin.User_Email, UserLogin.User_Name, MoviesLogic.SelectedMovie, seat, startTimeInput, durationInput);
            Console.WriteLine("an email has been send to your account with further detail.");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
            AccountMenu.Start();
        }
        catch (Exception e)
        {
            Console.WriteLine("The email could not be send. But your reservation has been created.");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
            Program.Main();
        }

    }
    public void SeatPricing()
    {
        List<string> colors = SeatMenu.selectedSeatsColor;
        foreach (var item in colors)
        {
            if (item == "[R]")
            {
                TotalPrice += 20;
            }
            else if (item == "[Y]")
            {
                TotalPrice += 15;
            }
            else if (item == "[B]")
            {
                TotalPrice += 10;
            }
        }

        MoviesLogic moviesLogic = new MoviesLogic();
        string selectedMovie = MoviesLogic.SelectedMovie;

        List<string> seat = SeatMenu.selectedSeats;
        //send everything to the seatscart json
        SeatsCartModel newSeat = new SeatsCartModel(seat, selectedMovie, TotalPrice);
        JsonAccessor<SeatsCartModel> _accesor = new JsonAccessor<SeatsCartModel>(@"DataSources/SeatsCart.json");
        List<SeatsCartModel> _seatsCart = _accesor.LoadAll();
        _seatsCart.Add(newSeat);
        _accesor.WriteAll(_seatsCart);
    }
    /*public void SendModifiedEmails()
    {
        
    }*/
}


