using System;

namespace HESApiClientExample.Models
{
    public class DateRange
    {
        /// <summary>
        /// (optional) The earliest value of the range.
        /// </summary>
        public DateTime? From { get; set; }

        /// <summary>
        /// (optional) The latest value of the range.
        /// </summary>
        public DateTime? To { get; set; }
    }
}
