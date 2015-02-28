using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PharmaProject
{
    static public class CL_SMTP
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oMsg">Data[0] doit contenir l'email de récéption, Data[1] le sujet, Data[2] le message</param>
        /// <returns></returns>
        static public STR_MSG Send(STR_MSG oMsg)
        {

            MailMessage mail = new MailMessage("exia@pharmaproject.com", (string)oMsg.Data[0]);
            SmtpClient client = new SmtpClient();

            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;

            client.Host = "smtp.google.com";
            mail.Subject = (string)oMsg.Data[1];
            mail.Body = (string)oMsg.Data[2];

            client.Send(mail);


            return oMsg;

        }



    }
}
