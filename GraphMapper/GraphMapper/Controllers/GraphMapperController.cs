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
            int imageWidth;
            int imageHeight;
            ViewBag.ImageFilenames = new string[graphMap.Rows, graphMap.Columns];
            ViewBag.ImageLefts = new int[graphMap.Rows, graphMap.Columns];
            ViewBag.ImageTops = new int[graphMap.Rows, graphMap.Columns];
            for (int row = 0; row != graphMap.Rows; row++ )
            {
                for(int column = 0; column != graphMap.Columns; column++)
                {
                    MapElement mapElement = graphMap.MapElements.Single(e => e.Row == row && e.Column == column);
                    string imageFilename = mapElement.Shape.FileName;
                    string imagePath = @"/Content/Shapes/";
                    string tempImagePath = @"/Content/TempShapes/";
                    string imageTypeExtension = mapElement.Shape.TypeExtension;
                    string imageSeparator = mapElement.Shape.FileNameExtensionSeparator;
                    string tempImageFilename = id + "_" + row + "_" + column + imageSeparator + imageTypeExtension;
                    Bitmap image = new Bitmap(Server.MapPath(Url.Content(imagePath + imageFilename)));
                    imageWidth = image.Width;
                    imageHeight = image.Height;
                    for (int x = 0; x < image.Width; x++)
                    {
                        for (int y = 0; y < image.Height; y++)
                        {
                            System.Drawing.Color pixelColor = image.GetPixel(x, y);
                            System.Drawing.Color newColor;
                            GraphMapper.Models.Color foregroundColor = mapElement.ForegroundColor;
                            GraphMapper.Models.Color backgroundColor = mapElement.BackgroundColor;
                            if (pixelColor.ToArgb() == System.Drawing.Color.Black.ToArgb())
                            {
                                newColor = System.Drawing.Color.FromArgb(foregroundColor.Red, foregroundColor.Green, foregroundColor.Blue);
                            }
                            else if (pixelColor.ToArgb() == System.Drawing.Color.White.ToArgb())
                            {
                                newColor = System.Drawing.Color.FromArgb(backgroundColor.Red, backgroundColor.Green, backgroundColor.Blue);
                            } else
                            {
                                newColor = pixelColor;
                            }
                            image.SetPixel(x, y, newColor);
                            image.Save(Server.MapPath(Url.Content(tempImagePath + tempImageFilename)));
                        }
                    } 
                    ViewBag.ImageFilenames[row, column] = tempImagePath + tempImageFilename;
                    ViewBag.ImageLefts[row, column] = imageWidth * column;
                    ViewBag.ImageTops[row, column] = imageHeight * row;
                    ViewBag.ImageWidth = imageWidth;
                    ViewBag.ImageHeight = imageHeight;
                    ViewBag.GraphMapWidth = imageWidth * graphMap.Rows;
                    ViewBag.GraphMapHeight = imageHeight * graphMap.Columns;
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
                graphMap.Updated = DateTime.Now;
                graphMap.MapElements = new List<MapElement>(graphMap.Rows * graphMap.Columns);
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
                                    FileNameExtensionSeparator = ".",
                                    ShortName = "SolidFilledBox",
                                    TypeExtension = "png"
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

            int imageWidth;
            int imageHeight;
            ViewBag.ImageFilenames = new string[graphMap.Rows, graphMap.Columns];
            ViewBag.ImageLefts = new int[graphMap.Rows, graphMap.Columns];
            ViewBag.ImageTops = new int[graphMap.Rows, graphMap.Columns];
            for (int row = 0; row != graphMap.Rows; row++)
            {
                for (int column = 0; column != graphMap.Columns; column++)
                {
                    MapElement mapElement = graphMap.MapElements.Single(e => e.Row == row && e.Column == column);
                    string imageFilename = mapElement.Shape.FileName;
                    string imagePath = @"/Content/Shapes/";
                    string tempImagePath = @"/Content/TempShapes/";
                    string imageTypeExtension = mapElement.Shape.TypeExtension;
                    string imageSeparator = mapElement.Shape.FileNameExtensionSeparator;
                    string tempImageFilename = id + "_" + row + "_" + column + imageSeparator + imageTypeExtension;
                    Bitmap image = new Bitmap(Server.MapPath(Url.Content(imagePath + imageFilename)));
                    imageWidth = image.Width;
                    imageHeight = image.Height;
                    for (int x = 0; x < image.Width; x++)
                    {
                        for (int y = 0; y < image.Height; y++)
                        {
                            System.Drawing.Color pixelColor = image.GetPixel(x, y);
                            System.Drawing.Color newColor;
                            GraphMapper.Models.Color foregroundColor = mapElement.ForegroundColor;
                            GraphMapper.Models.Color backgroundColor = mapElement.BackgroundColor;
                            if (pixelColor.ToArgb() == System.Drawing.Color.Black.ToArgb())
                            {
                                newColor = System.Drawing.Color.FromArgb(foregroundColor.Red, foregroundColor.Green, foregroundColor.Blue);
                            }
                            else if (pixelColor.ToArgb() == System.Drawing.Color.White.ToArgb())
                            {
                                newColor = System.Drawing.Color.FromArgb(backgroundColor.Red, backgroundColor.Green, backgroundColor.Blue);
                            }
                            else
                            {
                                newColor = pixelColor;
                            }
                            image.SetPixel(x, y, newColor);
                            image.Save(Server.MapPath(Url.Content(tempImagePath + tempImageFilename)));
                        }
                    }
                    ViewBag.ImageFilenames[row, column] = tempImagePath + tempImageFilename;
                    ViewBag.ImageLefts[row, column] = imageWidth * column;
                    ViewBag.ImageTops[row, column] = imageHeight * row;
                    ViewBag.ImageWidth = imageWidth;
                    ViewBag.ImageHeight = imageHeight;
                    ViewBag.GraphMapWidth = imageWidth * graphMap.Rows;
                    ViewBag.GraphMapHeight = imageHeight * graphMap.Columns;
                }
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
