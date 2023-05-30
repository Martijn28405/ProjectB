using System.Net;
using System.Net.Mail;
using System.Net.Mime;

public class EmailLogic
{
    private ReservationsLogic modifier = new ReservationsLogic();
    public void SendReservationEmail()
    {
        var smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("info.hetbioscoopje@gmail.com", "pqqlwfrqeplyfyll");
            smtpClient.EnableSsl = true;

                var MailMessage = new MailMessage
            {
                From = new MailAddress("info.hetbioscoopje@gmail.com"),
                Subject = "Your Reservation at Het Bioscoopje",
                Body = $"<h1>Dear {UserLogin.User_Name},\n" +
                       "Thank you for your reservation at Het Bioscoopje</h1>" +
                       $"<h2>this email includes the tickets for {MoviesLogic.SelectedMovie} \n" +
                       "We will see you at the movie!</h2>",
                IsBodyHtml = true
            };
            MailMessage.To.Add(UserLogin.User_Email);
            smtpClient.Send(MailMessage);

    }
    public void SendModifiedMovieEmail()
    {
        var smtpClient = new SmtpClient("smtp.gmail.com", 587);
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new NetworkCredential("info.hetbioscoopje@gmail.com", "pqqlwfrqeplyfyll");
        smtpClient.EnableSsl = true; ;

        var MailMessage = new MailMessage
        {
            From = new MailAddress("info.hetbioscoopje@gmail.com"),
            Subject = "Your Reservation has been Modified",
            Body = $"<h1>Dear {UserLogin.User_Name},\n" +
                   "Your reservation has been Modified</h1>" +
                   $"<h2>You now reserved for {ReservationsLogic.new_movie}</h2>",
            IsBodyHtml = true
        };
        MailMessage.To.Add(UserLogin.User_Email);
        smtpClient.Send(MailMessage);

    }
    public void SendModifiedSeatEmail()
    {
        var smtpClient = new SmtpClient("smtp.gmail.com", 587);
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new NetworkCredential("info.hetbioscoopje@gmail.com", "pqqlwfrqeplyfyll");
        smtpClient.EnableSsl = true; ;

        var MailMessage = new MailMessage
        {
            From = new MailAddress("info.hetbioscoopje@gmail.com"),
            Subject = "Your Reservation has been Modified",
            Body = $"<h1>Dear {UserLogin.User_Name},\n" +
                   "Your reservation has been Modified</h1>" +
                   $"<h2>Your seat has changed to seat {ReservationsLogic.new_seat}</h2>",
            IsBodyHtml = true
        };
        MailMessage.To.Add(UserLogin.User_Email);
        smtpClient.Send(MailMessage);
    }
    public void SendModifiedEmail()
    {
        var smtpClient = new SmtpClient("smtp.gmail.com", 587);
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new NetworkCredential("info.hetbioscoopje@gmail.com", "pqqlwfrqeplyfyll");
        smtpClient.EnableSsl = true; ;

        var MailMessage = new MailMessage
        {
            From = new MailAddress("info.hetbioscoopje@gmail.com"),
            Subject = "Your Reservation has been Modified",
            Body = $"<h1>Dear {UserLogin.User_Name},\n" +
                   "Your reservation has been Modified</h1>" +
                   $"<h2>Your email has changed to {ReservationsLogic.new_email}</h2>",
            IsBodyHtml = true
        };
        MailMessage.To.Add(ReservationsLogic.new_email);
        smtpClient.Send(MailMessage);

    }

}