using System.Collections.Generic;
using HerefordSecuritiesLtd.Entities;

namespace HerefordSecuritiesLtd.Models
{
    public class IndexViewModel
    {
        public SiteData SiteData { get; set; }
        public IEnumerable<WorkExperience> RecentWorkExperiences { get; set; }
        public IEnumerable<WorkExperience> ArchivedWorkExperiences { get; set; }
        public IEnumerable<Achievement> Achievements { get; set; }
    }
}