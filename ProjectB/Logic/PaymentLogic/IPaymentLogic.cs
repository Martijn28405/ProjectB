public interface IPaymentLogic
// this interface is used as a blueprint in IdealPaymentLog, CreditCardPaymentLogic and PayPalPaymentLogic.
{
    void Payment(double price);
}
