using System.Collections.Generic;
using HerefordSecuritiesLtd.Entities;

namespace HerefordSecuritiesLtd.Models
{
    public class IndexViewModel
    {
        public SiteData SiteData { get; set; }
        public IEnumerable<WorkExperience> WorkExperiences { get; set; }
    }
}