using CleanArchitectureTask.Application.Interfaces.Services;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;

namespace CleanArchitectureTask.Infrastructure.Services
{
    public class MailService : IMailService
    {
        public void SendMail(string body,string To,string title = null)
        {

            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress(title,"CleanArchCQRs@gmail.com"));
            message.To.Add(new MailboxAddress(title ?? "Clean Architecture",To));
            message.Subject = "Clean Architecture Test Notification";
            message.Body = new TextPart(TextFormat.Html) { Text = body };
            SmtpClient client = new SmtpClient();
            try
            {
                client.Connect("smtp.gmail.com",465,true);
                client.Authenticate("CleanArchCQRs@gmail.com","peampqqpvsdybrhq");
                var s = client.Send(message);
            }
            catch( Exception ex )
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}
