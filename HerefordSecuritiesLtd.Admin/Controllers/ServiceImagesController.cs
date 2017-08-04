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
    public class ServiceImagesController : Controller
    {
        private HerefordSecuritiesDb db = new HerefordSecuritiesDb();

        // GET: ServiceImages
        public async Task<ActionResult> Index()
        {
            return View(await db.ServiceImages.ToListAsync());
        }

        // GET: ServiceImages/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceImage serviceImage = await db.ServiceImages.FindAsync(id);
            if (serviceImage == null)
            {
                return HttpNotFound();
            }
            return View(serviceImage);
        }

        // GET: ServiceImages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ImageLink,ServiceProvidedId")] ServiceImage serviceImage)
        {
            if (ModelState.IsValid)
            {
                db.ServiceImages.Add(serviceImage);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(serviceImage);
        }

        // GET: ServiceImages/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceImage serviceImage = await db.ServiceImages.FindAsync(id);
            if (serviceImage == null)
            {
                return HttpNotFound();
            }
            return View(serviceImage);
        }

        // POST: ServiceImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ImageLink,ServiceProvidedId")] ServiceImage serviceImage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceImage).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(serviceImage);
        }

        // GET: ServiceImages/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceImage serviceImage = await db.ServiceImages.FindAsync(id);
            if (serviceImage == null)
            {
                return HttpNotFound();
            }
            return View(serviceImage);
        }

        // POST: ServiceImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ServiceImage serviceImage = await db.ServiceImages.FindAsync(id);
            db.ServiceImages.Remove(serviceImage);
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
