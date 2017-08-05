using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HerefordSecuritiesLtd.Entities;
using HerefordSecuritiesLtd.Models;

namespace HerefordSecuritiesLtd.Controllers
{
    public class HomeController : Controller
    {
        private HerefordSecuritiesDb _db = new HerefordSecuritiesDb();
        // GET: Home
        public ActionResult Index()
        {
            var model = new IndexViewModel
            {
                SiteData = _db.SiteData.FirstOrDefault()
            };
            model.Achievements = _db.GetAchievementsForSite(model.SiteData.Id).ToList();

            model.RecentWorkExperiences = _db.GetRecentWorkExperiencesForSite(model.SiteData.Id).ToList();
            GetWebsitesDeveloped(model.RecentWorkExperiences);

            model.ArchivedWorkExperiences = _db.GetArchivedWorkExperiencesForSite(model.SiteData.Id).ToList();
            GetWebsitesDeveloped(model.ArchivedWorkExperiences);

            return View(model);
        }

        private void GetWebsitesDeveloped(IEnumerable<WorkExperience> workExperiences)
        {
            foreach (var workExperience in workExperiences)
            {
                workExperience.Websites = _db.GetWebsites(workExperience.Id).ToList();
            }
        }

        // GET: Home
        public ActionResult Services()
        {
            return View();
        }

        // GET: Home
        public ActionResult ContactMe()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}