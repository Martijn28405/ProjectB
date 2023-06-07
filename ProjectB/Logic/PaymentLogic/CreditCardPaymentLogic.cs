using System.Globalization;
using System.Text.RegularExpressions;

public class CreditCardPaymentLogic : IPaymentLogic
{
    public void Payment(decimal price)
    {
        Console.WriteLine("Cardholder's name: ");
        string cardholderName = Console.ReadLine();

        int cardNumber;
        do
        {
            Console.WriteLine("Card number: ");
            cardNumber = Convert.ToInt32(Console.ReadLine());
        } while (!CreditCardNumber(cardNumber));

        string expiryDate;
        do
        {
            Console.WriteLine("Expiry date (mm/yyyy): "); 
            expiryDate = Console.ReadLine();
        } while (!CreditCardExpiryDate(expiryDate));


        int verificationCode;
        do
        {
            Console.WriteLine("3 digit card verification code: ");
            verificationCode = Convert.ToInt32(Console.ReadLine());
        } while (!CreditCardVerificationCode(verificationCode));

        Console.WriteLine($"Your credentials were correct, you've paid {price}.");
    }

    private bool CreditCardNumber(int cardNumber)
    {
        if (cardNumber.ToString().Length == 12)
        {
            return true;
        }
        Console.WriteLine("Invalid input");
        return false;
    }

    private bool CreditCardExpiryDate(string expiryDate)
    {
        if (!DateTime.TryParseExact(expiryDate, "MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                out DateTime expiryDateTime))
        {
            Console.WriteLine("Invalid input");
            return false;
        }
        if (expiryDateTime > DateTime.Now)
        {
            Console.WriteLine("Creditcard has been expired.");
            return false;
        }
        
        return true;
    }

    private bool CreditCardVerificationCode(int verificationCode)
    {
        if (verificationCode.ToString().Length == 3)
        {
            return true;
        }
        Console.WriteLine("Invalid input");
        return false;
    }
}

