using System.Collections.Generic;
using HerefordSecuritiesLtd.Entities;

namespace HerefordSecuritiesLtd.Models
{
    public class ContactViewModel
    {
        public SiteData SiteData { get; set; }
        public IEnumerable<Qualification> Qualifications { get; set; }
    }
}