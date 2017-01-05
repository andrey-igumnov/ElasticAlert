// <copyright file="IMessage.cs" company="PayOnline">
//     Copyright (c) PayOnline. All rights reserved.
// </copyright>

namespace ElasticAlert.Providers
{
    /// <summary>
    /// Represents message interface
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Gets the message header
        /// </summary>
        string Subject { get; }

        /// <summary>
        /// Gets the massage body
        /// </summary>
        string Body { get; }

        /// <summary>
        /// Gets the message priority
        /// </summary>
        MessagePriority Priority { get; }
    }
}
