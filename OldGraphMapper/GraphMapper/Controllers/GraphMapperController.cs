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
        private GridDBContext db = new GridDBContext();

        // GET: GraphMapper
        public ActionResult Index()
        {
            return View(db.Grids.ToList());
        }

        // GET: GraphMapper/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grid grid = db.Grids.Find(id);
            if (grid == null)
            {
                return HttpNotFound();
            }
            ViewData["MapCols"] = grid.Cols;
            ViewData["MapRows"] = grid.Rows;
            return View(grid);
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
        public ActionResult Create([Bind(Include = "GridID,Rows,Cols")] Grid grid)
        {
            if (ModelState.IsValid)
            {
                db.Grids.Add(grid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grid);
        }

        // GET: GraphMapper/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grid grid = db.Grids.Find(id);
            if (grid == null)
            {
                return HttpNotFound();
            }
            return View(grid);
        }

        // POST: GraphMapper/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GridID,Rows,Cols")] Grid grid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grid).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grid);
        }

        // GET: GraphMapper/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grid grid = db.Grids.Find(id);
            if (grid == null)
            {
                return HttpNotFound();
            }
            return View(grid);
        }

        // POST: GraphMapper/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grid grid = db.Grids.Find(id);
            db.Grids.Remove(grid);
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
