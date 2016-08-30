using System.Collections.Generic;
using Newtonsoft.Json;

namespace HESApiClientExample.Models
{
    public class SearchResponse
    {
        /// <summary>
        /// The search request object.
        /// </summary>
        public SearchQuery Request { get; set; }

        /// <summary>
        /// The collection of document entries.
        /// </summary>
        public IEnumerable<DocumentEntry> Items { get; set; }

        /// <summary>
        /// The number of search results found by query.
        /// </summary>
        public long TotalCount { get; set; }


        /// <summary>
        /// The collection of document sources found by query.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Aggregations.Source> Sources { get; set; }

        /// <summary>
        /// The collection of document types found by query.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Aggregations.Doctype> Doctypes { get; set; }

        /// <summary>
        /// The collection of document languages found by query.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Aggregations.Language> Languages { get; set; }
                        

        /// <summary>
        /// The link to the next page of the paged search response if exists, otherwise null.
        /// </summary>
        public string NextPageUrl { get; set; }
    }
}