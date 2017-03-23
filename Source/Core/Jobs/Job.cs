// <copyright file="Job.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
//     Licensed under the Apache License Version 2.0. See LICENSE file in the project root for full license information.
// </copyright>

namespace ElasticAlert.Jobs
{
    using System;
    using System.Collections.Generic;
    using Data;
    using Providers;

    /// <summary>
    /// Represents base job class
    /// </summary>
    internal abstract class Job : IJob
    {
        /// <summary>
        /// Job context
        /// </summary>
        private readonly IContext context = new Context();

        /// <inheritdoc/>
        public string JobId { get; set; }

        /// <inheritdoc/>
        public IDataClient DataClient { get; set; }

        /// <inheritdoc/>
        public IProvider Provider { get; set; }

        /// <inheritdoc/>
        public IMessage AlertMessage { get; set; }

        /// <inheritdoc/>
        public IMessage NormalMessage { get; set; }

        /// <inheritdoc/>
        public string Query { get; set; }

        /// <inheritdoc/>
        public TimeSpan? TimeShift { get; set; }

        /// <inheritdoc/>
        public TimeSpan Period { get; set; }

        /// <inheritdoc/>
        public TimeSpan InvocationPeriod { get; set; }

        /// <inheritdoc/>
        public string TimeZone { get; set; }

        /// <inheritdoc/>
        public int Repeat { get; set; }

        /// <inheritdoc/>
        public abstract void Run();

        /// <summary>
        /// Sends alert message
        /// </summary>
        /// <param name="data">Result returned from data client</param>
        protected void SendAlertMesage(IDictionary<string, object> data)
        {
            if (this.context.CurrentAlertMessagesCount < this.Repeat)
            {
                this.Provider.Send(this.AlertMessage, data);
                this.context.IncrementAlertMessagesCount();
            }
        }

        /// <summary>
        /// Sends normal message
        /// </summary>
        /// <param name="data">Result returned from data client</param>
        protected void SendNormalMessage(IDictionary<string, object> data)
        {
            if (this.context.CurrentNormalMessagesCount < 1)
            {
                this.Provider.Send(this.NormalMessage, data);
                this.context.IncrementNormalMessagesCount();
            }
        }
    }
}
