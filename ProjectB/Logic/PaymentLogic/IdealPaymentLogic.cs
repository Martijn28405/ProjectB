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
    public void Payment(decimal price)
    {
        Console.WriteLine("With which bank would you like to pay?\n[1] ABN AMBRO\n[2] ASN\n[3] ING\n[4] Knab\n[5] Rabobank\n[6] Regiobank\n[7] SNS\n[8] Triodos");
        int bankChoice = Convert.ToInt32(Console.ReadLine());
        if (Enum.IsDefined(typeof(Banks), bankChoice))
        {
            Console.WriteLine($"Welcome to the login page of {((Banks)bankChoice).ToString()}!");
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
}
