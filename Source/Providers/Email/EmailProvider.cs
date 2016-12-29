// <copyright file="EmailProvider.cs" company="PayOnline">
//     Copyright (c) Andrey Igumnov. All rights reserved.
//     Licensed under the Apache License Version 2.0. See LICENSE file in the project root for full license information.
// </copyright>

namespace ElasticAlert.Providers.Email
{
    using System;
    using System.Collections.ObjectModel;
    using System.Net.Mail;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents email provider
    /// </summary>
    public sealed class EmailProvider : IProvider
    {
        /// <summary>
        /// SMTP client
        /// </summary>
        private readonly SmtpClient smtpClient;

        /// <summary>
        /// Email sender
        /// </summary>
        private readonly MailAddress sender;

        /// <summary>
        /// Email recipients
        /// </summary>
        private readonly Collection<MailAddress> mailRecipients;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailProvider"/> class
        /// </summary>
        /// <param name="smtpClient">SMTP client</param>
        /// <param name="sender">Email sender</param>
        /// <param name="mailRecipients">Email recipients</param>
        public EmailProvider(SmtpClient smtpClient, MailAddress sender, Collection<MailAddress> mailRecipients)
        {
            if (smtpClient == null)
            {
                throw new ArgumentNullException(nameof(smtpClient));
            }

            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (mailRecipients == null || mailRecipients.Count == 0)
            {
                throw new ArgumentNullException(nameof(mailRecipients));
            }

            this.smtpClient = smtpClient;
            this.sender = sender;
            this.mailRecipients = mailRecipients;
        }

        /// <inheritdoc/>
        public void Send(IMessage message)
        {
            using (this.smtpClient)
            {
                this.smtpClient.Send(this.PrepareMailMessage(message));
            }
        }

        /// <inheritdoc/>
        public async Task SendAsync(IMessage message)
        {
            using (this.smtpClient)
            {
                await this.smtpClient.SendMailAsync(this.PrepareMailMessage(message));
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
        /// <param name="message">Alert message</param>
        /// <returns>Mail message</returns>
        private MailMessage PrepareMailMessage(IMessage message)
        {
            using (var mailMessage = new MailMessage())
            {
                foreach (var mailRecipient in this.mailRecipients)
                {
                    mailMessage.To.Add(mailRecipient);
                }

                mailMessage.Subject = message.Subject;
                mailMessage.Body = message.Body;
                mailMessage.Priority = ToMailPriority(message.Priority);
                mailMessage.From = this.sender;

                return mailMessage;
            }
        }
    }
}
