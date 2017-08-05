using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HerefordSecuritiesLtd.Entities
{
    public class HerefordSecuritiesDb : DbContext
    {
        public HerefordSecuritiesDb() : base("MySqlConnection")
        { }

        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<ServiceProvided> ServicesProvided { get; set; }
        public DbSet<SiteData> SiteData { get; set; }
        public DbSet<ServiceImage> ServiceImages { get; set; }
        public DbSet<Website> Websites { get; set; }
        public DbSet<Achievement> Achievements { get; set; }

        public IEnumerable<WorkExperience> GetRecentWorkExperiencesForSite(int siteId)
        {
            return WorkExperiences.Where(w => w.SiteDataId == siteId && w.IsActive && w.IsRecent)
                .OrderByDescending(s => s.DateFrom);
        }

        public IEnumerable<WorkExperience> GetArchivedWorkExperiencesForSite(int siteId)
        {
            return WorkExperiences.Where(w => w.SiteDataId == siteId && w.IsActive && !w.IsRecent)
                .OrderByDescending(s => s.DateFrom);
        }

        public IEnumerable<Website> GetWebsites(int workExperienceId)
        {
            return Websites.Where(w => w.WorkExperienceId == workExperienceId)
                .OrderBy(w => w.DisplayOrder);
        }

        public IEnumerable<Achievement> GetAchievementsForSite(int siteId)
        {
            return Achievements.Where(s => s.siteDataId == siteId && s.IsActive);
        }

    }
}