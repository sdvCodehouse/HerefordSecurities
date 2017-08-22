using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HerefordSecuritiesLtd.Entities;
using HerefordSecuritiesLtd.Models;
using HerefordSecuritiesLtd.Services;

namespace HerefordSecuritiesLtd.Controllers
{
    public class HomeController : Controller
    {
        private readonly HerefordSecuritiesDb _db = new HerefordSecuritiesDb();
        // GET: Home
        public ActionResult Index()
        {
            var model = CachingService.GetFromCache<IndexViewModel>("HomeIndex");

            if (model == null)
            {
                model = new IndexViewModel { SiteData = _db.SiteData.FirstOrDefault() };
                if (model.SiteData != null)
                {
                    model.Achievements = _db.GetAchievementsForSite(model.SiteData.Id).ToList();
                    model.Qualifications = _db.GetQualifications(model.SiteData.Id).ToList();

                    model.RecentWorkExperiences = _db.GetRecentWorkExperiencesForSite(model.SiteData.Id).ToList();
                    LoadWebsitesDeveloped(model.RecentWorkExperiences);

                    model.ArchivedWorkExperiences = _db.GetArchivedWorkExperiencesForSite(model.SiteData.Id).ToList();
                    LoadWebsitesDeveloped(model.ArchivedWorkExperiences);
                }
                CachingService.InsertToCache("IndexViewModel", model);
            }
            
            return View(model);
        }

        
        private void LoadWebsitesDeveloped(IEnumerable<WorkExperience> workExperiences)
        {
            foreach (var workExperience in workExperiences)
            {
                workExperience.Websites = _db.GetWebsites(workExperience.Id).ToList();
            }
        }

        // GET: Home
        public ActionResult Services()
        {
            var model = CachingService.GetFromCache<ServicesViewModel>("HomeServices");

            if (model == null)
            {
                model = new ServicesViewModel
                {
                    SiteData = _db.SiteData.FirstOrDefault()
                };
                model.ServicesProvided = _db.GetServicesProvidedForSite(model.SiteData.Id).ToList();
                model.Qualifications = _db.GetQualifications(model.SiteData.Id).ToList();

                CachingService.InsertToCache("ServicesViewModel", model);
            }
            return View(model);
        }

        // GET: Home
        public ActionResult ContactMe()
        {
            var model = CachingService.GetFromCache<ContactViewModel>("HomeServices");

            if (model == null)
            {
                model = new ContactViewModel
                {
                    SiteData = _db.SiteData.FirstOrDefault()
                };
                model.Qualifications = _db.GetQualifications(model.SiteData.Id).ToList();

                CachingService.InsertToCache("ContactViewModel", model);
            }
            return View(model);
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