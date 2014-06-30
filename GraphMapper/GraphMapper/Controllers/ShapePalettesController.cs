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
    public class ShapePalettesController : Controller
    {
        private GraphMapperContext db = new GraphMapperContext();

        // GET: ShapePalettes
        public ActionResult Index()
        {
            return View(db.ShapePalettes.ToList());
        }

        // GET: ShapePalettes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShapePalette shapePalette = db.ShapePalettes.Find(id);
            if (shapePalette == null)
            {
                return HttpNotFound();
            }

            ViewBag.ImageFilenames = new string[shapePalette.Rows, shapePalette.Columns];
            ViewBag.ImageLefts = new int[shapePalette.Rows, shapePalette.Columns];
            ViewBag.ImageTops = new int[shapePalette.Rows, shapePalette.Columns];
            foreach (Shape shape in shapePalette.Shapes)
            {
                string imageFilename = shape.FileName;
                string imagePath = Resources.ImageFilePath;
                string imageTypeExtension = shape.TypeExtension;
                string imageSeparator = shape.FileNameExtensionSeparator;
                string imageControllerName = "GraphMapperImages";
                string imageActionName = "GetImageFromShape";

                int imageWidth = CommonControllerUtils.GetImageWidth(
                    Server.MapPath(Url.Content(imagePath + imageFilename)));

                int imageHeight = CommonControllerUtils.GetImageHeight(
                    Server.MapPath(Url.Content(imagePath + imageFilename)));

                ViewBag.ImageFilenames[shape.Row, shape.Column] = "/" + imageControllerName + "/" + imageActionName + "/" + shape.ID;
                ViewBag.ImageLefts[shape.Row, shape.Column] = imageWidth * shape.Column;
                ViewBag.ImageTops[shape.Row, shape.Column] = imageHeight * shape.Row;
                ViewBag.ImageWidth = imageWidth;
                ViewBag.ImageHeight = imageHeight;
                ViewBag.ShapePaletteWidth = imageWidth * shapePalette.Columns;
                ViewBag.ShapePaletteHeight = imageHeight * shapePalette.Rows;
            }

            return View(shapePalette);
        }

        // GET: ShapePalettes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShapePalettes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Order,Rows,Columns")] ShapePalette shapePalette)
        {
            if (ModelState.IsValid)
            {
                db.ShapePalettes.Add(shapePalette);
                shapePalette.Updated = shapePalette.Created = DateTime.Now;
                shapePalette.Shapes = new List<Shape>(shapePalette.Rows * shapePalette.Columns);
                for (int row = 0; row != shapePalette.Rows; row++)
                {
                    for (int column = 0; column != shapePalette.Columns; column++)
                    {
                        shapePalette.Shapes.Add(
                            new Shape()
                            {
                                Row = row,
                                Column = column,
                                FileNameExtensionSeparator = Resources.DefaultFileExtensionSeparator,
                                ShortName = Resources.DefaultImageShortName,
                                TypeExtension = Resources.DefaultImageTypeExtension
                            }
                        );
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shapePalette);
        }

        // GET: ShapePalettes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShapePalette shapePalette = db.ShapePalettes.Find(id);
            if (shapePalette == null)
            {
                return HttpNotFound();
            }
            ViewBag.ImageFilenames = new string[shapePalette.Rows, shapePalette.Columns];
            ViewBag.ImageLefts = new int[shapePalette.Rows, shapePalette.Columns];
            ViewBag.ImageTops = new int[shapePalette.Rows, shapePalette.Columns];
            foreach (Shape shape in shapePalette.Shapes)
            {
                string imageFilename = shape.FileName;
                string imagePath = Resources.ImageFilePath;
                string imageTypeExtension = shape.TypeExtension;
                string imageSeparator = shape.FileNameExtensionSeparator;
                string imageControllerName = "GraphMapperImages";
                string imageActionName = "GetImageFromShape";

                int imageWidth = CommonControllerUtils.GetImageWidth(
                    Server.MapPath(Url.Content(imagePath + imageFilename)));

                int imageHeight = CommonControllerUtils.GetImageHeight(
                    Server.MapPath(Url.Content(imagePath + imageFilename)));

                ViewBag.ImageFilenames[shape.Row, shape.Column] = "/" + imageControllerName + "/" + imageActionName + "/" + shape.ID;
                ViewBag.ImageLefts[shape.Row, shape.Column] = imageWidth * shape.Column;
                ViewBag.ImageTops[shape.Row, shape.Column] = imageHeight * shape.Row;
                ViewBag.ImageWidth = imageWidth;
                ViewBag.ImageHeight = imageHeight;
                ViewBag.ShapePaletteWidth = imageWidth * shapePalette.Columns;
                ViewBag.ShapePaletteHeight = imageHeight * shapePalette.Rows;
            }
            bool addingShape;
            bool deletingShape;
            string currentUrl;
            try
            {
                addingShape = ViewBag.AddingShape = Profile.GetPropertyValue("AddingShape").ToString().ToLower().StartsWith("t");
                deletingShape = ViewBag.DeletingShape = Profile.GetPropertyValue("DeletingShape").ToString().ToLower().StartsWith("t");
                Profile.SetPropertyValue("OpenShapePaletteID", shapePalette.ID);
            }
            catch (System.Configuration.SettingsPropertyNotFoundException)
            {
                Profile.SetPropertyValue("AddingShape", false);
                addingShape = ViewBag.AddingShape = false;
                Profile.SetPropertyValue("DeletingShape", false);
                deletingShape = ViewBag.DeletingShape = false;
            }
            if(addingShape)
            {
                Profile.SetPropertyValue("DeletingShape", false);
                ViewBag.DeletingShape = false;
                int row = shapePalette.FirstEmptyRow;
                int column = shapePalette.FirstEmptyColumn;

                if (row >= 0 || column >= 0)
                {
                    Shape shape = new Shape
                    {
                        Row = row,
                        Column = column
                    };

                    shapePalette.Shapes.Add(shape);
                    db.Entry(shape).State = EntityState.Added;
                    db.Entry(shapePalette).State = EntityState.Modified;
                    db.SaveChanges();
                    currentUrl = HttpContext.Request.Path;
                    Profile.SetPropertyValue("CurrentUrl", currentUrl);
                    return Redirect("/Shapes/Edit/" + shape.ID);
                }
                else
                {
                    Profile.SetPropertyValue("AddingColor", false);
                }
            }
            else if (deletingShape)
            {
                Profile.SetPropertyValue("AddingShape", false);
                ViewBag.AddingShape = false;
            }
            currentUrl = HttpContext.Request.Path;
            Profile.SetPropertyValue("CurrentUrl", currentUrl);
            return View(shapePalette);
        }

        // POST: ShapePalettes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Order,Rows,Columns")] ShapePalette shapePalette)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shapePalette).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shapePalette);
        }

        // GET: ShapePalettes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShapePalette shapePalette = db.ShapePalettes.Find(id);
            if (shapePalette == null)
            {
                return HttpNotFound();
            }
            return View(shapePalette);
        }

        // POST: ShapePalettes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShapePalette shapePalette = db.ShapePalettes.Find(id);
            db.ShapePalettes.Remove(shapePalette);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteShape(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shape shape = db.Shapes.Find(id);
            ShapePalette shapePalette = db.ShapePalettes.Find(Profile.GetPropertyValue("OpenShapePaletteID"));
            if (shape == null || shapePalette == null)
            {
                return HttpNotFound();
            }
            shapePalette.Shapes.Remove(shape);
            db.ShapePalettes.Find(shapePalette.ID).Updated = DateTime.Now;
            db.SaveChanges();
            if (HttpContext.Request.UrlReferrer == null)
                try
                {
                    return Redirect(Profile.GetPropertyValue("CurrentUrl").ToString());
                }
                catch (System.Configuration.SettingsPropertyNotFoundException)
                {
                    return Redirect("/");
                }
            else
            {
                return Redirect(HttpContext.Request.UrlReferrer.AbsolutePath);
            }
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
