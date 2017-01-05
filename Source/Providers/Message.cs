// <copyright file="Message.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
//     Licensed under the Apache License Version 2.0. See LICENSE file in the project root for full license information.
// </copyright>

namespace ElasticAlert.Providers
{
    using Email;

    /// <summary>
    /// Represents email message
    /// </summary>
    public sealed class Message : IMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class
        /// </summary>
        /// <param name="subject">Subject of the message</param>
        /// <param name="body">Body of the message</param>
        /// <param name="priority">Message priority</param>
        public Message(string subject, string body, MessagePriority priority)
        {
            this.Subject = subject;
            this.Body = body;
            this.Priority = priority;
        }

        /// <inheritdoc/>
        public string Subject { get; }

        /// <inheritdoc/>
        public string Body { get; }

        /// <inheritdoc/>
        public MessagePriority Priority { get; }
    }
}
