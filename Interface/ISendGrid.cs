using System.Threading.Tasks;

namespace NetCoreRestApiSendEmailWithTemplateSendGrid.Interface
{
    public interface ISendGrid
    {
          Task sendEmail(string to,string from, string subject,string title,string body);
    }
}