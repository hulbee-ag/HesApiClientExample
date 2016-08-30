using System.Collections.Generic;
using System.Linq;

namespace HESApiClientExample.Models
{
    /// <summary>
    /// Represents the Document entity.
    /// </summary>
    public class Document
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
        /// The textual contents of document.
        /// </summary>
        public string Text { get; set; }
        
        
        /// <summary>
        /// The collection of keywords associated within the document.
        /// </summary>
        public IEnumerable<string> Keywords { get; set; }

        /// <summary>
        /// The collection of the most informative sentences from the document.
        /// </summary>
        public IEnumerable<string> Digest { get; set; }


        /// <summary>
        /// Metadata associated within the document.
        /// </summary>
        public DocumentMeta Meta { get; set; }

        /// <summary>
        /// Access rights associated within the document.
        /// </summary>
        public DocumentAccessRights Access { get; set; }
        

        public Document()
        {
            DocumentTypes = Enumerable.Empty<string>();
            Keywords = Enumerable.Empty<string>();
            Digest = Enumerable.Empty<string>();
            Meta = new DocumentMeta();
            Access = new DocumentAccessRights();
        }
    }
}
