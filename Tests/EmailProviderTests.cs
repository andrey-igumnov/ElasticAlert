// <copyright file="EmailProviderTests.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
//     Licensed under the Apache License Version 2.0. See LICENSE file in the project root for full license information.
// </copyright>

namespace ElasticAlert.Tests
{
    using System.Collections.ObjectModel;
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;

    using NUnit.Framework;

    using Providers;
    using Providers.Email;

    /// <summary>
    /// <see cref="EmailProvider"/> tests
    /// </summary>
    [TestFixture]
    public static class EmailProviderTests
    {
        /// <summary>
        /// Send message integration test
        /// </summary>
        [Test]
        [Ignore("Integration test")]
        public static void SendMessageIntegrationTest()
        {
            var client = new SmtpClient
            {
                Host = "smtp host",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("login", "password"),
            };

            var emailProvider = new EmailProvider(
                client,
                new MailAddress("from@example.com"),
                new Collection<MailAddress> { new MailAddress("to@example.com") });

            emailProvider.Send(new Message("Subject", "Body", MessagePriority.Low));
        }

        /// <summary>
        /// Send message asynchroniusly integration test
        /// </summary>
        [Test]
        [Ignore("Integration test")]
        public static async Task SendMessageAsyncIntegrationTest()
        {
            var client = new SmtpClient
            {
                Host = "smtp host",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("login", "password"),
            };

            var emailProvider = new EmailProvider(
                client,
                new MailAddress("from@example.com"),
                new Collection<MailAddress> { new MailAddress("to@example.com") });

            await emailProvider.SendAsync(new Message("Subject async", "Body async", MessagePriority.Low));
        }
    }
}
