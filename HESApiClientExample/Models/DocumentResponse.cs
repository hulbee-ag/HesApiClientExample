
namespace HESApiClientExample.Models
{
    public class DocumentResponse
    {
        /// <summary>
        /// The document request object.
        /// </summary>
        public DocumentQuery Request { get; set; }

        /// <summary>
        /// The document fetched by query.
        /// </summary>
        public Document Document { get; set; }

        /// <summary>
        /// The document preview options.
        /// </summary>
        public DocumentPreviewOptions Preview { get; set; }
    }

    public class DocumentPreviewOptions
    {
        /// <summary>
        /// The link to the document preview.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Whether the JavaScript allowed in the document preview.
        /// </summary>
        public bool AllowJavascript { get; set; }
    }
}