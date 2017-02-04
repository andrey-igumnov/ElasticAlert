// <copyright file="IContext.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
//     Licensed under the Apache License Version 2.0. See LICENSE file in the project root for full license information.
// </copyright>

namespace ElasticAlert
{
    using System;

    /// <summary>
    /// Represents job context
    /// </summary>
    internal interface IContext
    {
        /// <summary>
        /// Gets current alert messages count
        /// </summary>
        int CurrentAlertMessagesCount { get; }

        /// <summary>
        /// Gets current normal messages count
        /// </summary>
        int CurrentNormalMessagesCount { get; }

        /// <summary>
        /// Increments number of alert messages counter
        /// </summary>
        void IncrementAlertMessagesCount();

        /// <summary>
        /// Increments number of normal messages counter
        /// </summary>
        void IncrementNormalMessagesCount();
    }
}
