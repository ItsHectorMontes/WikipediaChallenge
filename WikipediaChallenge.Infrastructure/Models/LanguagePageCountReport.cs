using System;
using System.Collections.Generic;
using System.Text;

namespace WikipediaChallenge.Infrastructure.Models
{
    /// <summary>
    /// language page count report class
    /// </summary>
    public class LanguagePageCountReport
    {
        public List<LanguagePageCount> Data { get; set; }
        public LanguagePageCountReport() => Data = new List<LanguagePageCount>();   
    /// <summary>
    /// Add language page.
    /// </summary>
    /// <param name="item"></param>
    public void AddLanguagePage(LanguagePageCount item)
        {
            if (Data != null)
                Data.Add(item);

        }
    }
}
