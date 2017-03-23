// <copyright file="Program.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
//     Licensed under the Apache License Version 2.0. See LICENSE file in the project root for full license information.
// </copyright>

namespace ElasticAlert.Host
{
    using System;
    using Castle.Windsor;
    using Castle.Windsor.Installer;

    /// <summary>
    /// Entry point
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main function
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Will be refactored later")]
        public static void Main()
        {
            using (var scheduler = new WindsorContainer().Install(Configuration.FromAppConfig(), FromAssembly.This()).Resolve<Scheduler>())
            {
                scheduler.Start();
                Console.ReadKey();
            }
        }
    }
}
