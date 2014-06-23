using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GraphMapper.Models;

namespace GraphMapper.Controllers
{
    public class GraphMapperController : Controller
    {
        private GraphMapperDBContext db = new GraphMapperDBContext();

        // GET: GraphMapper
        public ActionResult Index()
        {
            return View(db.GraphMappers.ToList());
        }

        // GET: GraphMapper/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GraphMapperApp graphMapperApp = db.GraphMappers.Find(id);
            if (graphMapperApp == null)
            {
                return HttpNotFound();
            }
            return View(graphMapperApp);
        }

        // GET: GraphMapper/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GraphMapper/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GraphMapperID")] GraphMapperApp graphMapperApp)
        {
            if (ModelState.IsValid)
            {
                db.GraphMappers.Add(graphMapperApp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(graphMapperApp);
        }

        // GET: GraphMapper/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GraphMapperApp graphMapperApp = db.GraphMappers.Find(id);
            if (graphMapperApp == null)
            {
                return HttpNotFound();
            }
            return View(graphMapperApp);
        }

        // POST: GraphMapper/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GraphMapperID")] GraphMapperApp graphMapperApp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(graphMapperApp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(graphMapperApp);
        }

        // GET: GraphMapper/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GraphMapperApp graphMapperApp = db.GraphMappers.Find(id);
            if (graphMapperApp == null)
            {
                return HttpNotFound();
            }
            return View(graphMapperApp);
        }

        // POST: GraphMapper/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GraphMapperApp graphMapperApp = db.GraphMappers.Find(id);
            db.GraphMappers.Remove(graphMapperApp);
            db.SaveChanges();
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
