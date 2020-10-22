using System.Threading.Tasks;

namespace NetCoreRestApiSendEmailWithTemplateSendGrid.Interface
{
    public interface ISendEmail
    {
        Task sendEmail(string to, string subject,string title);
    }
}