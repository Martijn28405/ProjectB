using System;
using System.Net;
using System.Net.Mail;
[TestClass]
public class EmailLogicTests
{
    [TestMethod]
    public void SendEmail_ValidParameters_EmailSentSuccessfully()
    {
        // Arrange
        var emailLogic = new EmailLogic();
        var TestsmtpClient = new SmtpClient("smtp.gmail.com", 587)
        {
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("info.hetbioscoopje@gmail.com", "pqqlwfrqeplyfyll"),
            EnableSsl = true
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress("info.hetbioscoopje@gmail.com"),
            Subject = "Your Reservation at Het Bioscoopje",
            Body = "<h1>Dear Test User,\n" +
                   "Thank you for your reservation at Het Bioscoopje</h1>" +
                   "<h2>This email includes the tickets for Test Movie\n" +
                   "We will see you at the movie!</h2>",
            IsBodyHtml = true
        };
        mailMessage.To.Add("test@example.com");

        // Act
        emailLogic.SendReservationEmail();

        // Assert
        using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
        {
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("info.hetbioscoopje@gmail.com", "pqqlwfrqeplyfyll");
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
        }
    }
}