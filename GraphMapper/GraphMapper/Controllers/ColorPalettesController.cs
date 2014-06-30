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
    public class ColorPalettesController : Controller
    {
        private GraphMapperContext db = new GraphMapperContext();

        // GET: ColorPalettes
        public ActionResult Index()
        {
            return View(db.ColorPalettes.ToList());
        }

        // GET: ColorPalettes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColorPalette colorPalette = db.ColorPalettes.Find(id);
            if (colorPalette == null)
            {
                return HttpNotFound();
            }

            ViewBag.ColorPaletteImageFilenames = new string[colorPalette.Rows, colorPalette.Columns];
            ViewBag.ImageLefts = new int[colorPalette.Rows, colorPalette.Columns];
            ViewBag.ImageTops = new int[colorPalette.Rows, colorPalette.Columns];
            foreach (Color color in colorPalette.Colors)
            {
                string colorImageFilename = Resources.ColorImageShortName;
                string colorImagePath = Resources.ColorFilePath;
                string colorImageTypeExtension = Resources.ColorImageTypeExtension;
                string colorImageSeparator = Resources.DefaultFileExtensionSeparator;

                string imageControllerName = "GraphMapperImages";
                string imageActionName = "GetImageFromColor";

                int imageWidth = CommonControllerUtils.GetImageWidth(
                    Server.MapPath(Url.Content(colorImagePath + colorImageFilename + colorImageSeparator + colorImageTypeExtension)));

                int imageHeight = CommonControllerUtils.GetImageHeight(
                    Server.MapPath(Url.Content(colorImagePath + colorImageFilename + colorImageSeparator + colorImageTypeExtension)));

                ViewBag.ColorPaletteImageFilenames[color.Row, color.Column] = "/" + imageControllerName + "/" + imageActionName + "/" + color.ID;
                ViewBag.ImageLefts[color.Row, color.Column] = imageWidth * color.Column;
                ViewBag.ImageTops[color.Row, color.Column] = imageHeight * color.Row;
                ViewBag.ImageWidth = imageWidth;
                ViewBag.ImageHeight = imageHeight;
                ViewBag.ColorPaletteWidth = imageWidth * colorPalette.Columns;
                ViewBag.ColorPaletteHeight = imageHeight * colorPalette.Rows;
            }
            return View(colorPalette);
        }

        // GET: ColorPalettes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ColorPalettes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Order,Rows,Columns")] ColorPalette colorPalette)
        {
            if (ModelState.IsValid)
            {
                db.ColorPalettes.Add(colorPalette);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(colorPalette);
        }

        // GET: ColorPalettes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColorPalette colorPalette = db.ColorPalettes.Find(id);
            if (colorPalette == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColorPaletteImageFilenames = new string[colorPalette.Rows, colorPalette.Columns];
            ViewBag.ImageLefts = new int[colorPalette.Rows, colorPalette.Columns];
            ViewBag.ImageTops = new int[colorPalette.Rows, colorPalette.Columns];
            foreach (Color color in colorPalette.Colors)
            {
                string colorImageFilename = Resources.ColorImageShortName;
                string colorImagePath = Resources.ColorFilePath;
                string colorImageTypeExtension = Resources.ColorImageTypeExtension;
                string colorImageSeparator = Resources.DefaultFileExtensionSeparator;
                string imageControllerName = "GraphMapperImages";
                string imageActionName = "GetImageFromColor";

                int imageWidth = CommonControllerUtils.GetImageWidth(
                    Server.MapPath(Url.Content(colorImagePath + colorImageFilename + colorImageSeparator + colorImageTypeExtension)));

                int imageHeight = CommonControllerUtils.GetImageHeight(
                    Server.MapPath(Url.Content(colorImagePath + colorImageFilename + colorImageSeparator + colorImageTypeExtension)));

                ViewBag.ColorPaletteImageFilenames[color.Row, color.Column] = "/" + imageControllerName + "/" + imageActionName + "/" + color.ID;
                ViewBag.ImageLefts[color.Row, color.Column] = imageWidth * color.Column;
                ViewBag.ImageTops[color.Row, color.Column] = imageHeight * color.Row;
                ViewBag.ImageWidth = imageWidth;
                ViewBag.ImageHeight = imageHeight;
                ViewBag.ColorPaletteWidth = imageWidth * colorPalette.Columns;
                ViewBag.ColorPaletteHeight = imageHeight * colorPalette.Rows;
            }

            bool addingColor;
            bool deletingColor;
            try
            {
                addingColor = ViewBag.AddingColor = Profile.GetPropertyValue("AddingColor").ToString().ToLower().StartsWith("t");
                deletingColor = ViewBag.DeletingColor = Profile.GetPropertyValue("DeletingColor").ToString().ToLower().StartsWith("t");
                Profile.SetPropertyValue("OpenColorPaletteID", colorPalette.ID);
            }
            catch (System.Configuration.SettingsPropertyNotFoundException)
            {
                Profile.SetPropertyValue("AddingColor", false);
                addingColor = ViewBag.AddingColor = false;
                Profile.SetPropertyValue("DeletingColor", false);
                deletingColor = ViewBag.DeletingColor = false;
            }
            string currentUrl;
            if (addingColor)
            {
                Profile.SetPropertyValue("DeletingColor", false);
                ViewBag.DeletingColor = false;

                int row = colorPalette.FirstEmptyRow;
                int column = colorPalette.FirstEmptyColumn;

                if (row >= 0 || column >= 0)
                {
                    Color color = new Color
                        {
                            Red = 0,
                            Green = 0,
                            Blue = 0,
                            Row = row,
                            Column = column
                        };

                    colorPalette.Colors.Add(color);
                    db.Entry(color).State = EntityState.Added;
                    db.Entry(colorPalette).State = EntityState.Modified;
                    db.SaveChanges();
                    currentUrl = HttpContext.Request.Path;
                    Profile.SetPropertyValue("CurrentUrl", currentUrl);
                    return Redirect("/Colors/Edit/" + color.ID);
                } else
                {
                    Profile.SetPropertyValue("AddingColor", false);
                }
            }
            else if (deletingColor)
            {
                Profile.SetPropertyValue("AddingColor", false);
                ViewBag.AddingColor = false;
            }

            currentUrl = HttpContext.Request.Path;
            Profile.SetPropertyValue("CurrentUrl", currentUrl);

            return View(colorPalette);
        }

        // POST: ColorPalettes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Order,Rows,Columns")] ColorPalette colorPalette)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colorPalette).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(colorPalette);
        }

        // GET: ColorPalettes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColorPalette colorPalette = db.ColorPalettes.Find(id);
            if (colorPalette == null)
            {
                return HttpNotFound();
            }
            return View(colorPalette);
        }

        // POST: ColorPalettes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ColorPalette colorPalette = db.ColorPalettes.Find(id);
            db.ColorPalettes.Remove(colorPalette);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteColorFromPalette(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Color color = db.Colors.Find(id);
            ColorPalette colorPalette = db.ColorPalettes.Find(Profile.GetPropertyValue("OpenColorPaletteID"));
            if (colorPalette == null || color == null)
            {
                return HttpNotFound();
            }
            colorPalette.Colors.Remove(db.Colors.Find(id));
            db.ColorPalettes.Find(colorPalette.ID).Updated = DateTime.Now;
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
