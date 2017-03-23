// <copyright file="EmailProviderTests.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
//     Licensed under the Apache License Version 2.0. See LICENSE file in the project root for full license information.
// </copyright>

namespace ElasticAlert.Tests
{
    using System.Collections.Generic;

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
            var client = new SmtpClientData("smtpHost", 587);

            var emailProvider = new EmailProvider(
                client,
                false,
                "from@example.com",
                new List<string> { "to@example.com" });

            emailProvider.Send(new Message("Subject", "Body"), new Dictionary<string, object>());
        }

        /// <summary>
        /// Send message asynchronously integration test
        /// </summary>
        [Test]
        [Ignore("Integration test")]
        public static void SendMessageAsyncIntegrationTest()
        {
            var client = new SmtpClientData("smtpHost", 587);

            var emailProvider = new EmailProvider(
                client,
                true,
                "from@example.com",
                new List<string> { "to@example.com" });

            emailProvider.Send(new Message("Subject async", "Body async"), new Dictionary<string, object>());
        }
    }
}
