// <copyright file="Context.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
//     Licensed under the Apache License Version 2.0. See LICENSE file in the project root for full license information.
// </copyright>

namespace ElasticAlert
{
    /// <summary>
    /// Represents job context
    /// </summary>
    internal sealed class Context : IContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Context"/> class
        /// </summary>
        public Context()
        {
            this.CurrentNormalMessagesCount = 1;
        }

        /// <inheritdoc/>
        public int CurrentAlertMessagesCount { get; private set; }

        /// <inheritdoc/>
        public int CurrentNormalMessagesCount { get; private set; }

        /// <inheritdoc/>
        public void IncrementAlertMessagesCount()
        {
            this.CurrentAlertMessagesCount++;
            this.CurrentNormalMessagesCount = 0;
        }

        /// <inheritdoc/>
        public void IncrementNormalMessagesCount()
        {
            this.CurrentNormalMessagesCount++;
            this.CurrentAlertMessagesCount = 0;
        }
    }
}
