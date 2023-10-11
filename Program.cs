using System;
using System.Net.Mail;

namespace TestScheduleMail
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("rsivakumarms@outlook.com");
                mail.To.Add("rsivakumarms@gmail.com");
                mail.Subject = "Test";
                mail.Body = "This is test mail frim siva";
                mail.IsBodyHtml = true;

                using (SmtpClient smpt = new SmtpClient("smtp.office365.com", 587))
                {
                    smpt.UseDefaultCredentials = false;
                    smpt.Credentials = new System.Net.NetworkCredential("rsivakumarms@outlook.com", "WelcomeAswath01");
                    smpt.EnableSsl = true;
                    smpt.Send(mail);
                    // smpt.Send(mail);

                }
            }

            //new SmtpClient("smtp.server.com", 25).send("from@email.com",
            //                               "to@email.com",
            //                               "subject",
            //                               "body");

            //Console.WriteLine("Mail To");
            //MailAddress to = new MailAddress(Console.ReadLine());

            //Console.WriteLine("Mail From");
            //MailAddress from = new MailAddress(Console.ReadLine());

            //MailMessage mail = new MailMessage(from, to);

            //Console.WriteLine("Subject");
            //mail.Subject = Console.ReadLine();

            //Console.WriteLine("Your Message");
            //mail.Body = Console.ReadLine();

            //SmtpClient smtp = new SmtpClient();
            //smtp.Host = "smtp.mail.yahoo.com";
            //smtp.Port = 587;

            //smtp.Credentials = new NetworkCredential(
            //    "rsivakumarms@yahoo.com", "Chennai@01");
            //smtp.EnableSsl = true;

            //smtp.UseDefaultCredentials = false;
            //Console.WriteLine("Sending email...");
            //smtp.Send(mail);

            var smtp = new SmtpClient
            {
                Host = "smtp.mail.yahoo.com",
                Port = 587,
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false, // Credentials = new NetworkCredential(senderEmail.Address, password)
            };





            try
            {
                SmtpClient mySmtpClient = new SmtpClient("smtp.mail.yahoo.com");

                // set smtp-client with basicAuthentication
                mySmtpClient.Port = 587;
                mySmtpClient.EnableSsl = false;
                mySmtpClient.UseDefaultCredentials = true;
                System.Net.NetworkCredential basicAuthenticationInfo = new
                   System.Net.NetworkCredential("rsivakumarms@yahoo.com", "Chennai@01");
                mySmtpClient.Credentials = basicAuthenticationInfo;

                // add from,to mailaddresses
                MailAddress from = new MailAddress("rsivakumarms@yahoo.com", "Sivakumar");
                MailAddress to = new MailAddress("rsivakumarms@yahoo.com", "SK");
                MailMessage myMail = new System.Net.Mail.MailMessage(from, to);

                // add ReplyTo
                //MailAddress replyTo = new MailAddress("reply@example.com");
                //myMail.ReplyToList.Add(replyTo);

                // set subject and encoding
                myMail.Subject = "Test message";
                myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                // set body-message and encoding
                myMail.Body = "<b>Test Mail</b><br>using <b>HTML</b>.";
                myMail.BodyEncoding = System.Text.Encoding.UTF8;
                // text or html
                myMail.IsBodyHtml = true;

                mySmtpClient.Send(myMail);
            }

            catch (SmtpException ex)
            {
                throw new ApplicationException("SmtpException has occured: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
