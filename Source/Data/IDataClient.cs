// <copyright file="IDataClient.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
//     Licensed under the Apache License Version 2.0. See LICENSE file in the project root for full license information.
// </copyright>

namespace ElasticAlert.Data
{
    /// <summary>
    /// Represents data client interface
    /// </summary>
    public interface IDataClient
    {
        /// <summary>
        /// Returns documents count by query
        /// </summary>
        /// <param name="query">Search query</param>
        /// <param name="interval">Date time interval</param>
        /// <returns>Documents count</returns>
        int Count(string query, Interval interval);
    }
}
