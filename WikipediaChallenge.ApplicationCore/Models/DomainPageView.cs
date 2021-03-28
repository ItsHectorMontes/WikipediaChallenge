using System;
using System.Collections.Generic;
using System.Text;

namespace WikipediaChallenge.ApplicationCore.Models
{
    /// <summary>
    /// Domain page view class.
    /// </summary>
    public class DomainPageView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }        
        public string TrailingPart { get; set; }
        
    }
}
