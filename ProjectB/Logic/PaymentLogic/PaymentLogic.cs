using ProjectB.DataModels;

public class PaymentLogic
{
    public static List<string> shopping_cart_list = new List<string>();
    public static List<string> seats_list = new List<string>();
    string shopping_cart = string.Join(",", shopping_cart_list);
    string seat = string.Join(",", seats_list);
    decimal totalPrice = 0;
    public static Random randomcode = new Random();
    private decimal ShowReceipt(List<SeatsCartModel> cart, List<ShoppingCartModel> snacks)
    {
        
        foreach (var seat in cart)
        {
            Console.WriteLine($"Seat(s): {string.Join(' ', seat.Seat)}");
            Console.WriteLine($"Total Price: {seat.TotalPrice}");
            Console.WriteLine($"Movie Title: {seat.MovieName}");
            totalPrice += (decimal)seat.TotalPrice;
        }

        foreach (var snack in snacks)
        {
            Console.WriteLine($"Snack: {snack.NameFood}");
            Console.WriteLine($"Amount: {snack.Amount}");
            Console.WriteLine($"Price: {snack.PriceFood}");
            totalPrice += (decimal)snack.PriceFood;
        }

        Console.WriteLine($"The total price of your shopping cart is {totalPrice}.");

        return totalPrice;
    }

    public void CheckOut(List<SeatsCartModel> cart, List<ShoppingCartModel> snacks)
    {
        var totalPrice = ShowReceipt(cart, snacks);
        int userInput = 0;
        while (userInput != 1 && userInput != 2)
        {
            Console.WriteLine("Do you want to checkout? \n[1] Yes\n[2] No");
            userInput = Convert.ToInt32(Console.ReadLine());
            if (userInput == 1)
            {
                Payment(totalPrice);
                return;
            }
            if (userInput == 2)
            {
                return;
            }
            Console.WriteLine("Invalid idnput");
        }
    }

    public void Payment(decimal price)
    {
        Console.WriteLine("Would you like to pay with:\n[1] iDeal\n[2] Creditcard\n[3] PayPal");
        string paymentChoice = Console.ReadLine();
        switch (paymentChoice)
        {
            case "1":
                IdealPaymentLogic idealPayment = new IdealPaymentLogic();
                idealPayment.Payment(price);
                break;
            case "2":
                CreditCardPaymentLogic creditcardPayment = new CreditCardPaymentLogic();
                creditcardPayment.Payment(price);
                break;
            case "3":
                PaypalPaymentLogic paypalPayment = new PaypalPaymentLogic();
                paypalPayment.Payment(price);
                break;
            default:
                Console.WriteLine("Invalid input, try again:");
                Payment(price);
                break;
        }
    }

    public void FinalizeReservation()
    {
        if (UserLogin.User_Email == null)
        {
            GuestPayment();
        }
        else
        {
            UserPayment();
        }
    }

    public void UserPayment()
    {
        Console.WriteLine("Your reservation has been made, you will receive an e-mail with the information.");
        EmailLogic sendemail = new EmailLogic();
        try
        {
            // seat, starttime en durationtime nog toevoegen.
            sendemail.SendReservationEmail(UserLogin.User_Email, MoviesLogic.SelectedMovie, seat, MoviesLogic.startTimeInput, totalPrice, randomcode.Next());
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
            GuestMenu.Start();
        }
        catch (Exception)
        {
            Console.WriteLine("The email could not be send. But your reservation has been created.");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
            GuestMenu.Start();
        }
    }

    public void GuestPayment()
    {
        Console.WriteLine("Your reservation has been made, you will receive an e-mail with the information.");
        EmailLogic sendemail = new EmailLogic();
        try
        {
            // seat, starttime en durationtime nog toevoegen.
            sendemail.SendReservationEmail(GuestMenu.Guest_Email, MoviesLogic.SelectedMovie, seat, MoviesLogic.startTimeInput, totalPrice, randomcode.Next());
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
            GuestMenu.Start();
        }
        catch (Exception)
        {
            Console.WriteLine("The email could not be send. But your reservation has been created.");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
            GuestMenu.Start();
        }
    }
}
