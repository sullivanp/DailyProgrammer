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
        private GraphMapperContext db = new GraphMapperContext();

        // GET: GraphMapper
        public ActionResult Index()
        {
            return View(db.GraphMaps.ToList());
        }

        // GET: GraphMapper/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GraphMap graphMap = db.GraphMaps.Find(id);
            if (graphMap == null)
            {
                return HttpNotFound();
            }
            return View(graphMap);
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
        public ActionResult Create([Bind(Include = "ID,Rows,Columns,Name")] GraphMap graphMap)
        {
            if (ModelState.IsValid)
            {
                db.GraphMaps.Add(graphMap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(graphMap);
        }

        // GET: GraphMapper/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GraphMap graphMap = db.GraphMaps.Find(id);
            if (graphMap == null)
            {
                return HttpNotFound();
            }
            return View(graphMap);
        }

        // POST: GraphMapper/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Rows,Columns,Name")] GraphMap graphMap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(graphMap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(graphMap);
        }

        // GET: GraphMapper/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GraphMap graphMap = db.GraphMaps.Find(id);
            if (graphMap == null)
            {
                return HttpNotFound();
            }
            return View(graphMap);
        }

        // POST: GraphMapper/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GraphMap graphMap = db.GraphMaps.Find(id);
            db.GraphMaps.Remove(graphMap);
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
