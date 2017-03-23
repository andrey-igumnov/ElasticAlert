// <copyright file="IProvider.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
//     Licensed under the Apache License Version 2.0. See LICENSE file in the project root for full license information.
// </copyright>

namespace ElasticAlert.Providers
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents provider interface
    /// </summary>
    public interface IProvider
    {
        /// <summary>
        /// Sends the specified message
        /// </summary>
        /// <param name="message">Alert message template</param>
        /// <param name="data">Message data</param>
        void Send(IMessage message, IDictionary<string, object> data);
    }
}
