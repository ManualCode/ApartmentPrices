using MimeKit;
using MailKit.Net.Smtp;


namespace ApartmentPrices.Application.Services
{
    public class EmailService
    {
        public static async Task SendEmailAsync(string email, string subject, string data)
        {
            using var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("kirilltimohov", "kirilltimohov@yandex.ru"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = data
            };

            var client = new SmtpClient();
            await client.ConnectAsync("smtp.yandex.ru", 587, false);
            await client.AuthenticateAsync(Environment.GetEnvironmentVariable("SMTPEMAIL", EnvironmentVariableTarget.User),
                Environment.GetEnvironmentVariable("SMTPPASSWORD", EnvironmentVariableTarget.User));
            await client.SendAsync(emailMessage);

            await client.DisconnectAsync(true);

        }
    }
}
