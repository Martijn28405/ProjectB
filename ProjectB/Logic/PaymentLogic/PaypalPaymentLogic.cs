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
        Console.WriteLine("Password: ");
        string password = Console.ReadLine();
        while (string.IsNullOrEmpty(password) || password.Contains("-"))
        {
            Console.WriteLine("Invalid password. Please try again:");
            password = Console.ReadLine();
        }
        if (username != null && password != null)
        {
            Console.WriteLine($"Your login was correct, you've paid {price} succesfully.");
            return;
        }

        Console.WriteLine("Login failed");
        Payment(price);
    }

}
