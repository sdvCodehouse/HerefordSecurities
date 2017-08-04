using System.Data.Entity;

namespace HerefordSecuritiesLtd.Entities
{
    public class HerefordSecuritiesDb : DbContext
    {
        public HerefordSecuritiesDb() : base("MySqlConnection")
        { }

        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<ServiceProvided> ServicesProvided { get; set; }
        public DbSet<SiteData> SiteData { get; set; }

        public System.Data.Entity.DbSet<HerefordSecuritiesLtd.Entities.ServiceImage> ServiceImages { get; set; }

        public System.Data.Entity.DbSet<HerefordSecuritiesLtd.Entities.Website> Websites { get; set; }

    }
}