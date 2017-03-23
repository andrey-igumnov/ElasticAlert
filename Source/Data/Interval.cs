// <copyright file="Interval.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
//     Licensed under the Apache License Version 2.0. See LICENSE file in the project root for full license information.
// </copyright>

namespace ElasticAlert.Data
{
    using System;

    /// <summary>
    /// Represents date time interval
    /// </summary>
    public sealed class Interval
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Interval"/> class
        /// </summary>
        /// <param name="startDateTime">Start date time interval</param>
        /// <param name="endDateTime">End date time interval</param>
        public Interval(DateTime startDateTime, DateTime endDateTime)
        {
            this.StartDateTime = startDateTime;
            this.EndDateTime = endDateTime;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Interval"/> class
        /// </summary>
        /// <param name="timeZone">Interval time zone</param>
        /// <param name="period">Interval period</param>
        /// <param name="timeShift">Time shift</param>
        public Interval(TimeZoneInfo timeZone, TimeSpan period, TimeSpan timeShift)
        {
            var dateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone) - timeShift;

            this.EndDateTime = dateTime;
            this.StartDateTime = dateTime - period;
        }

        /// <summary>
        /// Gets start date time interval
        /// </summary>
        public DateTime StartDateTime { get; }

        /// <summary>
        /// Gets end date time interval
        /// </summary>
        public DateTime EndDateTime { get; }
    }
}
