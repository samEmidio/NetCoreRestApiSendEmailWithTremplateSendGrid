using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using MimeKit;
using System;
using MailKit.Net.Smtp;
using NetCoreRestApiSendEmailWithTemplateSendGrid.Interface;

namespace NetCoreRestApiSendEmailWithTemplateSendGrid.Service
{
    public class SendEmailService : ISendEmail
    {
        private readonly IWebHostEnvironment iWebHostEnvironment;
        private readonly ISendGrid iSendGrid;
        public SendEmailService(IWebHostEnvironment iWebHostEnvironment, ISendGrid iSendGrid)
        {
            this.iSendGrid = iSendGrid;
            this.iWebHostEnvironment = iWebHostEnvironment;
        }
        public async Task sendEmail(string to, string subject, string title)
        {
            string pathTemplate = iWebHostEnvironment.WebRootPath +
            Path.DirectorySeparatorChar.ToString() +
            "EmailTemplates" +
            Path.DirectorySeparatorChar.ToString() +
            "emailTemplate1.html";
            Console.WriteLine(pathTemplate);

            var builder = new BodyBuilder();
            using (StreamReader SourceReader = System.IO.File.OpenText(pathTemplate))
            {
                builder.HtmlBody = SourceReader.ReadToEnd();
            }
            string messageBody = builder.HtmlBody;
            
            iSendGrid.sendEmail(to,"your email",subject,title,messageBody);

        }
    }
}