using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HESApiClientExample.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DocumentProcessingState
    {
        Processed,
        Aborted,
        TimedOut,
        Error,
        ExtendedProcessing
    }
}
