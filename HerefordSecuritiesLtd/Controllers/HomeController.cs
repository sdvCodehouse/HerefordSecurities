using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Index()
        {
            await LogVisitAsync("Home Page");

            IndexViewModel model;
            if (CachingService.IsActive && CachingService.HasKey("IndexViewModel"))
            {
                model = CachingService.GetFromCache<IndexViewModel>("IndexViewModel");
                if (model != null)
                {
                    return View(model);
                }
            }
            model = new IndexViewModel {SiteData = _db.SiteData.FirstOrDefault()};
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
        public async Task<ActionResult> Services()
        {
            await LogVisitAsync("Services");

            ServicesViewModel model;
            if (CachingService.IsActive && CachingService.HasKey("ServicesViewModel"))
            {
                model = CachingService.GetFromCache<ServicesViewModel>("ServicesViewModel");
                if (model != null)
                {
                    return View(model);
                }
            }

            model = new ServicesViewModel()
            {
                SiteData = _db.SiteData.FirstOrDefault()
            };
            model.ServicesProvided = _db.GetServicesProvidedForSite(model.SiteData.Id).ToList();
            model.Qualifications = _db.GetQualifications(model.SiteData.Id).ToList();

            CachingService.InsertToCache("ServicesViewModel", model);

            return View(model);
        }

        // GET: Home
        public async Task<ActionResult> ContactMe()
        {
            await LogVisitAsync("ContactMe");

            ContactViewModel model;
            if (CachingService.IsActive && CachingService.HasKey("ContactViewModel"))
            {
                model = CachingService.GetFromCache<ContactViewModel>("ContactViewModel");
                if (model != null)
                {
                    return View(model);
                }
            }

            model = new ContactViewModel()
            {
                SiteData = _db.SiteData.FirstOrDefault()
            };
            model.Qualifications = _db.GetQualifications(model.SiteData.Id).ToList();

            CachingService.InsertToCache("ContactViewModel", model);

            return View(model);
        }

        private async Task LogVisitAsync(string pageVisited)
        {
            if (Request == null || _db.MaxSiteVisitRecordingsReached)
            {
                return;
            }
            var geoLocationService = new GeolocationService(Request);
            var geoLocation = await geoLocationService.GetLocationAsync();

            _db.RecordPageVisit(new SiteVisit
            {
                PageVisited = pageVisited,
                VisitTimestamp = DateTime.Now,
                VisitInfo = geoLocation.ToString()
            });
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