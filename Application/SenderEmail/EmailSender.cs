using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Application.SenderEmail
{
    public class EmailSender
    {

        public static void Send(string to, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("nozhan.r1host.com", 587);
            mail.From = new MailAddress("Support@benevisim.com", "Benevisim");
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
  
           
            SmtpServer.Credentials = new System.Net.NetworkCredential("Support@benevisim.com", "Dehnamaki4652");
            SmtpServer.EnableSsl = false;

            SmtpServer.Send(mail);

        }




    }
}
