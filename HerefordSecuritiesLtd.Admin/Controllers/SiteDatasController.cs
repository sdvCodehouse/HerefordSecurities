using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HerefordSecuritiesLtd.Entities;

namespace HerefordSecuritiesLtd.Admin.Controllers
{
    public class SiteDatasController : Controller
    {
        private HerefordSecuritiesDb db = new HerefordSecuritiesDb();

        // GET: SiteDatas
        public async Task<ActionResult> Index()
        {
            return View(await db.SiteData.ToListAsync());
        }

        // GET: SiteDatas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteData siteData = await db.SiteData.FindAsync(id);
            if (siteData == null)
            {
                return HttpNotFound();
            }
            return View(siteData);
        }

        // GET: SiteDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SiteDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,IntroLead,Intro,Education,ProfessionalQuals,Expertise,Interests")] SiteData siteData)
        {
            if (ModelState.IsValid)
            {
                db.SiteData.Add(siteData);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(siteData);
        }

        // GET: SiteDatas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteData siteData = await db.SiteData.FindAsync(id);
            if (siteData == null)
            {
                return HttpNotFound();
            }
            return View(siteData);
        }

        // POST: SiteDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,IntroLead,Intro,Education,ProfessionalQuals,Expertise,Interests")] SiteData siteData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siteData).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(siteData);
        }

        // GET: SiteDatas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteData siteData = await db.SiteData.FindAsync(id);
            if (siteData == null)
            {
                return HttpNotFound();
            }
            return View(siteData);
        }

        // POST: SiteDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SiteData siteData = await db.SiteData.FindAsync(id);
            db.SiteData.Remove(siteData);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
