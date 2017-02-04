// <copyright file="Message.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
//     Licensed under the Apache License Version 2.0. See LICENSE file in the project root for full license information.
// </copyright>

namespace ElasticAlert.Providers
{
    /// <summary>
    /// Represents email message
    /// </summary>
    public sealed class Message : IMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class
        /// </summary>
        /// <param name="subject">Subject of the message</param>
        /// <param name="templatePath">Message template path</param>
        public Message(string subject, string templatePath)
        {
            this.Subject = subject;
            this.Priority = MessagePriority.Default;
            this.TemplatePath = templatePath;
        }

        /// <inheritdoc/>
        public string Subject { get; }

        /// <inheritdoc/>
        public string TemplatePath { get; }

        /// <inheritdoc/>
        public bool IsBodyHtml { get; set; }

        /// <inheritdoc/>
        public MessagePriority Priority { get; set; }
    }
}
