// <copyright file="ElasticsearchClient.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
//     Licensed under the Apache License Version 2.0. See LICENSE file in the project root for full license information.
// </copyright>

namespace ElasticAlert.Data
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Represents ElasticSearch client
    /// </summary>
    public sealed class ElasticsearchClient : IDataClient
    {
        /// <summary>
        /// Service URI
        /// </summary>
        private readonly Uri serviceUri;

        /// <summary>
        /// Time field name
        /// </summary>
        private readonly string timeFieldName;

        /// <summary>
        /// Initializes a new instance of the <see cref="ElasticsearchClient"/> class
        /// </summary>
        /// <param name="serviceUri">Service URI</param>
        /// <param name="timeFieldName">Time field name</param>
        public ElasticsearchClient(Uri serviceUri, string timeFieldName)
        {
            this.serviceUri = serviceUri;
            this.timeFieldName = timeFieldName;
        }

        /// <inheritdoc/>
        public int Count(string query, Interval interval)
        {
            var uriBuilder = new UriBuilder(this.serviceUri);
            uriBuilder.Path = uriBuilder.Path + "/_count";
            var countResponse = Search(uriBuilder.Uri, query + FormattableString.Invariant($" AND {this.timeFieldName}:[{GetIntervalQuery(interval)}]"));
            dynamic d = JObject.Parse(countResponse);
            return d.count;
        }

        /// <summary>
        /// Performs search
        /// </summary>
        /// <param name="uri">Base search uri</param>
        /// <param name="query">Search query</param>
        /// <returns>Search result</returns>
        private static string Search(Uri uri, string query)
        {
            using (var webClient = new WebClient())
            {
                try
                {
                    return webClient.DownloadString(uri + "?q=" + query);
                }
                catch (WebException exception)
                {
                    if (exception.Response != null)
                    {
                        using (var stream = exception.Response.GetResponseStream())
                        {
                            var reader = new StreamReader(stream, Encoding.UTF8);
                            throw new DataClientException(reader.ReadToEnd());
                        }
                    }

                    throw;
                }
            }
        }

        /// <summary>
        /// Converts interval to query
        /// </summary>
        /// <param name="interval">Date time interval</param>
        /// <returns>Query part</returns>
        private static string GetIntervalQuery(Interval interval)
        {
            return FormattableString.Invariant($"{interval.StartDateTime:yyyy-MM-ddTHH:mm:ss} TO {interval.EndDateTime:yyyy-MM-ddTHH:mm:ss}");
        }
    }
}
