using System;
using System.Collections.Generic;
using System.Text;

namespace WikipediaChallenge.Domain.Models
{
    /// <summary>
    /// Pageview collection class.
    /// </summary>
    public class PageViewCollection : IDisposable
    {
        public List<PageViewEntry> Data;
        private DateTime? PeriodDate;
        public string StrPeriodDate;
        /// <summary>
        /// constructor.
        /// </summary>
        public PageViewCollection() => Data = new List<PageViewEntry>(); 
        /// <summary>
        /// Pageview collection Date time period / hour.
        /// </summary>
        /// <param name="periodDate"></param>
        public PageViewCollection(DateTime periodDate)
        {
            Data = new List<PageViewEntry>();
            PeriodDate = periodDate;
            StrPeriodDate = periodDate.ToString("yyyyMMdd");
        }  
        /// <summary>
        /// set period date.
        /// </summary>
        /// <param name="periodDate"></param>
        public void SetPeriodDate(DateTime periodDate)
        {
            PeriodDate = periodDate;
            StrPeriodDate = periodDate.ToString("yyyyMMdd");
        }
        /// <summary>
        /// get period date.
        /// </summary>
        /// <returns></returns>
        public string GetPeriodDate()
        {
            return StrPeriodDate;
        }
        /// <summary>
        /// add page view.
        /// </summary>
        /// <param name="entry"></param>
        public void AddPageView(PageViewEntry entry)
        {
            if (Data != null)
                Data.Add(entry);
        }
        /// <summary>
        /// clean memory.
        /// </summary>
        public void Dispose() => Data = null;
        
        
    }
}
