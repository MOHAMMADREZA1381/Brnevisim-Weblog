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
            //mail.Body = "<body>\r\n    <!-- شوع آن -->\r\n    <div style=\"margin-top: 50px;\">\r\n        <table cellpadding=\"0\" cellspacing=\"0\" style=\"direction: rtl; text-align: right; font-family: IRANSansfanum; font-size: 15px; font-weight: 400; max-width: 600px; border: none; margin: 0 auto; border-radius: 6px; overflow: hidden; background-color: #fff; box-shadow: 0 0 3px rgba(60, 72, 88, 0.15);\">\r\n            <thead>\r\n                <tr style=\"background-color: #000000; padding: 3px 0; border: none; line-height: 68px; text-align: center; color: #fff; font-size: 24px; letter-spacing: 1px;\">\r\n                    <th scope=\"col\"><img src=\"images/Logo.png\" height=\"24\" alt=\"\"></th>\r\n                </tr>\r\n            </thead>\r\n\r\n            <tbody>\r\n                <tr>\r\n                    <td style=\"padding: 48px 24px 0; color: #161c2d; font-size: 18px; font-weight: 600;\">\r\n                         @Model.UserName سلام\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n                    <td style=\"padding: 15px 24px 15px; color: #8492a6;\">\r\n                        با تشکر برای ایجاد یک حساب لندریک . برای ادامه ، لطفا با کلیک روی دکمه زیر آدرس ایمیل خود را تأیید کنید :\r\n                    </td>\r\n                </tr>\r\n\r\n                <tr>\r\n                    <td style=\"padding: 15px 24px;\">\r\n                        <a asp-area=\"\" asp-controller=\"Account\" asp-action=\"ActiveAccount\" asp-route-ActivateCode=\"@Model.ActiveCode\" style=\"padding: 8px 20px; outline: none; text-decoration: none; font-size: 16px; letter-spacing: 0.5px; transition: all 0.3s; font-weight: 600; border-radius: 6px; background-color: #2f55d4; border: 1px solid #2f55d4; color: #ffffff;\">تایید آدرس ایمیل</a>\r\n                    </td>\r\n                </tr>\r\n\r\n                <tr>\r\n                    <td style=\"padding: 15px 24px 0; color: #8492a6;\">\r\n                        این پیوند از زمان ارسال این ایمیل به مدت 30 دقیقه فعال خواهد بود.\r\n                    </td>\r\n                </tr>\r\n\r\n                <tr>\r\n                    <td style=\"padding: 15px 24px 15px; color: #8492a6;\">\r\n                        لندریک <br> تیم پشتیبان\r\n                    </td>\r\n                </tr>\r\n\r\n                <tr>\r\n                    <td style=\"padding: 16px 8px; color: #8492a6; background-color: #f8f9fc; text-align: center;\">\r\n                        © <script>document.write(new Date().getFullYear())</script>2024 لندریک.\r\n                    </td>\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n    <!-- پایان آن -->\r\n\r\n\r\n</body>";
            mail.Body = body;
            mail.IsBodyHtml = true;
            //System.Net.Mail.Attachment attachment;
            //System.Net.Mail.Attachment attachment;
            // attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
            // mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("mohammadrza1381@gmail.com", "jdlh xilv eave yzok");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }




    }
}
