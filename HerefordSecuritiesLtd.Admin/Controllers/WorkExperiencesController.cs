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
    public class WorkExperiencesController : Controller
    {
        private HerefordSecuritiesDb db = new HerefordSecuritiesDb();

        // GET: WorkExperiences
        public async Task<ActionResult> Index()
        {
            return View(await db.WorkExperiences.ToListAsync());
        }

        // GET: WorkExperiences/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkExperience workExperience = await db.WorkExperiences.FindAsync(id);
            if (workExperience == null)
            {
                return HttpNotFound();
            }
            return View(workExperience);
        }

        // GET: WorkExperiences/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkExperiences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Client,ClientWeblink,DateFrom,DateTo,ClientAdditional,Position,KeySkills,Narrative,SiteDataId,IsActive,IsRecent")] WorkExperience workExperience)
        {
            if (ModelState.IsValid)
            {
                db.WorkExperiences.Add(workExperience);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(workExperience);
        }

        // GET: WorkExperiences/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkExperience workExperience = await db.WorkExperiences.FindAsync(id);
            if (workExperience == null)
            {
                return HttpNotFound();
            }
            return View(workExperience);
        }

        // POST: WorkExperiences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Client,ClientWeblink,DateFrom,DateTo,ClientAdditional,Position,KeySkills,Narrative,SiteDataId,IsActive,IsRecent")] WorkExperience workExperience)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workExperience).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(workExperience);
        }

        // GET: WorkExperiences/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkExperience workExperience = await db.WorkExperiences.FindAsync(id);
            if (workExperience == null)
            {
                return HttpNotFound();
            }
            return View(workExperience);
        }

        // POST: WorkExperiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            WorkExperience workExperience = await db.WorkExperiences.FindAsync(id);
            db.WorkExperiences.Remove(workExperience);
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
