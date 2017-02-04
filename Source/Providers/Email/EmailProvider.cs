// <copyright file="EmailProvider.cs" company="PayOnline">
//     Copyright (c) Andrey Igumnov. All rights reserved.
//     Licensed under the Apache License Version 2.0. See LICENSE file in the project root for full license information.
// </copyright>

namespace ElasticAlert.Providers.Email
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Mail;
    using DotLiquid;

    /// <summary>
    /// Represents email provider
    /// </summary>
    public sealed class EmailProvider : IProvider
    {
        /// <summary>
        /// SMTP client data
        /// </summary>
        private readonly SmtpClientData smtpClientData;

        /// <summary>
        /// Email sender
        /// </summary>
        private readonly string sender;

        /// <summary>
        /// Email recipients
        /// </summary>
        private readonly ICollection<string> mailRecipients;

        /// <summary>
        /// Specifies the value whether message sends asynchronously
        /// </summary>
        private readonly bool sendAsync;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailProvider"/> class
        /// </summary>
        /// <param name="smtpClientData">SMTP client data</param>
        /// <param name="sendAsync">Specifies the value whether message sends asynchronously</param>
        /// <param name="sender">Email sender</param>
        /// <param name="mailRecipients">Email recipients</param>
        public EmailProvider(SmtpClientData smtpClientData, bool sendAsync, string sender, ICollection<string> mailRecipients)
        {
            if (smtpClientData == null)
            {
                throw new ArgumentNullException(nameof(smtpClientData));
            }

            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (mailRecipients == null || mailRecipients.Count == 0)
            {
                throw new ArgumentNullException(nameof(mailRecipients));
            }

            this.smtpClientData = smtpClientData;
            this.sender = sender;
            this.mailRecipients = mailRecipients;
            this.sendAsync = sendAsync;
        }

        /// <inheritdoc/>
        public void Send(IMessage message, IDictionary<string, object> data)
        {
            using (var smtpClient = new SmtpClient(this.smtpClientData.Host, this.smtpClientData.Port))
            {
                smtpClient.EnableSsl = this.smtpClientData.IsSslEnabled;
                if (this.smtpClientData.IsDefaultCredentialsUsed)
                {
                    smtpClient.UseDefaultCredentials = true;
                }
                else
                {
                    smtpClient.Credentials = new NetworkCredential(this.smtpClientData.UserName, this.smtpClientData.Password);
                }

                if (this.smtpClientData.Timeout.HasValue)
                {
                    smtpClient.Timeout = (int)this.smtpClientData.Timeout.Value.TotalMilliseconds;
                }

                if (this.sendAsync)
                {
                    smtpClient.SendMailAsync(this.PrepareMailMessage(message, data));
                }
                else
                {
                    smtpClient.Send(this.PrepareMailMessage(message, data));
                }
            }
        }

        /// <summary>
        /// Converts message priority to mail priority
        /// </summary>
        /// <param name="messagePriority">Message priority</param>
        /// <returns>Mail priority</returns>
        private static MailPriority ToMailPriority(MessagePriority messagePriority)
        {
            switch (messagePriority)
            {
                case MessagePriority.High:
                    return MailPriority.High;
                case MessagePriority.Normal:
                    return MailPriority.Normal;
                case MessagePriority.Low:
                    return MailPriority.Low;
                default:
                    return MailPriority.Normal;
            }
        }

        /// <summary>
        /// Converts <see cref="IMessage"/> to <see cref="MailMessage"/>
        /// </summary>
        /// <param name="message">Alert message template</param>
        /// <param name="data">Message data</param>
        /// <returns>Mail message</returns>
        private MailMessage PrepareMailMessage(IMessage message, IDictionary<string, object> data)
        {
            var mailMessage = new MailMessage();

            foreach (var mailRecipient in this.mailRecipients)
            {
                mailMessage.To.Add(mailRecipient);
            }

            var messageContent = File.ReadAllText(message.TemplatePath);

            var template = Template.Parse(messageContent);

            mailMessage.Subject = message.Subject;
            mailMessage.Body = data == null ? messageContent : template.Render(Hash.FromDictionary(data));
            mailMessage.Priority = ToMailPriority(message.Priority);
            mailMessage.From = new MailAddress(this.sender);
            mailMessage.IsBodyHtml = message.IsBodyHtml;

            return mailMessage;
        }
    }
}
