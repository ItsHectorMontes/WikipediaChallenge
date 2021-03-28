using System;
using System.Linq;
using WikipediaChallenge.Infrastructure.Models;

namespace WikipediaChallenge.Infrastructure.Repository
{   
    /// <summary>
    /// get data to console.
    /// </summary>
    public class DataToConsole
    {
        const string LanguageDomainHeader = "\t Period \t Language \t Domain \t ViewCount";
        const string LanguagePageMaxViewHeader = "\t Period \t Page \t\t ViewCount";
        /// <summary>
        /// Display count of language domain
        /// </summary>
        /// <param name="report"></param>
        public static void DisplayLanguageDomainCount(LanguageDomainCountReport report)
        {
            Console.WriteLine("\n -Language & Domain count");
            Console.WriteLine(LanguageDomainHeader);

            foreach (LanguageDomainCount item in report.Data.OrderByDescending(l => l.Period))
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("\n\n");
        }
        /// <summary>
        /// Display language page max count.
        /// </summary>
        /// <param name="report"></param>
        public static void DisplayLanguagePageMaxCount(LanguagePageCountReport report)
        {
            Console.WriteLine("\n -Language page max view count");
            Console.WriteLine(LanguagePageMaxViewHeader);
            foreach (LanguagePageCount item in report.Data.OrderByDescending(l => l.Period))
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("\n\n");
        }
    }
}
