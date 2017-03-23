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
        /// Gets the subject of the message
        /// </summary>
        string Subject { get; }

        /// <summary>
        /// Gets template path of the message
        /// </summary>
        string TemplatePath { get; }

        /// <summary>
        /// Gets a value indicating whether the message body is in HTML
        /// </summary>
        bool IsBodyHtml { get; }

        /// <summary>
        /// Gets the priority of the message
        /// </summary>
        MessagePriority Priority { get; }
    }
}
