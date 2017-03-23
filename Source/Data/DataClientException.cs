// <copyright file="DataClientException.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
//     Licensed under the Apache License Version 2.0. See LICENSE file in the project root for full license information.
// </copyright>

namespace ElasticAlert.Data
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Represents data client exception
    /// </summary>
    [Serializable]
    public class DataClientException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataClientException"/> class
        /// </summary>
        public DataClientException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataClientException"/> class with error message
        /// </summary>
        /// <param name="message">Exception message</param>
        public DataClientException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataClientException"/> class. Creates new exception
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="inner">Inner exception</param>
        public DataClientException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataClientException"/> class
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected DataClientException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
