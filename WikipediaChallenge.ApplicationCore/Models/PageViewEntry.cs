

namespace WikipediaChallenge.ApplicationCore.Models
{
    /// <summary>
    /// page view entry class.
    /// </summary>
    public class PageViewEntry
    {
        /// <summary>
        /// Domain code
        /// </summary>
        public string DomainCode { get; set; }
        /// <summary>
        /// Page title.
        /// </summary>
        public string PageTitle { get; set; }
        /// <summary>
        /// Viewcount or total.
        /// </summary>
        public uint ViewCount { get; set; }
    }
}
