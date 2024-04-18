using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SimplifiedBankingSendingEmail.Models
{
    public static class SendingEmail
    {
        public static void Send(TransactionNotifyEmail transactionEmail)
        {
            MailMessage mailMessage = new MailMessage();
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com", 587);

                smtpClient.EnableSsl = true;
                smtpClient.Timeout = 1200;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("EMAIL_FROM", "SENHA");
                mailMessage.From = new MailAddress("EMAIL", "PicPaySim by Vinicius Pecorari");
                mailMessage.Body = "Transação efetuada com sucesso!<br><br>" +
                                   $"<b>Código:</b> {transactionEmail.TransactionId.ToString()}" +
                                   $"<b>Pagador:</b> {transactionEmail.PayerName}" +
                                   $"<b>Beneficiario:</b> {transactionEmail.PayeeEmail}" +
                                   $"<b>Valor:</b> {transactionEmail.Value.ToString()}" +
                                   $"<b>Em:</b> {transactionEmail.TransactionCreatedAt.ToString()}";
                mailMessage.Subject = "PicPay Simplificado by Vinicius Pecorari";
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = MailPriority.Normal;
                mailMessage.To.Add("EMAIL_TO");

                smtpClient.Send(mailMessage);
                Console.WriteLine("Email enviado");
                Console.WriteLine(mailMessage);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
