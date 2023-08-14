public class IdealPaymentLogic : IPaymentLogic
{
    public enum Banks
    {
        ABNAMBRO = 1,
        ASN,
        ING,
        Knab,
        Rabobank,
        Regiobank,
        SNS,
        Triodos
    }
    public void Payment(double price)
    {
        Console.WriteLine("With which bank would you like to pay?\n[1] ABN AMBRO\n[2] ASN\n[3] ING\n[4] Knab\n[5] Rabobank\n[6] Regiobank\n[7] SNS\n[8] Triodos");
        int bankChoice;
        while (!int.TryParse(Console.ReadLine(), out bankChoice) || bankChoice < 1 || bankChoice > 8)
        {
            Console.WriteLine("Invalid input. Please try again:");
        }

        if (Enum.IsDefined(typeof(Banks), bankChoice))
        {
            Console.WriteLine($"Welcome to the login page of {((Banks)bankChoice).ToString()}!");
            Console.WriteLine("Username: ");
            string username = Console.ReadLine();
            while (string.IsNullOrEmpty(username) || int.TryParse(username, out _))
            {
                Console.WriteLine("Invalid input. Please try again:");
                username = Console.ReadLine();
            }
            Console.WriteLine("Please enter a four digit password: ");
            int password;
            while (true)
            {
                if(!int.TryParse(Console.ReadLine(), out password) || password < 0 || password.ToString().Length != 4)
                {
                    Console.WriteLine("Invalid input. Please try again:");
                }
                else
                {
                    break;
                }
            }

            if (username != null && password != null)
            {
                Console.WriteLine($"Your login was correct, you've paid {price} succesfully.");
                ReservationsLogic.EmptySeatCarts();
                SnacksLogic shoppingcartempty = new SnacksLogic();
                shoppingcartempty.EmptyShoppingCart();
                return;

            }

            Console.WriteLine("Login failed");
            Payment(price);
        }
    }
}
