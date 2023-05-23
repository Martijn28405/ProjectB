using System.Net;
using System.Net.Mail;
using System.Net.Mime;

public class EmailLogic
{
    public void SendEmail()
    {
        ReservationsLogic newReservationsLogic = new ReservationsLogic();
        try
        {
            var smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("info.hetbioscoopje@gmail.com", "pqqlwfrqeplyfyll");
            smtpClient.EnableSsl = true; ;

                var MailMessage = new MailMessage
            {
                From = new MailAddress("info.hetbioscoopje@gmail.com"),
                Subject = "Your Reservation at Het Bioscoopje",
                Body = $"<h1>Dear {UserLogin.User_Name},\n" +
                       "Thank you for your reservation at Het Bioscoopje</h1>" +
                       $"<h2>this email includes the tickets for {MoviesLogic.SelectedMovie} \n"+
                       "We will see you at the movie!</h2>",
                IsBodyHtml = true
            };
            MailMessage.To.Add(UserLogin.User_Email);
            smtpClient.Send(MailMessage);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
            
        }
        

    }
}