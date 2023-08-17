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
    public static JsonAccessor<SeatsCartModel> _cartAccesor;
    public static List<SeatsCartModel> _carts;
    public List<ReservationModel> _reservations;

    public ReservationsLogic()
    {
        _accesor = new JsonAccessor<ReservationModel>(@"DataSources/reservation.json");
        _cartAccesor = new JsonAccessor<SeatsCartModel>(@"DataSources/SeatsCart.json");
        _reservations = _accesor.LoadAll();
        _carts = _cartAccesor.LoadAll();
    }

    public void ShowUserSeats()
    {
        foreach (var item in _carts)
        {
            if (item != null)
            {
                Console.WriteLine();
                Console.WriteLine($"SEAT(S): {string.Join(' ', item.Seat)}");
                Console.WriteLine($"SEATPRICE: {item.TotalPrice}");
            }
            else
            {
                Console.WriteLine("No reservations at the moment.");
            }
        }

    }

    public void ShowReservations()
    {
        if (_reservations.Count == 0)
        {
            Console.WriteLine("There are no reservations at this moment\n");
            return;
        }

        foreach (var reservation in _reservations)
        {
            string seats = string.Join(",", reservation.Seat);
            Console.WriteLine($"SEATS: {seats}");
            Console.WriteLine($"EMAILADDRESS: {reservation.EmailAddress}");
            Console.WriteLine($"MOVIE: {reservation.Movie}");
            Console.WriteLine($"START TIME: {reservation.StartTime}");
            Console.WriteLine($"DURATION: {reservation.Duration}");
            Console.WriteLine();
        }
    }

    public void modifyReservations()
    {
        ShowReservations();
        Console.WriteLine("From which movie would you like to edit the reservation?\n");
        Console.WriteLine("Enter movie:");
        List<string> moviesList = new();
        List<string> emailList = new();
        foreach (ReservationModel reservation in _reservations)
        {
            moviesList.Add(reservation.Movie);
            emailList.Add(reservation.EmailAddress);
            continue;
        }
        string? movieInput = Console.ReadLine();
        while (string.IsNullOrEmpty(movieInput) || int.TryParse(movieInput, out _) || movieInput == null || !moviesList.Contains(movieInput))
        {
            Console.WriteLine("Invalid input. Please try again, enter movie:");
            movieInput = Console.ReadLine();
        }

        Console.WriteLine("Enter e-mail:");
        string? EmailInput = Console.ReadLine();
        while (string.IsNullOrEmpty(EmailInput) || int.TryParse(EmailInput, out _) || EmailInput == null || !emailList.Contains(EmailInput))
        {
            Console.WriteLine("Invalid input. Please try again, enter e-mail:");
            EmailInput = Console.ReadLine();
        }

        var filteredReservations = _reservations.Where(r => r.EmailAddress == EmailInput && r.Movie == movieInput);
        foreach (var reservation in filteredReservations)
        {
            string seats = string.Join(",", reservation.Seat);
            Console.WriteLine($"SEAT: {seats}");
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
        while (string.IsNullOrEmpty(input) || !int.TryParse(input, out _) || (input != "1" && input != "2" && input != "3" && input != "4" && input != "5" && input != "6"))
        {
            Console.WriteLine("Invalid input. Please try again, What would you like to edit?");
            input = Console.ReadLine();
        }
        switch (input)
        {
            case "1":
                Console.WriteLine("Enter new row and seat:");
                List<string> seatInput = new List<string>();

                Console.WriteLine("Row:");
                int seatRow;
                while (!int.TryParse(Console.ReadLine(), out seatRow) || seatRow <= 0 || seatRow > 20)
                {
                    Console.WriteLine("Invalid input. Please enter a valid row:");
                }

                Console.WriteLine("Seat:");
                int seatChair;
                while (!int.TryParse(Console.ReadLine(), out seatChair) || seatChair <= 0 || seatChair > 600)
                {
                    Console.WriteLine("Invalid input. Please enter a valid seat:");
                }

                seatInput.Add($"Row: {seatRow} Seat: {seatChair}");
                foreach (var reservation in filteredReservations)
                {
                    reservation.Seat = seatInput;
                }
                break;

            case "2":
                Console.WriteLine("Enter new e-mail:");
                string? emailInput = Console.ReadLine();
                while (string.IsNullOrEmpty(emailInput) || int.TryParse(emailInput, out _) || !emailInput.Contains("@"))
                {
                    Console.WriteLine("Invalid input. Please enter a valid e-mail address:");
                    emailInput = Console.ReadLine();
                }
                foreach (var reservation in filteredReservations)
                {
                    reservation.EmailAddress = emailInput;
                }
                break;
            case "3":
                Console.WriteLine("Enter new movie:");
                string? newMovieInput = Console.ReadLine();
                while (string.IsNullOrEmpty(newMovieInput))
                {
                    Console.WriteLine("Invalid input. Please enter a valid movie:");
                    newMovieInput = Console.ReadLine();
                }
                foreach (var reservation in filteredReservations)
                {
                    reservation.Movie = newMovieInput;
                }
                break;
            case "4":
                Console.WriteLine("Enter new start time (example: 13/10/2023 15:30:00):");
                DateTime startTimeInput;
                while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out startTimeInput))
                {
                    Console.WriteLine("Invalid input. Please enter a valid start time in the format 'day/month/year hour:minute:second':");
                }
                foreach (var reservation in filteredReservations)
                {
                    reservation.StartTime = startTimeInput;
                }
                break;
            case "5":
                Console.WriteLine("Enter new duration:");
                int durationInput;
                while (!int.TryParse(Console.ReadLine(), out durationInput) || durationInput <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a valid duration:");
                }
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

        System.Console.WriteLine("Do you want to change another reservation? (y/n)");
        string? input2 = Console.ReadLine();
        if (input2 == "y")
        {
            modifyReservations();
        }
        else
        {
            if (ManagerLogin.Manager_Email == null)
            {
                _accesor.WriteAll(_reservations);
                CoWorkerMenu.Start();
            }
            _accesor.WriteAll(_reservations);
            ManagerMenu.Start();
        }
    }

    public void CreateReservation(List<ShoppingCartModel> shoppingCart)
    {
        List<string> seat = SeatMenu.selectedSeats;
        var email = "";
        if (UserLogin.User_Email == null)
        {
            email = GuestMenu.Guest_Email;
        }
        else
        {
            email = UserLogin.User_Email;
        }
        LogicBase moviesLogic = new LogicBase();
        string selectedMovie = LogicBase.SelectedMovie;
        Console.WriteLine(selectedMovie);
        int durationInput = LogicBase.duration;
        ReservationModel newReservation = new ReservationModel(seat, email, LogicBase.SelectedMovie, LogicBase.startTimeInput, durationInput);
        SeatPricing();
        ProceedCheckout(shoppingCart, newReservation);

        Console.WriteLine("Return to Homepage");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey(true);
    }
    public void CreateReservation2(List<ShoppingCartModel> shoppingCart)
    {
        List<string> seat = SeatMenu2.selectedSeats;
        var email = "";
        if (UserLogin.User_Email == null)
        {
            email = GuestMenu.Guest_Email;
        }
        else
        {
            email = UserLogin.User_Email;
        }
        LogicBase moviesLogic = new LogicBase();
        string selectedMovie = LogicBase.SelectedMovie;
        Console.WriteLine(selectedMovie);
        int durationInput = LogicBase.duration;
        ReservationModel newReservation = new ReservationModel(seat, email, LogicBase.SelectedMovie, LogicBase.startTimeInput, durationInput);
        SeatPricing2();
        ProceedCheckout(shoppingCart, newReservation);

        Console.WriteLine("Return to Homepage");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey(true);
    }

    public void CreateReservation3(List<ShoppingCartModel> shoppingCart)
    {
        List<string> seat = SeatMenu3.selectedSeats;
        var email = "";
        if (UserLogin.User_Email == null)
        {
            email = GuestMenu.Guest_Email;
        }
        else
        {
            email = UserLogin.User_Email;
        }
        LogicBase moviesLogic = new LogicBase();
        string selectedMovie = LogicBase.SelectedMovie;
        Console.WriteLine(selectedMovie);
        int durationInput = LogicBase.duration;
        ReservationModel newReservation = new ReservationModel(seat, email, LogicBase.SelectedMovie, LogicBase.startTimeInput, durationInput);
        SeatPricing3();
        ProceedCheckout(shoppingCart, newReservation);

        Console.WriteLine("Return to Homepage");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey(true);
    }

    private void ProceedCheckout(List<ShoppingCartModel> snacks, ReservationModel reservationModel)
    {
        PaymentLogic paymentLogic = new PaymentLogic();
        paymentLogic.CheckOut(_carts, snacks);
        _reservations.Add(reservationModel);
        _accesor.WriteAll(_reservations);
        _cartAccesor.WriteAll(new List<SeatsCartModel>());
        paymentLogic.FinalizeReservation();
    }

    public void SeatPricing()
    {
        List<string> colors = SeatMenu.selectedSeatsColor;
        int totalPrice = 0;
        foreach (var item in colors)
        {
            if (item == "[R]")
            {
                totalPrice += 20;
            }
            else if (item == "[G]")
            {
                totalPrice += 15;
            }
            else if (item == "[B]")
            {
                totalPrice += 10;
            }
        }

        MoviesLogic moviesLogic = new MoviesLogic();
        string selectedMovie = MoviesLogic.SelectedMovie;

        List<string> seat = SeatMenu.selectedSeats;
        // send everything to the seatscart.json
        SeatsCartModel newSeat = new SeatsCartModel(seat, selectedMovie, totalPrice);
        _carts = _cartAccesor.LoadAll();
        _carts.Add(newSeat);
        _cartAccesor.WriteAll(_carts);
    }
    public void SeatPricing2()
    {
        List<string> colors = SeatMenu2.selectedSeatsColor;
        int totalPrice = 0;
        foreach (var item in colors)
        {
            if (item == "[R]")
            {
                totalPrice += 20;
            }
            else if (item == "[G]")
            {
                totalPrice += 15;
            }
            else if (item == "[B]")
            {
                totalPrice += 10;
            }
        }

        MoviesLogic moviesLogic = new MoviesLogic();
        string selectedMovie = MoviesLogic.SelectedMovie;

        List<string> seat = SeatMenu2.selectedSeats;
        // send everything to the seatscart.json
        SeatsCartModel newSeat = new SeatsCartModel(seat, selectedMovie, totalPrice);
        _carts = _cartAccesor.LoadAll();
        _carts.Add(newSeat);
        _cartAccesor.WriteAll(_carts);
    }

    public void SeatPricing3()
    {
        List<string> colors = SeatMenu3.selectedSeatsColor;
        int totalPrice = 0;
        foreach (var item in colors)
        {
            if (item == "[R]")
            {
                totalPrice += 20;
            }
            else if (item == "[G]")
            {
                totalPrice += 15;
            }
            else if (item == "[B]")
            {
                totalPrice += 10;
            }
        }

        MoviesLogic moviesLogic = new MoviesLogic();
        string selectedMovie = MoviesLogic.SelectedMovie;

        List<string> seat = SeatMenu3.selectedSeats;
        // send everything to the seatscart.json
        SeatsCartModel newSeat = new SeatsCartModel(seat, selectedMovie, totalPrice);
        _carts = _cartAccesor.LoadAll();
        _carts.Add(newSeat);
        _cartAccesor.WriteAll(_carts);
    }

    public static void EmptySeatCarts()
    {
        _carts.Clear();
        _cartAccesor.WriteAll(_carts);
    }
}
