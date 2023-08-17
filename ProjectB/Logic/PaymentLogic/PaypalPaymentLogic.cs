public class PaypalPaymentLogic : IPaymentLogic
{
    public void Payment(double price)
    {
        Console.WriteLine("Welcome to the login page of PayPal!");
        Console.WriteLine("Username: ");
        string username = Console.ReadLine();
        while (string.IsNullOrEmpty(username) || int.TryParse(username, out _))
        {
            Console.WriteLine("Invalid username. Please try again:");
            username = Console.ReadLine();
        }
        Console.WriteLine("Password (4 digits): ");
        string password = Console.ReadLine();
        while (string.IsNullOrEmpty(password) || password.Contains("-") || password.Length < 4 || password.Length > 4)
        {
            Console.WriteLine("Invalid password. Please try again:");
            password = Console.ReadLine();
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
