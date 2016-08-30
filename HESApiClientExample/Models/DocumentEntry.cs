using System.Collections.Generic;
using System.Linq;

namespace HESApiClientExample.Models
{
    /// <summary>
    /// Represents the reduced presentation of the Document entity usually returned in response of user's search query.
    /// </summary>
    public class DocumentEntry
    {
        /// <summary>
        /// The unique resource identifier of the document.
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// The title of document.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The type of document.
        /// </summary>
        public IEnumerable<string> DocumentTypes { get; set; }

        /// <summary>
        /// A short extract from Document's contents.
        /// </summary>
        public string Excerpt { get; set; }
        
        /// <summary>
        /// Metadata associated within the document.
        /// </summary>
        public DocumentMeta Meta { get; set; }
  

        public DocumentEntry()
        {
            DocumentTypes = Enumerable.Empty<string>();
            Meta = new DocumentMeta();
        }
    }
}
