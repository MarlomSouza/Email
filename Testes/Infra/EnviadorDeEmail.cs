using System;
using System.Net;
using System.Net.Mail;
using Dominio;

namespace Testes
{
    internal class EnviadorDeEmail
    {
        private Email email;

        public EnviadorDeEmail(Email email)
        {
            this.email = email;
        }

        public bool Enviar()
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.Priority = System.Net.Mail.MailPriority.High;
            mailMessage.From  = new MailAddress(email.Remetente);
            mailMessage.To.Add(email.Destinario);
            mailMessage.Body = email.Mensagem;
            
            // SmtpClient objSmtp = new SmtpClient("smtp.mail.yahoo.com", 587)
            SmtpClient objSmtp = new SmtpClient
            {
                Host = "Smtp.Gmail.com",
                Port = 587,
                EnableSsl = true,
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("aliguijulmar@gmail.com", "$8jXpC8O")
            };

            try
            {
                objSmtp.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreram problemas no envio do e-mail. Erro = " + ex.Message);
            }
            finally
            {
                mailMessage.Dispose();
            }
        }
    }
}