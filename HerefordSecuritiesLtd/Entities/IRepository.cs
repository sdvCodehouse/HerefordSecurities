using System.Collections.Generic;

namespace HerefordSecuritiesLtd.Entities
{
    public interface IRepository
    {
        SiteData SiteData { get; set; }
        ICollection<WorkExperience> WorkExperiences { get; set; }
        ICollection<ServiceProvided> ServicesProvided { get; set; }
    }
}
