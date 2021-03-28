using System.Collections.Generic;


namespace WikipediaChallenge.Infrastructure.Models
{
    /// <summary>
    /// Language domagin count report class.
    /// </summary>
    public class LanguageDomainCountReport
    {
        /// <summary>
        /// List Language domain count.
        /// </summary>
        public List<LanguageDomainCount> Data { get; set; }
        public string ProcessIdentifier { get; set; }
        public LanguageDomainCountReport() => Data = new List<LanguageDomainCount>();
        public void AddLanguageDomain(LanguageDomainCount item)
        {
            if (Data != null)
                Data.Add(item);            
        }
    }
}
