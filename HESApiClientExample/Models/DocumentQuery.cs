using System.ComponentModel.DataAnnotations;

namespace HESApiClientExample.Models
{
    public class DocumentQuery
    {
        /// <summary>
        /// The URI of the document to return.
        /// </summary>
        [Required]
        public string Uri { get; set; }

        /// <summary>
        /// The text you want to be highlighted in the document's text and summary.
        /// </summary>
        public string Query { get; set; }
    }
}