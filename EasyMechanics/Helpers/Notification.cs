using System.Net;
using System.Net.Mail;

namespace EasyMachanics.Extensions
{
    public class Notification
    {
        /// <summary>
        /// Створюємо о'єкт для відправки повідомлення
        /// </summary>
        /// <param name="SenderName">і'мя відправника</param>
        /// <param name="SenderEmail">адреса відправника</param>
        /// <param name="SenderPassword">пароль відправника</param>
        /// <param name="ReceiverEmail">адреса отримувача</param>
        /// <param name="Subject">тема повідомлення</param>
        /// <param name="Body">тіло листа в форматі (підтримує HTML)</param>
        /// <param name="SMTPHost">хост смтп сервера (напр smtp.mail.ru)</param>
        /// <param name="SMTPPort">порт SMTP сервера</param>
        public Notification(string SenderName, string SenderEmail, string SenderPassword, string ReceiverEmail, string Subject, string Body, string SMTPHost, int SMTPPort)
        {
            this.SenderName = SenderName;
            this.SenderEmail = SenderEmail;
            this.SenderPassword = SenderPassword;
            this.ReceiverEmail = ReceiverEmail;
            this.Subject = Subject;
            this.Body = Body;
            this.SMTPHost = SMTPHost;
            this.SMTPPort = SMTPPort;
        }

        /// <summary>
        /// Створюємо о'єкт для відправки повідомлення (хост за замовчування: smtp.mail.ru порт за замовчуванням: 587)
        /// </summary>
        /// <param name="SenderName">і'мя відправника</param>
        /// <param name="SenderEmail">адреса відправника</param>
        /// <param name="SenderPassword">пароль відправника</param>
        /// <param name="ReceiverEmail">адреса отримувача</param>
        /// <param name="Subject">тема повідомлення</param>
        /// <param name="Body">тіло листа в форматі (підтримує HTML)</param>
        public Notification(string SenderName, string SenderEmail, string SenderPassword, string ReceiverEmail, string Subject, string Body)
        {
            this.SenderName = SenderName;
            this.SenderEmail = SenderEmail;
            this.SenderPassword = SenderPassword;
            this.ReceiverEmail = ReceiverEmail;
            this.Subject = Subject;
            this.Body = Body;
            this.SMTPHost = "smtp.mail.ru";
            this.SMTPPort = 587;
        }
        /// <summary>
        /// Створюємо о'єкт для відправки повідомлення (хост за замовчування: smtp.mail.ru порт за замовчуванням: 587)
        /// </summary>
        /// <param name="SenderName">і'мя відправника</param>
        /// <param name="SenderEmail">адреса відправника</param>
        /// <param name="SenderPassword">пароль відправника</param>
        /// <param name="ReceiverEmail">адреса отримувача</param>
        /// <param name="Body">тіло листа в форматі (підтримує HTML)</param>
        public Notification(string SenderName, string SenderEmail, string SenderPassword, string ReceiverEmail, string Body)
        {
            this.SenderName = SenderName;
            this.SenderEmail = SenderEmail;
            this.SenderPassword = SenderPassword;
            this.ReceiverEmail = ReceiverEmail;
            this.Subject = "new message";
            this.Body = Body;
            this.SMTPHost = "smtp.mail.ru";
            this.SMTPPort = 587;
        }



        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string SenderPassword { get; set; }
        public string ReceiverEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string SMTPHost { get; set; }
        public int SMTPPort { get; set; }

        public void SendMessage()
        {
            var message = new MailMessage(this.SenderEmail, ReceiverEmail);
            message.Subject = Subject; //тема листа
            message.Body = Body; // тіло лста
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = SenderEmail,  // емейл з якого відсилаєм
                    Password = SenderPassword  // пароль до емейлу з якого відсилаєм
                };
                smtp.Credentials = credential;
                smtp.Host = SMTPHost;
                smtp.Port = SMTPPort;
                smtp.EnableSsl = true;
                smtp.Send(message);
            }
        }
    }
}