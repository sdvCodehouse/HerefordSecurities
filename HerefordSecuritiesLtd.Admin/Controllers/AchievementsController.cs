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
    public class AchievementsController : Controller
    {
        private HerefordSecuritiesDb db = new HerefordSecuritiesDb();

        // GET: Achievements
        public async Task<ActionResult> Index()
        {
            return View(await db.Achievements.ToListAsync());
        }

        // GET: Achievements/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Achievement achievement = await db.Achievements.FindAsync(id);
            if (achievement == null)
            {
                return HttpNotFound();
            }
            return View(achievement);
        }

        // GET: Achievements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Achievements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Narrative,DisplayOrder,IsActive,SiteDataId")] Achievement achievement)
        {
            if (ModelState.IsValid)
            {
                db.Achievements.Add(achievement);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(achievement);
        }

        // GET: Achievements/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Achievement achievement = await db.Achievements.FindAsync(id);
            if (achievement == null)
            {
                return HttpNotFound();
            }
            return View(achievement);
        }

        // POST: Achievements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Narrative,DisplayOrder,IsActive,SiteDataId")] Achievement achievement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(achievement).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(achievement);
        }

        // GET: Achievements/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Achievement achievement = await db.Achievements.FindAsync(id);
            if (achievement == null)
            {
                return HttpNotFound();
            }
            return View(achievement);
        }

        // POST: Achievements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Achievement achievement = await db.Achievements.FindAsync(id);
            db.Achievements.Remove(achievement);
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
