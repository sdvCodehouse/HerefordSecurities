using System.Collections.Generic;
using HerefordSecuritiesLtd.Entities;

namespace HerefordSecuritiesLtd.Models
{
    public class ServicesViewModel
    {
        public SiteData SiteData { get; set; }
        public IEnumerable<ServiceProvided> ServicesProvided { get; set; }
        public IEnumerable<Qualification> Qualifications { get; set; }

        public string ImageStyle(int index)
        {
            return index % 2 == 0 ? "pull-right" : "pull-left";
        }
    }
}