using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NetCoreRestApiSendEmailWithTemplateSendGrid.Interface;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace NetCoreRestApiSendEmailWithTemplateSendGrid.Service
{
    public class SendGridService : ISendGrid
    {
        private readonly IConfiguration _configuration;
        public SendGridService(IConfiguration _configuration)
        {
            this._configuration = _configuration;
        }

        public async Task sendEmail(string to, string from,string subject,string title ,string body)
        {
            var apiKey = _configuration["send_grid_api_key"];
            var client = new SendGridClient(apiKey);
            var _from = new EmailAddress(from, title);
            var sub = subject;
            var _to = new EmailAddress(to, "email name");
            var plainTextContent = "";
            var msg = MailHelper.CreateSingleEmail(_from, _to, subject, plainTextContent, body);
            var response = await client.SendEmailAsync(msg);
        }
    }
}