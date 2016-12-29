// <copyright file="IProvider.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
//     Licensed under the Apache License Version 2.0. See LICENSE file in the project root for full license information.
// </copyright>

namespace ElasticAlert.Providers
{
    using System.Threading.Tasks;

    /// <summary>
    /// Represents provider interface
    /// </summary>
    public interface IProvider
    {
        /// <summary>
        /// Sends the specified message
        /// </summary>
        /// <param name="message">Alert message</param>
        void Send(IMessage message);

        /// <summary>
        /// Sends the specified message as an asynchronous operation
        /// </summary>
        /// <param name="message">>Alert message</param>
        /// <returns>The task object representing the asynchronous operation</returns>
        Task SendAsync(IMessage message);
    }
}
