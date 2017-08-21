using System;

namespace HerefordSecuritiesLtd.Entities
{
    public class SiteVisit
    {
        public int Id { get; set; }
        public string PageVisited { get; set; }
        public DateTime VisitTimestamp { get; set; }
        public string VisitInfo { get; set; }
    }
}

