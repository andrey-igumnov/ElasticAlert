// <copyright file="SmtpClientData.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
// </copyright>

namespace ElasticAlert.Providers.Email
{
    using System;

    /// <summary>
    /// Represents SMTP client data
    /// </summary>
    public sealed class SmtpClientData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmtpClientData"/> class
        /// </summary>
        /// <param name="host">The name of the host used for SMTP transactions</param>
        /// <param name="port">The port used for SMTP transactions</param>
        public SmtpClientData(string host, int port)
        {
            this.Host = host;
            this.Port = port;
        }

        /// <summary>
        /// Gets the name of the host used for SMTP transactions
        /// </summary>
        public string Host { get; }

        /// <summary>
        /// Gets the port used for SMTP transactions
        /// </summary>
        public int Port { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the SMTP client uses SSL to encrypt the connections
        /// </summary>
        public bool IsSslEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether default credentials used
        /// </summary>
        public bool IsDefaultCredentialsUsed { get; set; }

        /// <summary>
        /// Gets or sets the amount of the time after which synchronous call times out
        /// </summary>
        public TimeSpan? Timeout { get; set; }

        /// <summary>
        /// Gets or sets the user name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password of the user name
        /// </summary>
        public string Password { get; set; }
    }
}
