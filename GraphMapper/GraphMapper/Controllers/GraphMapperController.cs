using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Drawing;
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
            ViewBag.ImageFilenames = new string[graphMap.Rows, graphMap.Columns];
            ViewBag.ImageLefts = new int[graphMap.Rows, graphMap.Columns];
            ViewBag.ImageTops = new int[graphMap.Rows, graphMap.Columns];
            for (int row = 0; row != graphMap.Rows; row++ )
            {
                for(int column = 0; column != graphMap.Columns; column++)
                {
                    MapElement mapElement = graphMap.MapElements.Single(e => e.Row == row && e.Column == column);
                    string imageFilename = mapElement.Shape.FileName;
                    string imagePath = Resources.ImageFilePath;
                    string imageTypeExtension = mapElement.Shape.TypeExtension;
                    string imageSeparator = mapElement.Shape.FileNameExtensionSeparator;
                    string imageControllerName = "GraphMapperImages";
                    string imageActionName = "GetImageFromMapElement";

                    int imageWidth = CommonControllerUtils.GetImageWidth(
                        Server.MapPath(Url.Content(imagePath + imageFilename)));

                    int imageHeight = CommonControllerUtils.GetImageHeight(
                        Server.MapPath(Url.Content(imagePath + imageFilename)));

                    ViewBag.ImageFilenames[row, column] = "/" + imageControllerName + "/" + imageActionName + "/" + mapElement.ID;
                    ViewBag.ImageLefts[row, column] = imageWidth * column;
                    ViewBag.ImageTops[row, column] = imageHeight * row;
                    ViewBag.ImageWidth = imageWidth;
                    ViewBag.ImageHeight = imageHeight;
                    ViewBag.GraphMapWidth = imageWidth * graphMap.Columns;
                    ViewBag.GraphMapHeight = imageHeight * graphMap.Rows;
                }
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
                graphMap.Updated = graphMap.Created = DateTime.Now;
                graphMap.MapElements = new List<MapElement>(graphMap.Rows * graphMap.Columns);
                graphMap.DefaultColorPalette = new ColorPalette
                    {
                        Rows = 2, Columns = 2, Name = "Default Color Palette for New GraphMap", Order = 20,
                        Updated = new DateTime(2014, 6, 26, 8, 32, 15),
                        Colors = new List<GraphMapper.Models.Color>
                        {
                            new GraphMapper.Models.Color { Row = 0, Column = 0, Red = 0, Green = 0, Blue = 0, Name = "Black", Order = 40 },
                            new GraphMapper.Models.Color { Row = 0, Column = 1, Red = 255, Green = 255, Blue = 255, Name = "White", Order = 60 }
                        }
                    };
                graphMap.DefaultShapePalette = new ShapePalette
                    {
                        Rows = 2,
                        Columns = 2,
                        Name = "Default Shape Palette for New GraphMap",
                        Order = 80,
                        Updated = new DateTime(2014, 6, 26, 8, 32, 20),
                        Shapes = new List<Shape>
                        {
                            new Shape { Row = 0, Column = 0, ShortName = "HollowBox" },
                            new Shape { Row = 0, Column = 1, ShortName = "CenteredVerticalLine" },
                            new Shape { Row = 1, Column = 0, ShortName = "CenteredHorizontalLine" },
                            new Shape { Row = 1, Column = 1, ShortName = "SolidFilledBox" }
                        }
                    };

                for (int row = 0; row != graphMap.Rows; row++ )
                {
                    for(int column = 0; column != graphMap.Columns; column++)
                    {
                        graphMap.MapElements.Add(
                            new MapElement()
                            {
                                Row = row, Column = column, GraphMap = graphMap, GraphMapID = graphMap.ID,
                                Shape = new Shape()
                                {
                                    FileNameExtensionSeparator = Resources.DefaultFileExtensionSeparator,
                                    ShortName = Resources.DefaultImageShortName,
                                    TypeExtension = Resources.DefaultImageTypeExtension
                                },
                                ForegroundColor = new GraphMapper.Models.Color()
                                {
                                    Red = 255, Green = 255, Blue = 255, Name = "White"
                                },
                                BackgroundColor = new GraphMapper.Models.Color()
                                {
                                    Red = 0, Green = 0, Blue = 0, Name = "Black"
                                }
                            }
                        );
                    }
                }
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
            ViewBag.ImageFilenames = new string[graphMap.Rows, graphMap.Columns];
            ViewBag.ImageLefts = new int[graphMap.Rows, graphMap.Columns];
            ViewBag.ImageTops = new int[graphMap.Rows, graphMap.Columns];
            int graphMapImageWidth = 40;
            int graphMapImageHeight = 40;
            foreach(MapElement mapElement in graphMap.MapElements)
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
                ViewBag.GraphMapWidth = graphMapImageWidth * graphMap.Columns;
                ViewBag.GraphMapHeight = graphMapImageHeight * graphMap.Rows;
            }

            ShapePalette shapePalette = graphMap.DefaultShapePalette;
            ViewBag.ShapePalette = shapePalette;

            ViewBag.ShapePaletteImageFilenames = new string[shapePalette.Rows, shapePalette.Columns];
            ViewBag.ShapePaletteImageLefts = new int[shapePalette.Rows, shapePalette.Columns];
            ViewBag.ShapePaletteImageTops = new int[shapePalette.Rows, shapePalette.Columns];
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

                ViewBag.ShapePaletteImageFilenames[shape.Row, shape.Column] = "/" + imageControllerName + "/" + imageActionName + "/" + shape.ID;
                ViewBag.ShapePaletteImageLefts[shape.Row, shape.Column] = imageWidth * shape.Column;
                ViewBag.ShapePaletteImageTops[shape.Row, shape.Column] = imageHeight * shape.Row;
                ViewBag.ShapePaletteImageWidth = imageWidth;
                ViewBag.ShapePaletteImageHeight = imageHeight;
                ViewBag.ShapePaletteWidth = imageWidth * shapePalette.Columns;
                ViewBag.ShapePaletteHeight = imageHeight * shapePalette.Rows;
            }

            ColorPalette colorPalette = graphMap.DefaultColorPalette;
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
            } else
            {
                ViewBag.PreviewImageExists = false;
                ViewBag.PreviewImageHeight = 2 * graphMapImageHeight;
                ViewBag.PreviewImageWidth = 2 * graphMapImageWidth;
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
            if (graphMap.ID < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (graphMap == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                graphMap.Updated = DateTime.Now;
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

        public ActionResult SetMapElement(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if(id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapElement mapElement = db.MapElements.Find(id);
            if (mapElement == null)
            {
                return HttpNotFound();
            }

            try
            {
                int newForegroundColor = int.Parse(Profile.GetPropertyValue("ForegroundColorID").ToString());
                int newBackgroundColor = int.Parse(Profile.GetPropertyValue("BackgroundColorID").ToString());
                int newShape = int.Parse(Profile.GetPropertyValue("ShapeID").ToString());
                if (db.Shapes.Find(newShape) == null)
                {
                    return HttpNotFound();
                }
                mapElement.Shape = db.Shapes.Find(newShape);
                if (db.Colors.Find(newForegroundColor) == null)
                {
                    return HttpNotFound();
                }
                mapElement.ForegroundColor = db.Colors.Find(newForegroundColor);
                if (db.Colors.Find(newBackgroundColor) == null)
                {
                    return HttpNotFound();
                }
                mapElement.BackgroundColor = db.Colors.Find(newBackgroundColor);
                if (ModelState.IsValid)
                {
                    db.Entry(mapElement).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (System.Configuration.SettingsPropertyNotFoundException)
            {
                if (HttpContext.Request.UrlReferrer == null)
                {
                    try
                    {
                        return Redirect(Profile.GetPropertyValue("CurrentUrl").ToString());
                    }
                    catch (System.Configuration.SettingsPropertyNotFoundException)
                    {
                        return Redirect("/");
                    }
                }
                else
                {
                    return Redirect(HttpContext.Request.UrlReferrer.AbsolutePath);
                }
            }

            if (HttpContext.Request.UrlReferrer == null)
            {
                try
                {
                    return Redirect(Profile.GetPropertyValue("CurrentUrl").ToString());
                }
                catch (System.Configuration.SettingsPropertyNotFoundException)
                {
                    return Redirect("/");
                }
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
