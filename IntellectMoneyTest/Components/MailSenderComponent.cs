using IntellectMoneyTest.Facades;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace IntellectMoneyTest.Components
{
    public class MailSenderComponent
    {
        private const string _mailHostOfService = "XXXXXXXXXXXX";
        private const int _mailPortOfService = 0;
        private const string _mailOfService = "XXXXXXXXXXXX";
        private const string _mailPasswordOfService = "XXXXXXXXXX";

        public bool sendMailToUsername(string username, string subject, string messageText)
        {
            try
            {
                MailAddress from = new MailAddress(_mailOfService, "DoNotReply");
                MailAddress to = new MailAddress(username);
                MailMessage m = new MailMessage(from, to);
                m.Subject = subject;
                m.Body = messageText;
                m.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient(_mailHostOfService, _mailPortOfService);

                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(_mailOfService, _mailPasswordOfService);
                smtp.EnableSsl = true;

                smtp.Send(m);
                smtp.Dispose();

                System.Diagnostics.Debug.WriteLine("Сообщение " + username + " отправлено");

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception caught in threadMailSend(): {0}", ex.ToString());
                return false;
            }
        }
    }
}
