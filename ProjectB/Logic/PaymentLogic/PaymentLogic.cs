using ProjectB.DataModels;

public class PaymentLogic
// This file is used for the methods surrounding payments like showing the receipts and finalizing the payment.
{
    public static List<string> shopping_cart_list = new List<string>();
    public static List<string> seats_list = new List<string>();
    string shopping_cart = string.Join(",", shopping_cart_list);

    public static double totalPrice = 0;
    public static Random randomcode = new Random();
    public static Dictionary<string, int> snackDict = new();

    private double ShowReceipt(List<SeatsCartModel> cart, List<ShoppingCartModel> snacks)
    {

        foreach (var seat in cart)
        {
            Console.WriteLine($"Seat(s): {string.Join(' ', seat.Seat)}");
            Console.WriteLine($"Total Price: {seat.TotalPrice}");
            totalPrice = seat.TotalPrice;
        }

        foreach (var snack in snacks)
        {
            Console.WriteLine($"Snack: {snack.NameFood}");
            Console.WriteLine($"Amount: {snack.Amount}");
            Console.WriteLine($"Price: {snack.PriceFood}");
            double totalSnackPrice = snack.Amount * snack.PriceFood;
            totalPrice += totalSnackPrice;
        }

        Console.WriteLine($"The total price of your shopping cart is {totalPrice}.");
        cart.Clear();
        return totalPrice;
    }

    public void CheckOut(List<SeatsCartModel> cart, List<ShoppingCartModel> snacks)
    {
        var totalPrice = ShowReceipt(cart, snacks);
        int userInput = 0;
        while (userInput != 1 && userInput != 2)
        {
            Console.WriteLine("Do you want to checkout? \n[1] Yes\n[2] No");
            while (!int.TryParse(Console.ReadLine(), out userInput) || (userInput != 1 && userInput != 2))
            {
                Console.WriteLine("Invalid input. Please try again:");
            }
            if (userInput == 1)
            {
                Payment(totalPrice);
                return;
            }
            if (userInput == 2)
            {
                if (UserLogin.User_Email == null)
                {
                    GuestMenu.Start();
                    return;
                }
                else
                {
                    AccountMenu.Start();
                    return;
                }
            }
            Console.WriteLine("Invalid input");
        }
    }

    public void Payment(double price)
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
            FinalPayment(GuestMenu.Guest_Email, GuestMenu.Start);
        }
        else
        {
            FinalPayment(UserLogin.User_Email, AccountMenu.Start);
        }
    }

    public void FinalPayment(string userEmail, Action nextMenu)
    {
        Console.WriteLine("Your reservation has been made, you will receive an e-mail with the information.");
        EmailLogic sendemail = new EmailLogic();
        try
        {
            string seat = string.Join(",", seats_list);
            sendemail.SendReservationEmail(userEmail, LogicBase.SelectedMovie, seat, LogicBase.startTimeInput, totalPrice, randomcode.Next());
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
            nextMenu();
        }
        catch (Exception)
        {
            Console.WriteLine("The email could not be sent. But your reservation has been created.");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
            nextMenu();
        }
    }

    public void FinalPayment()
    {
        if (UserLogin.User_Email == null)
        {
            FinalPayment(GuestMenu.Guest_Email, GuestMenu.Start);
        }
        else
        {
            FinalPayment(UserLogin.User_Email, AccountMenu.Start);
        }
    }

}
