using ProjectB.DataModels;

public class PaymentLogic
{

    public static List<string> shopping_cart_list = new List<string>();
    public static List<string> seats_list = new List<string>();
    string shopping_cart = string.Join(",", shopping_cart_list);
    string seat = string.Join(",", seats_list);
    public static double totalPrice = 0;
    public static Random randomcode = new Random();
    private double ShowReceipt(List<SeatsCartModel> cart, List<ShoppingCartModel> snacks)
    {

        foreach (var seat in cart)
        {
            Console.WriteLine($"Seat(s): {string.Join(' ', seat.Seat)}");
            Console.WriteLine("Seats" + seat.Seat);
            Console.WriteLine($"Total Price: {seat.TotalPrice}");
            totalPrice += seat.TotalPrice;
        }

        foreach (var snack in snacks)
        {
            Console.WriteLine($"Snack: {snack.NameFood}");
            Console.WriteLine($"Amount: {snack.Amount}");
            Console.WriteLine($"Price: {snack.PriceFood}");
            totalPrice += snack.PriceFood;
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
                AccountMenu.Start();
                return;
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
            // seat, starttime en durationtime nog toevoegen.
            sendemail.SendReservationEmail(userEmail, MoviesLogic.SelectedMovie, seat, MoviesLogic.startTimeInput, totalPrice, randomcode.Next());
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
    // public void GenerateEmailTemplate(List<SeatsCartModel> cart, List<ShoppingCartModel> snacks, List<ShoppingCartModel> shoppingCart)
    // {
    //     // Manually populate the shopping_cart_list with the required shopping cart items
    //     foreach (var item in shoppingCart)
    //     {
    //         // Assuming the ShoppingCartModel has a property like 'Name' or 'Description' that represents the item
    //         shopping_cart_list.Add(item.NameFood); // Change 'item.Name' to the appropriate property representing the item
    //     }

    //     string shopping_cart = string.Join(", ", shopping_cart_list); // Now, you can join the items in the shopping_cart_list

    //     // Now you can generate the email template
    //     string htmlBody = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Strict//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\">\n";
    //     htmlBody += "<html>\n";
    //     // ... Rest of your email template code ...

    //     // Use the populated shopping_cart to display in the email template
    //     htmlBody += $"<h3 align=\"center\">Shopping cart items: {shopping_cart}</h3>\n";
    //     // ... Continue with the rest of your email template ...

    //     htmlBody += "</html>";
    //     // Send the email using the htmlBody
    // }
}
