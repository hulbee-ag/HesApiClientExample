using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HESApiClientExample.Models
{
    public class SearchQuery
    {
        /// <summary>
        /// The user's search query string
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// The original user's search query string
        /// </summary>
        public string OriginalQuery { get; set; }

        /// <summary>
        /// The zero-based offset that indicates the number of search results to skip before returning results. 
        /// Defaults to 0.
        /// </summary>
        [Range(0, 1000)]
        public int Offset { get; set; }

        /// <summary>
        /// The number of search results to return in the response. 
        /// The actual number delivered may be less than requested. 
        /// Defaults to 10.
        /// </summary>
        [Range(1, 50)]
        public int ItemsCount { get; set; }


        /// <summary>
        /// The type of sorting to apply to the search results. Defaults to Relevance.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public SortType SortBy { get; set; }

        /// <summary>
        /// The sort direction.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public SortOrder SortOrder { get; set; }

        /// <summary>
        /// The search mode allows to specify which properties should be included to the search response.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public SearchMode Mode { get; set; }


        #region Filters

        /// <summary>
        /// Specify the list of document types which should be returned in the response. 
        /// For example: "Document|Spreadsheet" to return spreadsheets only, or "Image" to return images. 
        /// The default is all.
        /// </summary>
        public IEnumerable<string> Doctype { get; set; }

        /// <summary>
        /// Limit the search results to the documents in the specified languages. 
        /// For example: "en" to return the documents in English.
        /// The default is all.
        /// </summary>
        public IEnumerable<string> Language { get; set; }

        /// <summary>
        /// Return the documents whose size in bytes satisfies the range.
        /// For example: "Size.From=512000" and "Size.To=2097152" to return the documents which size is greater or equals than 500Kb and lower or equals than 2MB.
        /// By default all documents will be returned.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Range Size { get; set; }

        /// <summary>
        /// Return the documents which were created at the specified date range.
        /// For example: "CreatedAt.From=1970-01-01" and "CreatedAt.To=2016-01-01" to return the documents which were created since the 1st of January 1970, but earlier than the 1st of January 2016.
        /// By default all documents will be returned.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateRange CreatedAt { get; set; }

        /// <summary>
        /// Return the documents which were last modified at the specified date range.
        /// For example: "LastUpdatedAt.From=1970-01-01" and "LastUpdatedAt.To=2016-01-01" to return the documents which were modified since the 1st of January 1970, but earlier than the 1st of January 2016.
        /// By default all documents will be returned.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateRange LastUpdatedAt { get; set; }

        /// <summary>
        /// Limit the search results to the documents which are located in the specified domain.
        /// For example: "www.example.org" to return documents from the http://www.example.org.
        /// By default all documents will be returned.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Site { get; set; }

        /// <summary>
        /// Limit the search results to the documents which are located in the specified folder.
        /// For example: "\\Share\public\docs" to return documents from the folder "public\docs" in the shared resource named "Share".
        /// By default all documents will be returned.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Path { get; set; }

        /// <summary>
        /// Specify one or several document extensions which should be returned in the response. 
        /// For example: ".doc, .docx" to return only *.doc or *.docx files. 
        /// The default is all.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Extension { get; set; }

        /// <summary>
        /// Specify the list of document sources which should be returned in the response. 
        /// For example: "Hes.Connectors.FileSystem" to return the documents provided by the FileSystem connector. 
        /// The default is all.
        /// </summary>
        public IEnumerable<string> Source { get; set; }
        

        #endregion


        public SearchQuery()
        {
            Offset = 0;
            ItemsCount = 10;
            Mode = SearchMode.ResultsOnly;

            Doctype = Enumerable.Empty<string>();
            Language = Enumerable.Empty<string>();
            Source = Enumerable.Empty<string>();
        }        
    }

    public enum SortType
    {
        /// <summary>
        /// Sort results by the relevance.
        /// </summary>
        Relevance,

        /// <summary>
        /// Sort results by the size.
        /// </summary>
        FileSize,

        /// <summary>
        /// Sort results by the date of the creation.
        /// </summary>
        CreationDate,

        /// <summary>
        /// Sort results by the date of the last update.
        /// </summary>
        LastUpdateDate
    }

    public enum SortOrder
    {
        /// <summary>
        /// Sort in ascending order.
        /// </summary>
        Asc = 0,

        /// <summary>
        /// Sort in descending order.
        /// </summary>
        Desc = 1
    }

    public enum SearchMode
    {
        /// <summary>
        /// Return the search results only. Please provide this value if you don't need the facets values within the search results.
        /// </summary>
        ResultsOnly,

        /// <summary>
        /// Return the search results and the facets values.
        /// </summary>
        All
    }
}