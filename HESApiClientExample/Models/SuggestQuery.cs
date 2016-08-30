using System;
using System.ComponentModel.DataAnnotations;

namespace HESApiClientExample.Models
{
    public class SuggestQuery
    {
        /// <summary>
        /// The user's search query string
        /// </summary>
        [Required]
        public string Query { get; set; }

        /// <summary>
        /// The number of suggestions to return in the response. Defaults to 10.
        /// </summary>
        [Range(1, 50)]
        public int ItemsCount { get; set; }


        public SuggestQuery()
        {
            Query = String.Empty;
            ItemsCount = 10;
        }
    }
}