using System.Collections.Generic;
using System.Linq;
using WikipediaChallenge.ApplicationCore.Interfaces;
using WikipediaChallenge.Domain.Models;

namespace WikipediaChallenge.Infrastructure.Data
{
    /// <summary>
    /// Wikipedia data domain used to count and order.
    /// </summary>
    public class DataDomain : IDomainDataService
    {
        private readonly List<DomainPageView> _domainPageViews;
        public DataDomain()
        {
            _domainPageViews = new List<DomainPageView>()
            {
                new DomainPageView { Id = 1,  Name = "Wikipedia",   Code = "", TrailingPart = ".wikipedia.org"},
                new DomainPageView { Id = 2,  Name = "Wikibooks", Code = "b", TrailingPart = ".wikibooks.org"},
                new DomainPageView { Id = 3,  Name = "Wiktionary", Code = "d", TrailingPart = ".wiktionary.org"},
                new DomainPageView { Id = 4,  Name = "Wikimedia Foundation", Code = "f", TrailingPart = ".wikimediafoundation.org"},
                new DomainPageView { Id = 5,  Name = "Wikimedia", Code = "m", TrailingPart = ".wikimedia.org"},
                new DomainPageView { Id = 6,  Name = "Whitelisted Project", Code = "mv", TrailingPart = ".m.${WHITELISTED_PROJECT}.org"},
                new DomainPageView { Id = 7,  Name = "Wikinews", Code = "n", TrailingPart = ".wikinews.org"},
                new DomainPageView { Id = 8,  Name = "Wikiquote", Code = "q", TrailingPart = ".wikiquote.org"},
                new DomainPageView { Id = 9,  Name = "Wikisource", Code = "s", TrailingPart = ".wikisource.org"},
                new DomainPageView { Id = 10, Name = "Wikiversity", Code = "v", TrailingPart = ".wikiversity.org"},
                new DomainPageView { Id = 11, Name = "Wikivoyage", Code = "voy", TrailingPart = ".wikivoyage.org"},
                new DomainPageView { Id = 12, Name = "MediaWiki", Code = "w", TrailingPart = ".mediawiki.org"},
                new DomainPageView { Id = 13, Name = "Wikidata", Code = "wd", TrailingPart = ".wikidata.org"}
            };
        }
        /// <summary>
        /// getting all domains.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DomainPageView> GetAllDomains()
        {
            return _domainPageViews;
        }
        /// <summary>
        /// get domain by code.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DomainPageView GetDomainByCode(string code)
        {
           string[] domainParts = code.Split('.');
            string domainCode = "";
            if (domainParts.Length > 1)
                domainCode = domainParts[1]; 
            return _domainPageViews.SingleOrDefault(d => d.Code.Equals(domainCode));
        }
        /// <summary>
        /// get domain by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DomainPageView GetDomainById(int id)
        {
            return _domainPageViews.SingleOrDefault(d => d.Id == id);
        }
        /// <summary>
        /// get domain by code.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetDomainNameByCode(string code)
        {
            string[] domainParts = code.Split('.');
            string domainCode = "";

            if (domainParts.Length > 1)
                domainCode = domainParts[1]; 

            return _domainPageViews.SingleOrDefault(d => d.Code.Equals(domainCode))?.Name;
        }
        /// <summary>
        /// get language.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>

        public string GetLanguage(string code)
        {
             string[] domainParts = code.Split('.');            
            return domainParts[0];
        }
    }
}
