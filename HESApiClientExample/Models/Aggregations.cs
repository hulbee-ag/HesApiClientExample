using System.Collections.Generic;
using Newtonsoft.Json;

namespace HESApiClientExample.Models.Aggregations
{
    /// <summary>
    /// Repesents the facet by document types.
    /// </summary>
    public class Doctype
    {
        /// <summary>
        /// Document type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The number of documents which matches the doctype.
        /// </summary>
        public long ItemsCount { get; set; }

        /// <summary>
        /// The collection of nested facet values.
        /// </summary>
        public IList<Doctype> Doctypes { get; set; }


        public Doctype()
        {
            Doctypes = new List<Doctype>();
        }
    }

    /// <summary>
    /// Repesents the facet by document languages.
    /// </summary>
    public class Language
    {
        /// <summary>
        /// The ISO 639-1 two-letter code for the language.
        /// </summary>
        public string TwoLetterISOName { get; set; }

        /// <summary>
        /// The native language name.
        /// </summary>
        public string NativeName { get; set; }

        /// <summary>
        /// The number of documents which matches the language.
        /// </summary>
        public long ItemsCount { get; set; }
    }

    /// <summary>
    /// Repesents the facet by document pathes.
    /// </summary>
    public class PathItem
    {
        /// <summary>
        /// The path to the document.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The number of documents which matches the path.
        /// </summary>
        public long ItemsCount { get; set; }
    }

    /// <summary>
    /// Repesents the facet by document extensions.
    /// </summary>
    public class ExtensionItem
    {
        /// <summary>
        /// The document extension.
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// The number of documents which matches the extension.
        /// </summary>
        public long ItemsCount { get; set; }
    }

    /// <summary>
    /// Repesents the facet by document sources.
    /// </summary>
    public class Source
    {
        /// <summary>
        /// The unique ID of the source.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The source's displaying name.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The collection of nested facet values.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Source> Sources { get; set; }

        /// <summary>
        /// The number of documents which matches the source.
        /// </summary>
        public long ItemsCount { get; set; }

        public Source()
        {
            Sources = new List<Source>();
        }
    }
}
