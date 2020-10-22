using System;
using Microsoft.AspNetCore.Mvc;
using NetCoreRestApiSendEmailWithTemplateSendGrid.Interface;

namespace NetCoreRestApiSendEmailWithTemplateSendGrid.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class EmailController : ControllerBase
    {
        private readonly ISendEmail iSendEmail;

        public EmailController(ISendEmail iSendEmail)
        {
            this.iSendEmail = iSendEmail;

        }


        [HttpGet]
        public ActionResult sendEmail(string email)
        {

            if(email == null){
                return NoContent();
            }

            try{
                iSendEmail.sendEmail(email,"subject","title");
                return Ok();
            }catch(Exception){
                throw;
            }

        }

    }
}