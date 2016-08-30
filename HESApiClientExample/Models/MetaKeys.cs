using System;

namespace HESApiClientExample.Models
{
    public static class MetaKeys
    {
        /// <summary>
        /// Represents the full path to the document's file.
        /// </summary>
        public const string FullPath = "FullPath";

        /// <summary>
        /// Represents the directory of the document's file.
        /// </summary>
        public const string Directory = "Directory";

        /// <summary>
        /// Represents the name of the document's file.
        /// </summary>
        public const string Filename = "Filename";

        /// <summary>
        /// Represents the extension of the document's file.
        /// </summary>
        public const string Extension = "Extension";

        /// <summary>
        /// Represents the flag is document is archived or attached.
        /// </summary>
        public const string IsArchived = "IsArchived";

        /// <summary>
        /// Represents the size of document.
        /// </summary>
        public const string Size = "Size";
        
        /// <summary>
        /// Represents the datetime when the document was created.
        /// </summary>
        public const string CreationDateTime = "CreatedAt";

        /// <summary>
        /// Represents the datetime when the document was last updated.
        /// </summary>
        public const string LastUpdateDateTime = "LastUpdatedAt";

        /// <summary>
        /// Represents the datetime when the document wast last synchronized.
        /// </summary>
        public const string SynchronizationDateTime = "SynchronizedAt";

        /// <summary>
        /// Represents the languages of the document's content.
        /// </summary>
        public const string Languages = "Languages";

        /// <summary>
        /// Represents the document's connector identifier.
        /// </summary>
        public const string Connector = "Connector";

        /// <summary>
        /// Represents the document's feed identifier.
        /// </summary>
        public const string Feed = "Feed";


        /// <summary>
        /// Represent the document's processing state.
        /// </summary>
        public const string ProcessingState = "ProcessingState";
                
        /// <summary>
        /// Represents the description of the document conversion error.
        /// </summary>
        public const string ProcessingError = "ProcessingError";
    }
}
