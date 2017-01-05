// <copyright file="MessagePriority.cs" company="PayOnline">
//     Copyright (c) PayOnline. All rights reserved.
// </copyright>

namespace ElasticAlert.Providers
{
    /// <summary>
    /// Represents the priority of a <see cref="IMessage"/>
    /// </summary>
    public enum MessagePriority
    {
        /// <summary>
        /// The message has low priority
        /// </summary>
        Low,

        /// <summary>
        /// The message has normal priority
        /// </summary>
        Normal,

        /// <summary>
        /// The message has high priority
        /// </summary>
        High,

        Default = Normal,
    }
}
