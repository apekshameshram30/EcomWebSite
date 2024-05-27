using Application.Interface;
using Domain.Entity;
using MimeKit;

namespace Web.Implementation
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailService(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public void SendEmailAsync(string _emailTo, string _name, string _username, string _password)
        {
            var emailSend = CreateMessage( _emailTo,  _name,  _username,  _password);

            Send(emailSend);
        }

        #region Private Methods

        private MimeMessage CreateMessage(string _emailTo, string _name, string _username, string _password)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", _emailConfig.From));
            emailMessage.To.Add(MailboxAddress.Parse(_emailTo));
            emailMessage.Subject= "Welcome! Credentials for Login!!";       
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = $"Username - {_username}, password - {_password}"
            };
            return emailMessage;
        }

       
        private void Send(MimeMessage mailMessage)
        {
            using var client = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                var port = int.Parse(_emailConfig.Port);
                client.Connect(_emailConfig.SmtpServer, port, true);

                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailConfig.UserName, _emailConfig.Password);

                client.Send(mailMessage);
            }
            catch
            {
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();

            }
        }
        #endregion
    }
}
