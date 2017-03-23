// <copyright file="IJob.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
//     Licensed under the Apache License Version 2.0. See LICENSE file in the project root for full license information.
// </copyright>

namespace ElasticAlert.Jobs
{
    using System;
    using Data;
    using Providers;

    /// <summary>
    /// Represents job interface
    /// </summary>
    public interface IJob
    {
        /// <summary>
        /// Gets or sets job ID
        /// </summary>
        string JobId { get; set; }

        /// <summary>
        /// Gets or sets data client
        /// </summary>
        IDataClient DataClient { get; set; }

        /// <summary>
        /// Gets or sets notification provider
        /// </summary>
        IProvider Provider { get; set; }

        /// <summary>
        /// Gets or sets alert message
        /// </summary>
        IMessage AlertMessage { get; set; }

        /// <summary>
        /// Gets or sets normally message
        /// </summary>
        IMessage NormalMessage { get; set; }

        /// <summary>
        /// Gets or sets search query
        /// </summary>
        string Query { get; set; }

        /// <summary>
        /// Gets or sets time shift
        /// </summary>
        TimeSpan? TimeShift { get; set; }

        /// <summary>
        /// Gets or sets search period
        /// </summary>
        TimeSpan Period { get; set; }

        /// <summary>
        /// Gets or sets invocation period
        /// </summary>
        TimeSpan InvocationPeriod { get; set; }

        /// <summary>
        /// Gets or sets time zone
        /// </summary>
        string TimeZone { get; set; }

        /// <summary>
        /// Gets or sets alert repeat count
        /// </summary>
        int Repeat { get; set; }

        /// <summary>
        /// Runs the job
        /// </summary>
        void Run();
    }
}
