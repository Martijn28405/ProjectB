using System.Globalization;
using System.Text.RegularExpressions;

public class CreditCardPaymentLogic : IPaymentLogic
{
    public void Payment(double price)
    {
        string cardholderName;
        while(true)
        {
            Console.WriteLine("Cardholder's name: ");
            cardholderName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(cardholderName) || int.TryParse(cardholderName, out _))
            {
                Console.WriteLine("Invalid input. Please enter a valid cardholder's name.");
            }
            else
            {
                break;
            }

        }
        long cardNumber;
        while (true)
        {
            Console.WriteLine("Card number (16 digits): ");
            if (!long.TryParse(Console.ReadLine(), out cardNumber))
            {
                Console.WriteLine("Invalid input. Please enter a valid card number.");
            }
            else if (CreditCardNumber(cardNumber))
            {
                break;
            }
        }
        string expiryDate;
        while(true)
        {
            Console.WriteLine("Expiry date (mm/yyyy): ");
            expiryDate = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(expiryDate) || !CreditCardExpiryDate(expiryDate))
            {
                Console.WriteLine("Invalid input. Please enter a valid expiry date.");
            }
            else
            {
                break;
            }
        }
        while(true)
        {
            Console.WriteLine("3 digit card verification code: ");
            int verificationCode;
            if (!int.TryParse(Console.ReadLine(), out verificationCode))
            {
                Console.WriteLine("Invalid input. Please enter a valid verification code.");
            }
            else if (CreditCardVerificationCode(verificationCode))
            {
                break;
            }
        }
        Console.WriteLine($"Your credentials were correct, you've paid {price}.");
        ReservationsLogic.EmptySeatCarts();
        SnacksLogic shoppingcartempty = new SnacksLogic();
        shoppingcartempty.EmptyShoppingCart();
        return;
    }

    private bool CreditCardNumber(long cardNumber)
    {
        if (cardNumber.ToString().Length == 16)
        {
            return true;
        }
        Console.WriteLine("Invalid input. Please enter a valid card number.");
        return false;
    }

    private bool CreditCardExpiryDate(string expiryDate)
    {
        if (!DateTime.TryParseExact(expiryDate, "MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                out DateTime expiryDateTime))
        {
            return false;
        }
        if (expiryDateTime < DateTime.Now)
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
        Console.WriteLine("Invalid input. Please enter a valid verification code.");
        return false;
    }
}
