using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HESApiClientExample.Models
{
    /// <summary>
    /// Represents the metadata associated within the Swisscows.Ses.Models.Document object.
    /// </summary>
    public class DocumentMeta : IDictionary<string, object>
    {
        private readonly IDictionary<string, object> _dict;

        public DocumentMeta()
        {
            _dict = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// The full path to the document.
        /// </summary>
        public string FullPath
        {
            get { return _dict.ContainsKey(MetaKeys.FullPath) ? (string)_dict[MetaKeys.FullPath] : null; }
            set { _dict[MetaKeys.FullPath] = value; }
        }

        /// <summary>
        /// The directory of the document.
        /// </summary>
        public string Directory
        {
            get { return _dict.ContainsKey(MetaKeys.Directory) ? (string)_dict[MetaKeys.Directory] : null; }
            set { _dict[MetaKeys.Directory] = value; }
        }

        /// <summary>
        /// The filename of the document.
        /// </summary>
        public string Filename
        {
            get { return _dict.ContainsKey(MetaKeys.Filename) ? (string)_dict[MetaKeys.Filename] : null; }
            set { _dict[MetaKeys.Filename] = value; }
        }

        /// <summary>
        /// The extension of the document file.
        /// </summary>
        public string Extension
        {
            get { return _dict.ContainsKey(MetaKeys.Extension) ? (string)_dict[MetaKeys.Extension] : null; }
            set { _dict[MetaKeys.Extension] = value; }
        }

        [DefaultValue(false)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsArchived
        {
            get { return _dict.ContainsKey(MetaKeys.IsArchived) ? (bool)_dict[MetaKeys.IsArchived] : false; }
            set { _dict[MetaKeys.IsArchived] = value; }
        }

        /// <summary>
        /// The size of the document.
        /// </summary>
        public long Size 
        {
            get { return _dict.ContainsKey(MetaKeys.Size) ? (long)_dict[MetaKeys.Size] : 0; }
            set { _dict[MetaKeys.Size] = value; } 
        }

        /// <summary>
        /// The datetime when the document was created.
        /// </summary>
        public DateTime CreatedAt 
        {
            get { return _dict.ContainsKey(MetaKeys.CreationDateTime) ? (DateTime)_dict[MetaKeys.CreationDateTime] : DateTime.MinValue; }
            set { _dict[MetaKeys.CreationDateTime] = value; }
        }

        /// <summary>
        /// The datetime when the document was last updated.
        /// </summary>
        public DateTime LastUpdatedAt 
        {
            get { return _dict.ContainsKey(MetaKeys.LastUpdateDateTime) ? (DateTime)_dict[MetaKeys.LastUpdateDateTime] : DateTime.MinValue; }
            set { _dict[MetaKeys.LastUpdateDateTime] = value; }
        }

        /// <summary>
        /// The datetime when the document was last synchronized.
        /// </summary>
        public DateTime SynchronizedAt
        {
            get { return _dict.ContainsKey(MetaKeys.SynchronizationDateTime) ? (DateTime)_dict[MetaKeys.SynchronizationDateTime] : DateTime.MinValue; }
            set { _dict[MetaKeys.SynchronizationDateTime] = value; }
        }

        /// <summary>
        /// List of detected in the document languages.
        /// </summary>
        public IEnumerable<string> Languages 
        {
            get 
            {
                IEnumerable<string> languages;
                if (TryGetEnumerable<string>(MetaKeys.Languages, out languages))
                {
                    return languages ?? Enumerable.Empty<string>();
                }

                return Enumerable.Empty<string>();
            }
            set { _dict[MetaKeys.Languages] = value; }
        }
        
        /// <summary>
        /// The identifier of the connector to which the document belongs to.
        /// </summary>
        public string Connector
        {
            get { return _dict.ContainsKey(MetaKeys.Connector) ? (string)_dict[MetaKeys.Connector] : null; }
            set { _dict[MetaKeys.Connector] = value; }
        }

        /// <summary>
        /// The identifier of the feed to which the document belongs to.
        /// </summary>
        public string Feed
        {
            get { return _dict.ContainsKey(MetaKeys.Feed) ? (string)_dict[MetaKeys.Feed] : null; }
            set { _dict[MetaKeys.Feed] = value; }
        }
        
        /// <summary>
        /// Document processing state.
        /// </summary>
        public DocumentProcessingState ProcessingState
        {
            get
            {
                if (_dict.ContainsKey(MetaKeys.ProcessingState))
                {
                    if (_dict[MetaKeys.ProcessingState] is DocumentProcessingState)
                    {
                        return (DocumentProcessingState)_dict[MetaKeys.ProcessingState];
                    }
                    if (_dict[MetaKeys.ProcessingState] is int)
                    {
                        return (DocumentProcessingState)Enum.ToObject(typeof(DocumentProcessingState), (int)_dict[MetaKeys.ProcessingState]);
                    }
                    else
                    {
                        DocumentProcessingState result;
                        if (Enum.TryParse(_dict[MetaKeys.ProcessingState].ToString(), out result))
                        {
                            return result;
                        }
                    }
                }

                return DocumentProcessingState.Processed;
            }                
            set { _dict[MetaKeys.ProcessingState] = value; }
        }
        

        private bool TryGetEnumerable<T>(string key, out IEnumerable<T> values)
        {
            if (_dict.ContainsKey(key))
            {
                object valueObject = _dict[key];
                if (valueObject is IEnumerable<T>)
                {
                    values = (IEnumerable<T>)valueObject;
                    return true;
                }
                else if (valueObject is JArray)
                {
                    try
                    {
                        values = ((JArray)valueObject).Select(x => x.ToObject<T>()).ToArray();
                        return true;
                    }
                    catch { }
                }
            }

            values = Enumerable.Empty<T>();
            return false;
        }

        #region IDictionary<string, object> members

        public void Add(string key, object value)
        {
            _dict.Add(key, value);
        }

        public bool ContainsKey(string key)
        {
            return _dict.ContainsKey(key);
        }

        public ICollection<string> Keys
        {
            get { return _dict.Keys; }
        }

        public bool Remove(string key)
        {
            return _dict.Remove(key);
        }

        public bool TryGetValue(string key, out object value)
        {
            return _dict.TryGetValue(key, out value);
        }

        public ICollection<object> Values
        {
            get { return _dict.Values; }
        }

        public object this[string key]
        {
            get { return _dict[key]; }
            set { _dict[key] = value; }
        }

        public void Add(KeyValuePair<string, object> item)
        {
            _dict.Add(item);
        }

        public void Clear()
        {
            _dict.Clear();
        }

        public bool Contains(KeyValuePair<string, object> item)
        {
            return _dict.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            _dict.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _dict.Count; }
        }

        public bool IsReadOnly
        {
            get { return _dict.IsReadOnly; }
        }

        public bool Remove(KeyValuePair<string, object> item)
        {
            return _dict.Remove(item);
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return _dict.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _dict.GetEnumerator();
        }

        #endregion
    }
}
