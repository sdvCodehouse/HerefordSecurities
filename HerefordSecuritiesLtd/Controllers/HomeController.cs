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
                SiteData = _db.SiteData.FirstOrDefault(),
                WorkExperiences = _db.WorkExperiences.ToList()
            };

            return View(model);
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