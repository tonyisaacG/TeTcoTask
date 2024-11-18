using CleanArchitectureTask.Application.Interfaces.Services;
using CleanArchitectureTask.Infrastructure.Common;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace CleanArchitectureTask.Infrastructure.Services
{
    public class MailService : IMailService
    {
        private readonly ILogger<MailService> _logger;
        private readonly StmpSetting _stmpSetting;

        public MailService(ILogger<MailService> logger,IOptions<StmpSetting> StmpSettingConfigure)
        {
            _logger = logger;
            _stmpSetting = StmpSettingConfigure.Value;
        }
   

        public void SendMail(string body,string to,string title = null)
        {
            string smtpHost = _stmpSetting.Host;
            int smtpPort = _stmpSetting.Port;
            string smtpUser = _stmpSetting.Username;
            string smtpPassword = _stmpSetting.Password;
            string defaultFromEmail = _stmpSetting.FromEmail;

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(title ?? "Clean Architecture",defaultFromEmail));
            message.To.Add(new MailboxAddress(title ?? "Recipient",to));
            message.Subject = "Clean Architecture Test Notification";
            message.Body = new TextPart(TextFormat.Html) { Text = body };

            try
            {
                using var client = new SmtpClient();
                client.Connect(smtpHost,smtpPort,true);
                client.Authenticate(smtpUser,smtpPassword);
                client.Send(message);
                _logger.LogInformation("Email sent successfully to {Recipient}",to);
            }
            catch( Exception ex )
            {
                _logger.LogError(ex,"Failed to send email to {Recipient}",to);
                throw;
            }
        }
    }
}