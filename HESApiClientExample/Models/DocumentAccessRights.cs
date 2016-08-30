using System.Collections.Generic;
using System.Linq;

namespace HESApiClientExample.Models
{
    /// <summary>
    /// Represents the access rights associated within the document.
    /// </summary>
    public class DocumentAccessRights
    {
        /// <summary>
        /// The collection of identities which is granted to read the document.
        /// </summary>
        public IEnumerable<string> Allowed { get; set; }

        /// <summary>
        /// The collection of identities which is forbidden to read the document.
        /// </summary>
        public IEnumerable<string> Denied { get; set; }


        public DocumentAccessRights()
        {
            Allowed = Enumerable.Empty<string>();
            Denied = Enumerable.Empty<string>();
        }
    }
}
