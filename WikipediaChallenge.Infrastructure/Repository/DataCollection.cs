using System;
using System.Linq;
using WikipediaChallenge.ApplicationCore.Interfaces;
using WikipediaChallenge.ApplicationCore.Models;
using WikipediaChallenge.Infrastructure.Models;

namespace WikipediaChallenge.Infrastructure.Repository
{
    /// <summary>
    /// Getting data and order to show.
    /// </summary>
    public class DataCollection
    {
        private readonly IDomainDataService _domainDataService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="domainData"></param>
        public DataCollection(IDomainDataService domainData) => _domainDataService = domainData;
        /// <summary>
        /// Get and count language and domain.
        /// </summary>
        /// <param name="periodCollection"></param>
        /// <returns></returns>
        public LanguageDomainCount GetLanguageAndDomainCount(PageViewCollection periodCollection)
        {
            LanguageDomainCount report = new LanguageDomainCount();
            var entry = periodCollection.Data.Where(e => e.ViewCount > 0)
                .GroupBy(x => x.DomainCode)
                .Select(y => new PageViewEntry
                {
                    DomainCode = y.Key,
                    ViewCount = Convert.ToUInt32(y.Sum(s => s.ViewCount)),
                })
                .OrderByDescending(x => x.ViewCount)
                .FirstOrDefault();

            report.Domain = _domainDataService.GetDomainNameByCode(entry.DomainCode); 
            report.LanguageCode = _domainDataService.GetLanguage(entry.DomainCode);
            report.ViewCount = entry.ViewCount;
            return report;
        }
        /// <summary>
        /// get and count language.
        /// </summary>
        /// <param name="periodCollection"></param>
        /// <returns></returns>
        public LanguagePageCount GetLanguagePageCount(PageViewCollection periodCollection)
        {
            LanguagePageCount report = new LanguagePageCount();

            var entry = periodCollection.Data.Where(e => e.ViewCount > 0)
                .GroupBy(x => x.PageTitle)
                .Select(y => new PageViewEntry
                {
                    PageTitle = y.Key,
                    ViewCount = Convert.ToUInt32(y.Sum(s => s.ViewCount)),
                })
                .OrderByDescending(x => x.ViewCount)
                .FirstOrDefault();
            report.Page = entry.PageTitle; 
            report.ViewCount = entry.ViewCount;
            return report;
        }

    }
}
