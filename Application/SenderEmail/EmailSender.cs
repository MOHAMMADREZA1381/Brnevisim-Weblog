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
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("mohammadrza1381@gmail.com", "Benevisim");
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
  
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("mohammadrza1381@gmail.com", "jdlh xilv eave yzok");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }




    }
}
