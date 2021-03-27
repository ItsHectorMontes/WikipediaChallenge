using System;
using System.Collections.Generic;
using System.Text;

namespace WikipediaChallenge.Infrastructure.Models
{
    /// <summary>
    /// Language Domain count Class.
    /// </summary>
    public class LanguageDomainCount
    {
        public DateTime Period { get; set; }
        public string LanguageCode { get; set; }
        public string Domain { get; set; }
        public uint ViewCount { get; set; }

        public override string ToString()
        {
            return string.Concat("\t", 
                Period.ToString("hh tt"),
                "\t", LanguageCode, 
                "\t\t", Domain,
                "\t", ViewCount);
        }
    }
}
