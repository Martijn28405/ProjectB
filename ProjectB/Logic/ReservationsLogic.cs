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
    private int TotalPrice;
    public ReservationsLogic()
    {
        _accesor = new JsonAccessor<ReservationModel>(@"DataSources/reservation.json");
        _cartAccesor = new JsonAccessor<SeatsCartModel>(@"DataSources/SeatsCart.json");
        _reservations = _accesor.LoadAll();
        _carts = _cartAccesor.LoadAll();
    }
    public void ShowReservations()
    {
        foreach (var reservation in _reservations)
        {
            string seats = string.Join(",", reservation.Seat);
            Console.WriteLine($"SEATS: {seats}");
            Console.WriteLine($"EMAILADDRESS: {reservation.EmailAddress}");
            Console.WriteLine($"MOVIE: {reservation.Movie}");
            Console.WriteLine($"START TIME: {reservation.StartTime}");
            Console.WriteLine($"DURATION: {reservation.Duration}");
            return;
        }
        Console.WriteLine("There are no reservations at this moment\n");
    }
    /*public static void AddReservation()
    {
        foreach (var item in _carts)

        {

            EmailLogic.seats_list.Add(item.Seat.ToString());
        }
    }*/

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
        System.Console.WriteLine("Do you want to change another reservation? (y/n)");
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

    public void CreateReservation(List<ShoppingCartModel> shoppingCart)
    {
        List<string> seat = SeatMenu.selectedSeats;
        var email = UserLogin.User_Email;
        MoviesLogic moviesLogic = new MoviesLogic();
        string selectedMovie = MoviesLogic.SelectedMovie;
        Console.WriteLine(selectedMovie);
        int durationInput = 1;
        ReservationModel newReservation = new ReservationModel(seat, email, selectedMovie, MoviesLogic.startTimeInput, durationInput);
        SeatPricing();
        ProceedCheckout(shoppingCart, newReservation);

        Console.WriteLine("Return to Homepage");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey(true);
    }
    public void CreateReservation2(List<ShoppingCartModel> shoppingCart)
    {
        List<string> seat = SeatMenu2.selectedSeats;
        var email = UserLogin.User_Email;
        MoviesLogic moviesLogic = new MoviesLogic();
        string selectedMovie = MoviesLogic.SelectedMovie;
        Console.WriteLine(selectedMovie);
        int durationInput = 1;
        ReservationModel newReservation = new ReservationModel(seat, email, selectedMovie, MoviesLogic.startTimeInput, durationInput);
        SeatPricing2();
        ProceedCheckout(shoppingCart, newReservation);

        Console.WriteLine("Return to Homepage");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey(true);
    }
    public void CreateReservation3(List<ShoppingCartModel> shoppingCart)
    {
        List<string> seat = SeatMenu3.selectedSeats;
        var email = UserLogin.User_Email;
        MoviesLogic moviesLogic = new MoviesLogic();
        string selectedMovie = MoviesLogic.SelectedMovie;
        Console.WriteLine(selectedMovie);
        int durationInput = 1;
        ReservationModel newReservation = new ReservationModel(seat, email, selectedMovie, MoviesLogic.startTimeInput, durationInput);
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
        paymentLogic.FinalizeReservation();


    }

    public void SeatPricing()
    {
        List<string> colors = SeatMenu.selectedSeatsColor;
        foreach (var item in colors)
        {
            if (item == "[R]")
            {
                PaymentLogic.totalPrice += 20;
            }
            else if (item == "[G]")
            {
                PaymentLogic.totalPrice += 15;
            }
            else if (item == "[B]")
            {
                PaymentLogic.totalPrice += 10;
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
    public void SeatPricing2()
    {
        List<string> colors = SeatMenu2.selectedSeatsColor;
        foreach (var item in colors)
        {
            if (item == "[R]")
            {
                PaymentLogic.totalPrice += 20;
            }
            else if (item == "[G]")
            {
                PaymentLogic.totalPrice += 15;
            }
            else if (item == "[B]")
            {
                PaymentLogic.totalPrice += 10;
            }
        }

        MoviesLogic moviesLogic = new MoviesLogic();
        string selectedMovie = MoviesLogic.SelectedMovie;

        List<string> seat = SeatMenu2.selectedSeats;
        //send everything to the seatscart json
        SeatsCartModel newSeat = new SeatsCartModel(seat, selectedMovie, TotalPrice);
        JsonAccessor<SeatsCartModel> _accesor = new JsonAccessor<SeatsCartModel>(@"DataSources/SeatsCart.json");
        List<SeatsCartModel> _seatsCart = _accesor.LoadAll();
        _seatsCart.Add(newSeat);
        _accesor.WriteAll(_seatsCart);
    }
    public void SeatPricing3()
    {
        List<string> colors = SeatMenu3.selectedSeatsColor;
        foreach (var item in colors)
        {
            if (item == "[R]")
            {
                PaymentLogic.totalPrice += 20;
            }
            else if (item == "[G]")
            {
                PaymentLogic.totalPrice += 15;
            }
            else if (item == "[B]")
            {
                PaymentLogic.totalPrice += 10;
            }
        }

        MoviesLogic moviesLogic = new MoviesLogic();
        string selectedMovie = MoviesLogic.SelectedMovie;

        List<string> seat = SeatMenu3.selectedSeats;
        //send everything to the seatscart json
        SeatsCartModel newSeat = new SeatsCartModel(seat, selectedMovie, TotalPrice);
        JsonAccessor<SeatsCartModel> _accesor = new JsonAccessor<SeatsCartModel>(@"DataSources/SeatsCart.json");
        List<SeatsCartModel> _seatsCart = _accesor.LoadAll();
        _seatsCart.Add(newSeat);
        _accesor.WriteAll(_seatsCart);
    }
    public static void EmptySeatCarts()
    {
        _carts.Clear();
        _cartAccesor.WriteAll(_carts);

    }
    /*public void SendModifiedEmails()
    {
        
    }*/
}


