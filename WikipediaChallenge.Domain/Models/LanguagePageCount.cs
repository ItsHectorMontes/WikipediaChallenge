using System;
using System.Collections.Generic;
using System.Text;

namespace WikipediaChallenge.Infrastructure.Models
{
    /// <summary>
    /// Language page count class.
    /// </summary>
    public class LanguagePageCount
    {
        public DateTime Period { get; set; }
        public string Page { get; set; }
        public uint ViewCount { get; set; }

        public override string ToString()
        {
            return string.Concat("\t", 
                Period.ToString("hh tt"),
                "\t", 
                Page, "\t", 
                ViewCount);
        }
    }
}
