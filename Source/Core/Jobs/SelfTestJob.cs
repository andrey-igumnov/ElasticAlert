// <copyright file="SelfTestJob.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
//     Licensed under the Apache License Version 2.0. See LICENSE file in the project root for full license information.
// </copyright>

namespace ElasticAlert.Jobs
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents self-testing job
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated via Castle Windsow")]
    internal sealed class SelfTestJob : Job
    {
        /// <inheritdoc/>
        public override void Run()
        {
            var utcNow = DateTime.UtcNow;

            if (utcNow.Minute % 2 == 0)
            {
                this.SendAlertMesage(new Dictionary<string, object> { { "date_time", utcNow } });
            }
            else
            {
                this.SendNormalMessage(new Dictionary<string, object> { { "date_time", utcNow } });
            }
        }
    }
}
