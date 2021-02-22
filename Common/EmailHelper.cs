using MailKit;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreMixProject
{
    public class EmailHelper
    {
        public static void SendEmail(IConfigurationSection email, MimeEntity content , MimeEntity attachment ,Action<Object, MessageSentEventArgs> mailSent)
        {
            var messageToSend = new MimeMessage
            {
                Sender = new MailboxAddress(email["DisplayName"], email["EmailFromAddress"]),
                Subject = email["Subject"],
            };
            messageToSend.From.Add(new MailboxAddress(email["EmailFromAddress"], email["EmailFromAddress"]));
            //to
            string toAddr = email["EmailToAddress"];
            foreach (string addr in toAddr.Split(';'))
            {
                messageToSend.To.Add(new MailboxAddress(addr, addr));
            }
            //bcc
            string bccAddr = email["EmailBccAddress"];
            foreach (string addr in bccAddr.Split(';'))
            {
                messageToSend.Bcc.Add(new MailboxAddress(addr, addr));
            }

            //附件 
            var mixed = new Multipart("mixed");
            if (content != null)
            {
                mixed.Add(content);
            }
            if (attachment != null)
            {
                mixed.Add(attachment);
            }
            messageToSend.Body = mixed;

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.MessageSent += async (sender, args) =>
                {
                    mailSent(sender ,args);
                };
                client.Connect(email["Host"], int.Parse(email["Port"]), SecureSocketOptions.None);
                client.Authenticate(email["Username"], email["Password"]);
                client.Send(messageToSend);
                client.Disconnect(true);
            };
        }
    }
}
