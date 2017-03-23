// <copyright file="ThresholdJob.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
//     Licensed under the Apache License Version 2.0. See LICENSE file in the project root for full license information.
// </copyright>

namespace ElasticAlert.Jobs
{
    using System;
    using System.Collections.Generic;
    using Data;

    /// <summary>
    /// Performs notification when count of the events more than maximum value or less than minimum value
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated via Castle Windsow")]
    internal sealed class ThresholdJob : Job
    {
        /// <summary>
        /// Gets or sets minimum threshold value
        /// </summary>
        public int? MinimumValue { get; set; }

        /// <summary>
        /// Gets or sets maximum threshold value
        /// </summary>
        public int? MaximumValue { get; set; }

        /// <inheritdoc/>
        public override void Run()
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(this.TimeZone);
            var interval = new Interval(timeZone, this.Period, this.TimeShift.GetValueOrDefault(TimeSpan.Zero));
            var count = this.DataClient.Count(this.Query, interval);

            var data = new Dictionary<string, object>
            {
                { "count", count },
                { "start", interval.StartDateTime },
                { "end", interval.StartDateTime },
            };

            if (count < this.MinimumValue.GetValueOrDefault(int.MinValue) || count > this.MaximumValue.GetValueOrDefault(int.MaxValue))
            {
                this.SendAlertMesage(data);
            }
            else
            {
                this.SendNormalMessage(data);
            }
        }
    }
}
