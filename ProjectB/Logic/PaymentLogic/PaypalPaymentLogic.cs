public class PaypalPaymentLogic : IPaymentLogic
{
    public void Payment(double price)
    {
        Console.WriteLine("Welcome to the login page of PayPal!");
        Console.WriteLine("Username: ");
        string username = Console.ReadLine();
        Console.WriteLine("Password: ");
        string password = Console.ReadLine();
        if (username != null && password != null)
        {
            Console.WriteLine($"Your login was correct, you've paid {price} succesfully.");
            return;
        }

        Console.WriteLine("Login failed");
        Payment(price);
    }
}
