using GraphMapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GraphMapper.Controllers
{
    public class ProfileController : Controller
    {
        private GraphMapperContext db = new GraphMapperContext();

        public ActionResult SetShapeID(int? id)
        {
            if(id == null || id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            if(db.Shapes.Find(id) == null)
            {
                return HttpNotFound();
            }

            Profile.SetPropertyValue("ShapeID",  id);
            MakePreview();

            if (HttpContext.Request.UrlReferrer == null)
            {
                try
                {
                    return Redirect(Profile.GetPropertyValue("CurrentUrl").ToString());
                } catch(System.Configuration.SettingsPropertyNotFoundException)
                {
                    return Redirect("/");
                }
            }
            else
            {
                return Redirect(HttpContext.Request.UrlReferrer.AbsolutePath);
            }
        }

        public ActionResult SetColorID(int? id)
        {
            if (id == null || id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (db.Colors.Find(id) == null)
            {
                return HttpNotFound();
            }

            if (GetSelectingForegroundColor())
            {
                Profile.SetPropertyValue("ForegroundColorID", id);
            } else
            {
                Profile.SetPropertyValue("BackgroundColorID", id);
            }
            MakePreview();

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

        public ActionResult SetForegroundColorID(int? id)
        {
            if (id == null || id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (db.Colors.Find(id) == null)
            {
                return HttpNotFound();
            }

            Profile.SetPropertyValue("ForegroundColorID", id);
            MakePreview();

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

        public ActionResult SetBackgroundColorID(int? id)
        {
            if (id == null || id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (db.Colors.Find(id) == null)
            {
                return HttpNotFound();
            }

            Profile.SetPropertyValue("BackgroundColorID", id);
            MakePreview();

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

        public ActionResult SetPreviewID(int? id)
        {
            if (id == null || id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (db.MapElements.Find(id) == null)
            {
                return HttpNotFound();
            }

            Profile.SetPropertyValue("PreviewID", id);

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

        public ActionResult SetSelectingForegroundColor(bool? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Profile.SetPropertyValue("SelectingForegroundColor", id);

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

        public ActionResult SetAddingShape(bool? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Profile.SetPropertyValue("AddingShape", id);
            Profile.SetPropertyValue("DeletingShape", !id);

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

        public ActionResult SetAddingColor(bool? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Profile.SetPropertyValue("AddingColor", id);
            Profile.SetPropertyValue("DeletingColor", !id);

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

        public ActionResult SetDeletingShape(bool? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Profile.SetPropertyValue("AddingShape", !id);
            Profile.SetPropertyValue("DeletingShape", id);

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

        public ActionResult SetDeletingColor(bool? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Profile.SetPropertyValue("AddingColor", !id);
            Profile.SetPropertyValue("DeletingColor", id);

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

        public ActionResult ResetShapeID()
        {
            Profile.SetPropertyValue("ShapeID", -1);
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

        public ActionResult ResetColorID()
        {
            Profile.SetPropertyValue("ColorID", -1);
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

        public ActionResult ResetForegroundColorID()
        {
            Profile.SetPropertyValue("ForegroundColorID", -1);
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

        public ActionResult ResetBackgroundColorID()
        {
            Profile.SetPropertyValue("BackgroundColorID", -1);
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

        public ActionResult ResetPreviewID()
        {
            Profile.SetPropertyValue("PreviewID", -1);
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
        
        public ActionResult ResetSelectingForegroundColor()
        {
            Profile.SetPropertyValue("SelectingForegroundColor", true);
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

        public ActionResult ResetAddingColor()
        {
            Profile.SetPropertyValue("AddingColor", false);
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

        public ActionResult ResetDeletingColor()
        {
            Profile.SetPropertyValue("DeletingColor", false);
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

        public ActionResult ResetAddingShape()
        {
            Profile.SetPropertyValue("AddingShape", false);
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

        public ActionResult ResetDeletingShape()
        {
            Profile.SetPropertyValue("DeletingShape", false);
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

        public ActionResult ResetProfile()
        {
            ResetShapeID();
            ResetColorID();
            ResetBackgroundColorID();
            ResetForegroundColorID();
            ResetPreviewID();
            ResetSelectingForegroundColor();
            ResetAddingColor();
            ResetAddingShape();
            ResetDeletingColor();
            ResetDeletingShape();
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

        public string GetColorID()
        {
            try
            {
                return Profile.GetPropertyValue("ColorID").ToString();
            } catch(System.Configuration.SettingsPropertyNotFoundException)
            {
                Profile.SetPropertyValue("ColorID", -2);
                return "-2";
            }
        }

        public string GetForegroundColorID()
        {
            try
            {
                return Profile.GetPropertyValue("ForegroundColorID").ToString();
            }
            catch (System.Configuration.SettingsPropertyNotFoundException)
            {
                Profile.SetPropertyValue("ForegroundColorID", -30);
                return "-30";
            }
        }

        public string GetBackgroundColorID()
        {
            try
            {
                return Profile.GetPropertyValue("BackgroundColorID").ToString();
            }
            catch (System.Configuration.SettingsPropertyNotFoundException)
            {
                Profile.SetPropertyValue("BackgroundColorID", -40);
                return "-40";
            }
        }

        public string GetShapeID()
        {
            try
            {
                return Profile.GetPropertyValue("ShapeID").ToString();
            }
            catch (System.Configuration.SettingsPropertyNotFoundException)
            {
                Profile.SetPropertyValue("ShapeID", -3);
                return "-3";
            }
        }

        public string GetPreviewID()
        {
            try
            {
                return Profile.GetPropertyValue("PreviewID").ToString();
            }
            catch (System.Configuration.SettingsPropertyNotFoundException)
            {
                Profile.SetPropertyValue("PreviewID", -4);
                return "-4";
            }
        }

        public bool GetSelectingForegroundColor()
        {
            try
            {
                return (Profile.GetPropertyValue("SelectingForegroundColor").ToString().ToLower().StartsWith("t"));
            }
            catch (System.Configuration.SettingsPropertyNotFoundException)
            {
                Profile.SetPropertyValue("SelectingForegroundColor", true);
                return true;
            }
        }

        public bool GetAddingColor()
        {
            try
            {
                return (Profile.GetPropertyValue("AddingColor").ToString().ToLower().StartsWith("t"));
            }
            catch (System.Configuration.SettingsPropertyNotFoundException)
            {
                Profile.SetPropertyValue("AddingColor", false);
                return false;
            }
        }

        public bool GetDeletingColor()
        {
            try
            {
                return (Profile.GetPropertyValue("DeletingColor").ToString().ToLower().StartsWith("t"));
            }
            catch (System.Configuration.SettingsPropertyNotFoundException)
            {
                Profile.SetPropertyValue("DeletingColor", false);
                return false;
            }
        }

        public bool GetAddingShape()
        {
            try
            {
                return (Profile.GetPropertyValue("AddingShape").ToString().ToLower().StartsWith("t"));
            }
            catch (System.Configuration.SettingsPropertyNotFoundException)
            {
                Profile.SetPropertyValue("AddingShape", false);
                return false;
            }
        }

        public bool GetDeletingShape()
        {
            try
            {
                return (Profile.GetPropertyValue("DeletingShape").ToString().ToLower().StartsWith("t"));
            }
            catch (System.Configuration.SettingsPropertyNotFoundException)
            {
                Profile.SetPropertyValue("DeletingShape", false);
                return false;
            }
        }

        public string MakePreview()
        {
            int shapeID = int.Parse(GetShapeID());
            int colorID = int.Parse(GetColorID());
            int foregroundColorId = int.Parse(GetForegroundColorID());
            int backgroundColorId = int.Parse(GetBackgroundColorID());
            if(shapeID > 0 && foregroundColorId > 0 && backgroundColorId > 0)
            {
                if(db.Shapes.Find(shapeID) != null && db.Colors.Find(foregroundColorId) != null && db.Colors.Find(backgroundColorId) != null)
                {
                    if (int.Parse(GetPreviewID()) < 0)
                    {
                        MapElement preview;
                        preview = new MapElement()
                            {
                                Shape = db.Shapes.Find(shapeID),
                                ForegroundColor = db.Colors.Find(foregroundColorId),
                                BackgroundColor = db.Colors.Find(backgroundColorId)
                            };
                        db.MapElements.Add(preview);
                        db.SaveChanges();
                        Profile.SetPropertyValue("PreviewID", preview.ID);
                        return preview.ID.ToString();
                    }
                    else
                    {
                        MapElement preview = db.MapElements.Find(int.Parse(GetPreviewID()));
                        preview.ForegroundColor = db.Colors.Find(foregroundColorId);
                        preview.BackgroundColor = db.Colors.Find(backgroundColorId);
                        preview.Shape = db.Shapes.Find(shapeID);
                        db.MapElements.Add(preview);
                        db.SaveChanges();
                        Profile.SetPropertyValue("PreviewID", preview.ID);
                        return preview.ID.ToString();
                    }
                } else
                {
                    return "-6";
                }
            }
            return "-5";
        }
    }
}
