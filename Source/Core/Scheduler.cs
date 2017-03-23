// <copyright file="Scheduler.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
//     Licensed under the Apache License Version 2.0. See LICENSE file in the project root for full license information.
// </copyright>

namespace ElasticAlert
{
    using System;
    using System.Collections.Generic;
    using System.Timers;

    using Jobs;

    /// <summary>
    /// Represents jobs scheduler
    /// </summary>
    public sealed class Scheduler : IDisposable
    {
        /// <summary>
        /// Timers dictionary
        /// </summary>
        private readonly Dictionary<string, Timer> timers = new Dictionary<string, Timer>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Scheduler"/> class with jobs collection
        /// </summary>
        /// <param name="runningJobs">Jobs collection</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Will be refactored later")]
        public Scheduler(ICollection<IJob> runningJobs)
        {
            if (runningJobs == null)
            {
                throw new ArgumentNullException(nameof(runningJobs));
            }

            foreach (var runningJob in runningJobs)
            {
                var timer = new Timer(runningJob.InvocationPeriod.TotalMilliseconds);
                timer.Elapsed += (o, e) => runningJob.Run();
                timer.Enabled = true;
                this.timers.Add(runningJob.JobId, timer);
            }
        }

        /// <summary>
        /// Start all jobs
        /// </summary>
        public void Start()
        {
            foreach (var timer in this.timers.Values)
            {
                timer.Start();
            }
        }

        /// <summary>
        /// Stops all jobs
        /// </summary>
        public void Stop()
        {
            foreach (var timer in this.timers.Values)
            {
                timer.Stop();
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            foreach (var timer in this.timers.Values)
            {
                timer.Dispose();
            }
        }
    }
}
