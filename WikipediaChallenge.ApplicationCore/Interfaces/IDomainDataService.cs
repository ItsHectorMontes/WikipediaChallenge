using System.Collections.Generic;
using WikipediaChallenge.Domain.Models;

namespace WikipediaChallenge.ApplicationCore.Interfaces
{
    /// <summary>
    /// Interface to Domain data service.
    /// </summary>
    public interface IDomainDataService
    {
        IEnumerable<DomainPageView> GetAllDomains();
        DomainPageView GetDomainByCode(string code);
        string GetDomainNameByCode(string code);
        DomainPageView GetDomainById(int id);
        string GetLanguage(string code);
    }
}
