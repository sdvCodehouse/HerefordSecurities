using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HerefordSecuritiesLtd.Entities
{
    public class HerefordSecuritiesDb : DbContext
    {
        private int _visitCount;
        public HerefordSecuritiesDb() : base("MySqlConnection")
        {
            _visitCount = SiteVisits.Count();
        }

        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<ServiceProvided> ServicesProvided { get; set; }
        public DbSet<SiteData> SiteData { get; set; }
        public DbSet<Website> Websites { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<SiteVisit> SiteVisits { get; set; }

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
            return Achievements.Where(s => s.SiteDataId == siteId && s.IsActive)
                .OrderBy(s => s.DisplayOrder);
        }

        public IEnumerable<ServiceProvided> GetServicesProvidedForSite(int siteId)
        {
            return ServicesProvided.Where(s => s.SiteDataId == siteId && s.IsActive)
                .OrderBy(s => s.DisplayOrder);
        }

        public void RecordPageVisit(SiteVisit siteVisit)
        {
            if (!MaxSiteVisitRecordingsReached)
            {
                SiteVisits.Add(siteVisit);
                SaveChanges();
                _visitCount++;
            }
        }

        public bool MaxSiteVisitRecordingsReached
        {
            get
            {
                // added max recordings to control the size of the visitor log to prevent abusive behaviour
                // todo set this value in config
                int maxrecordings = 1000;
                return _visitCount > maxrecordings;
            }
        }

        public IEnumerable<Qualification> GetQualifications(int siteId)
        {
            return Qualifications.Where(s => s.SiteDataId == siteId && s.IsActive)
                .OrderBy(s => s.DisplayOrder);
        }

    }
}