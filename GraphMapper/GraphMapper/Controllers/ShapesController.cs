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
    public class ShapesController : Controller
    {
        private GraphMapperContext db = new GraphMapperContext();

        // GET: Shapes
        public ActionResult Index()
        {
            return View(db.Shapes.ToList());
        }

        // GET: Shapes/Details/5
        public ActionResult Details(int? id)
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
            return View(shape);
        }

        // GET: Shapes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shapes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ShortName,TypeExtension,FileNameExtensionSeparator,Row,Column")] Shape shape)
        {
            if (ModelState.IsValid)
            {
                db.Shapes.Add(shape);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shape);
        }

        // GET: Shapes/Edit/5
        public ActionResult Edit(int? id)
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

            GraphMap shapeMap;

            if (int.Parse(Profile.GetPropertyValue("OpenShapeMapID").ToString()) == -1)
            {
                Color white = new Color
                {
                    Red = 255,
                    Green = 255,
                    Blue = 255,
                    Name = "White",
                    Row = 1,
                    Column = 0
                };

                Color black = new Color
                {
                    Red = 0,
                    Green = 0,
                    Blue = 0,
                    Name = "Black",
                    Row = 0,
                    Column = 0
                };

                db.Colors.Add(white);
                db.Colors.Add(black);
                db.SaveChanges();

                Shape solidFilledBox = new Shape
                {
                    Row = 0,
                    Column = 0,
                    ShortName = "SolidFilledBox"
                };

                db.Shapes.Add(solidFilledBox);
                db.SaveChanges();

                shapeMap = new GraphMap()
                {
                    Rows = int.Parse(Resources.DefaultShapeHeight),
                    Columns = int.Parse(Resources.DefaultShapeWidth),
                    DefaultColorPalette = new ColorPalette
                    {
                        Rows = 2,
                        Columns = 1,
                        Colors = new List<Color>
                        {
                            black,
                            white
                        }
                    },
                    DefaultShapePalette = new ShapePalette
                    {
                        Rows = 1,
                        Columns = 1,
                        Shapes = new List<Shape>
                        {
                            solidFilledBox
                        }
                    }
                };

                for (int row = 0; row != shapeMap.Rows; row++)
                {
                    for (int column = 0; column != shapeMap.Columns; column++)
                    {
                        shapeMap.MapElements.Add(
                            new MapElement
                            {
                                Row = row,
                                Column = column,
                                BackgroundColor = new Color
                                {
                                    Red = 0,
                                    Green = 0,
                                    Blue = 0,
                                    Name = "Black"
                                },
                                ForegroundColor = new Color
                                {
                                    Red = 255,
                                    Green = 255,
                                    Blue = 255,
                                    Name = "White"
                                },
                                Shape = new Shape
                                {
                                    ShortName = "SolidFilledBox"
                                }
                            }
                        );
                    }
                }

                db.GraphMaps.Add(shapeMap);
                db.SaveChanges();

                Profile.SetPropertyValue("OpenShapeMapID", shapeMap.ID);
            } else
            {
                shapeMap = db.GraphMaps.Find(Profile.GetPropertyValue("OpenShapeMapID"));
            }

            ViewBag.ShapeMap = shapeMap;

            ViewBag.ImageFilenames = new string[shapeMap.Rows, shapeMap.Columns];
            ViewBag.ImageLefts = new int[shapeMap.Rows, shapeMap.Columns];
            ViewBag.ImageTops = new int[shapeMap.Rows, shapeMap.Columns];
            int graphMapImageWidth = 40;
            int graphMapImageHeight = 40;
            foreach (MapElement mapElement in shapeMap.MapElements)
            {
                string imageFilename = mapElement.Shape.FileName;
                string imagePath = Resources.ImageFilePath;
                string imageTypeExtension = mapElement.Shape.TypeExtension;
                string imageSeparator = mapElement.Shape.FileNameExtensionSeparator;
                string imageControllerName = "GraphMapperImages";
                string imageActionName = "GetImageFromMapElement";

                graphMapImageWidth = CommonControllerUtils.GetImageWidth(
                    Server.MapPath(Url.Content(imagePath + imageFilename)));

                graphMapImageHeight = CommonControllerUtils.GetImageHeight(
                    Server.MapPath(Url.Content(imagePath + imageFilename)));

                ViewBag.ImageFilenames[mapElement.Row, mapElement.Column] = "/" + imageControllerName + "/" + imageActionName + "/" + mapElement.ID.ToString();
                ViewBag.ImageLefts[mapElement.Row, mapElement.Column] = graphMapImageWidth * mapElement.Column;
                ViewBag.ImageTops[mapElement.Row, mapElement.Column] = graphMapImageHeight * mapElement.Row;
                ViewBag.ImageWidth = graphMapImageWidth;
                ViewBag.ImageHeight = graphMapImageHeight;
                ViewBag.GraphMapWidth = graphMapImageWidth * shapeMap.Columns;
                ViewBag.GraphMapHeight = graphMapImageHeight * shapeMap.Rows;
            }

            ShapePalette shapePalette = shapeMap.DefaultShapePalette;
            ViewBag.ShapePalette = shapePalette;

            ViewBag.ShapePaletteImageFilenames = new string[shapePalette.Rows, shapePalette.Columns];
            ViewBag.ShapePaletteImageLefts = new int[shapePalette.Rows, shapePalette.Columns];
            ViewBag.ShapePaletteImageTops = new int[shapePalette.Rows, shapePalette.Columns];
            foreach (Shape paletteShape in shapePalette.Shapes)
            {
                string imageFilename = paletteShape.FileName;
                string imagePath = Resources.ImageFilePath;
                string imageTypeExtension = paletteShape.TypeExtension;
                string imageSeparator = paletteShape.FileNameExtensionSeparator;
                string imageControllerName = "GraphMapperImages";
                string imageActionName = "GetImageFromShape";

                int imageWidth = CommonControllerUtils.GetImageWidth(
                    Server.MapPath(Url.Content(imagePath + imageFilename)));

                int imageHeight = CommonControllerUtils.GetImageHeight(
                    Server.MapPath(Url.Content(imagePath + imageFilename)));

                ViewBag.ShapePaletteImageFilenames[paletteShape.Row, paletteShape.Column] = "/" + imageControllerName + "/" + imageActionName + "/" + paletteShape.ID;
                ViewBag.ShapePaletteImageLefts[paletteShape.Row, paletteShape.Column] = imageWidth * paletteShape.Column;
                ViewBag.ShapePaletteImageTops[paletteShape.Row, paletteShape.Column] = imageHeight * paletteShape.Row;
                ViewBag.ShapePaletteImageWidth = imageWidth;
                ViewBag.ShapePaletteImageHeight = imageHeight;
                ViewBag.ShapePaletteWidth = imageWidth * shapePalette.Columns;
                ViewBag.ShapePaletteHeight = imageHeight * shapePalette.Rows;
            }

            ColorPalette colorPalette = shapeMap.DefaultColorPalette;
            ViewBag.ColorPalette = colorPalette;

            ViewBag.ColorPaletteImageFilenames = new string[colorPalette.Rows, colorPalette.Columns];
            ViewBag.ColorPaletteImageLefts = new int[colorPalette.Rows, colorPalette.Columns];
            ViewBag.ColorPaletteImageTops = new int[colorPalette.Rows, colorPalette.Columns];
            foreach (GraphMapper.Models.Color color in colorPalette.Colors)
            {
                string imageFilename = Resources.ColorImageShortName;
                string imagePath = Resources.ColorFilePath;
                string imageTypeExtension = Resources.ColorImageTypeExtension;
                string imageSeparator = Resources.DefaultFileExtensionSeparator;
                string imageControllerName = "GraphMapperImages";
                string imageActionName = "GetImageFromColor";

                int imageWidth = CommonControllerUtils.GetImageWidth(
                    Server.MapPath(Url.Content(imagePath + imageFilename + imageSeparator + imageTypeExtension)));

                int imageHeight = CommonControllerUtils.GetImageHeight(
                    Server.MapPath(Url.Content(imagePath + imageFilename + imageSeparator + imageTypeExtension)));

                ViewBag.ColorPaletteImageFilenames[color.Row, color.Column] = "/" + imageControllerName + "/" + imageActionName + "/" + color.ID;
                ViewBag.ColorPaletteImageLefts[color.Row, color.Column] = imageWidth * color.Column;
                ViewBag.ColorPaletteImageTops[color.Row, color.Column] = imageHeight * color.Row;
                ViewBag.ColorPaletteImageWidth = imageWidth;
                ViewBag.ColorPaletteImageHeight = imageHeight;
                ViewBag.ColorPaletteWidth = imageWidth * colorPalette.Columns;
                ViewBag.ColorPaletteHeight = imageHeight * colorPalette.Rows;
            }

            int foregroundColorID;
            int backgroundColorID;
            int shapeID;
            int previewID;

            try
            {
                foregroundColorID = int.Parse(Profile.GetPropertyValue("ForegroundColorID").ToString());
                backgroundColorID = int.Parse(Profile.GetPropertyValue("BackgroundColorID").ToString());
                shapeID = int.Parse(Profile.GetPropertyValue("ShapeID").ToString());
                previewID = int.Parse(Profile.GetPropertyValue("PreviewID").ToString());

            }
            catch (System.Configuration.SettingsPropertyNotFoundException)
            {
                foregroundColorID = -1;
                backgroundColorID = -1;
                shapeID = -1;
                previewID = -1;
                Profile.SetPropertyValue("ForegroundColorID", foregroundColorID);
                Profile.SetPropertyValue("ColorID", backgroundColorID);
                Profile.SetPropertyValue("ShapeID", shapeID);
                Profile.SetPropertyValue("PreviewID", previewID);
            }

            string currentUrl = HttpContext.Request.Path;
            Profile.SetPropertyValue("CurrentUrl", currentUrl);

            ViewBag.ForegroundColorID = foregroundColorID;
            ViewBag.BackgroundColorID = backgroundColorID;
            ViewBag.ShapeID = shapeID;
            ViewBag.PreviewID = previewID;

            if (previewID >= 0 && db.MapElements.Find(previewID) != null)
            {
                MapElement previewElement = db.MapElements.Find(previewID);

                string previewImageFilename = previewElement.Shape.FileName;
                string previewImagePath = Resources.ImageFilePath;
                string previewImageTypeExtension = previewElement.Shape.TypeExtension;
                string previewImageSeparator = previewElement.Shape.FileNameExtensionSeparator;
                string previewImageControllerName = "GraphMapperImages";
                string previewImageActionName = "GetImageFromMapElement";

                int previewImageWidth = 2 * CommonControllerUtils.GetImageWidth(
                    Server.MapPath(Url.Content(previewImagePath + previewImageFilename)));

                int previewImageHeight = 2 * CommonControllerUtils.GetImageHeight(
                    Server.MapPath(Url.Content(previewImagePath + previewImageFilename)));

                ViewBag.PreviewImageFilename = "/" + previewImageControllerName + "/" + previewImageActionName + "/" + previewElement.ID.ToString();
                ViewBag.PreviewImageWidth = previewImageWidth;
                ViewBag.ImageHeight = previewImageHeight;
                ViewBag.PreviewImageExists = true;
            }
            else
            {
                ViewBag.PreviewImageExists = false;
                ViewBag.PreviewImageHeight = 2 * graphMapImageHeight;
                ViewBag.PreviewImageWidth = 2 * graphMapImageWidth;
            }

            CommonControllerUtils.ShapeMapToBitmap(shapeMap, shape, Server.MapPath(Url.Content(Resources.ImageFilePath)));

            return View(shape);
        }

        // POST: Shapes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ShortName,TypeExtension,FileNameExtensionSeparator,Row,Column")] Shape shape)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shape).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shape);
        }

        // GET: Shapes/Delete/5
        public ActionResult Delete(int? id)
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
            return View(shape);
        }

        // POST: Shapes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shape shape = db.Shapes.Find(id);
            db.Shapes.Remove(shape);
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
