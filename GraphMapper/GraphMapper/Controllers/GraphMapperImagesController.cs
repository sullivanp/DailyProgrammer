using GraphMapper.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GraphMapper.Controllers
{
    public class GraphMapperImagesController : Controller
    {
        private GraphMapperContext db = new GraphMapperContext();

        public ActionResult GetImageFromColor(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Color color = db.Colors.Find(id);
            if (color == null)
            {
                return HttpNotFound();
            }
            string imageFilename = Resources.ColorImageShortName;
            string imagePath = Resources.ImageFilePath;
            string imageTypeExtension = Resources.DefaultImageTypeExtension;
            string imageSeparator = Resources.DefaultFileExtensionSeparator;

            MemoryStream imageData = CommonControllerUtils.RecolorImage(
                Server.MapPath(Url.Content(imagePath + imageFilename + imageSeparator + imageTypeExtension)),
                System.Drawing.Color.Black,
                color.ToSystemColor(),
                System.Drawing.Color.Empty,
                System.Drawing.Color.Empty,
                null
            );
            string mimeType = System.Web.MimeMapping.GetMimeMapping(imageFilename + imageSeparator + imageTypeExtension);

            return File(imageData.ToArray(), mimeType);
        }

        public ActionResult GetImageFromMapElement(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapElement mapElement = db.MapElements.Find(id);
            if (mapElement == null)
            {
                return HttpNotFound();
            }

            string imageFilename = mapElement.Shape.FileName;
            string imagePath = Resources.ImageFilePath;
            string imageTypeExtension = mapElement.Shape.TypeExtension;
            string imageSeparator = mapElement.Shape.FileNameExtensionSeparator;

            MemoryStream imageData = CommonControllerUtils.RecolorImage(
                Server.MapPath(Url.Content(imagePath + imageFilename)),
                System.Drawing.Color.Black,
                mapElement.ForegroundColor.ToSystemColor(),
                System.Drawing.Color.White,
                mapElement.BackgroundColor.ToSystemColor(),
                null
            );
            String mimeType = System.Web.MimeMapping.GetMimeMapping(imageFilename + imageSeparator + imageTypeExtension);

            int imageWidth = CommonControllerUtils.GetImageWidth(
                Server.MapPath(Url.Content(imagePath + imageFilename)));

            int imageHeight = CommonControllerUtils.GetImageHeight(
                Server.MapPath(Url.Content(imagePath + imageFilename)));

            //return View();
            //return "id: " + id + " row: " + row + " column " + column + " ext: " + ext;
            return File(imageData.ToArray(), mimeType);
        }

        public ActionResult GetImageFromShape(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shape shape = db.Shapes.Find(id);
            if (shape == null)
            {
                return HttpNotFound();
            }
            string imageFilename = shape.ShortName;
            string imagePath = Resources.ImageFilePath;
            string imageTypeExtension = Resources.DefaultImageTypeExtension;
            string imageSeparator = Resources.DefaultFileExtensionSeparator;

            MemoryStream imageData = CommonControllerUtils.RecolorImage(
                Server.MapPath(Url.Content(imagePath + imageFilename + imageSeparator + imageTypeExtension)),
                System.Drawing.Color.Empty,
                System.Drawing.Color.Empty,
                System.Drawing.Color.Empty,
                System.Drawing.Color.Empty,
                null
            );
            string mimeType = System.Web.MimeMapping.GetMimeMapping(imageFilename + imageSeparator + imageTypeExtension);

            return File(imageData.ToArray(), mimeType);
        }

        // GET: GraphMapperImages
        public ActionResult Index()
        {
            return View();
        }

        // GET: GraphMapperImages/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GraphMapperImages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GraphMapperImages/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GraphMapperImages/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GraphMapperImages/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GraphMapperImages/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GraphMapperImages/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
