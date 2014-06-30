using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraphMapper.Models;
using System.Drawing;
using System.IO;

namespace GraphMapper.Controllers
{
    public static class CommonControllerUtils
    {
        public static void RecolorImage(string oldFilename, string newFilename,
            System.Drawing.Color oldForegroundColor, System.Drawing.Color newForegroundColor,
            System.Drawing.Color oldBackgroundColor, System.Drawing.Color newBackgroundColor)
        {
            Bitmap image = new Bitmap(oldFilename);

            MemoryStream ms = CommonControllerUtils.RecolorImage(
                oldFilename,
                oldForegroundColor,
                newForegroundColor,
                oldBackgroundColor,
                newBackgroundColor,
                null);

            using (FileStream file = new FileStream(oldFilename, FileMode.Create, System.IO.FileAccess.Write))
            {
                byte[] bytes = new byte[ms.Length];
                ms.Read(bytes, 0, (int)ms.Length);
                file.Write(bytes, 0, bytes.Length);
                ms.Close();
            }
        }

        public static MemoryStream RecolorImage(string oldFilename,
            System.Drawing.Color oldForegroundColor, System.Drawing.Color newForegroundColor,
            System.Drawing.Color oldBackgroundColor, System.Drawing.Color newBackgroundColor,
            System.Drawing.Imaging.ImageFormat format = null)
        {
            System.Drawing.Imaging.ImageFormat theFormat = null;
            Bitmap image = new Bitmap(oldFilename);
            if(format == null)
            {
                if (!string.IsNullOrEmpty(Path.GetExtension(oldFilename)))
                {
                    theFormat = ExtensionToImageFormat(Path.GetExtension(oldFilename));
                } else
                {
                    theFormat = ExtensionToImageFormat(Resources.DefaultImageTypeExtension);
                }
            }

            for (int x = 0; x != image.Width; x++)
            {
                for (int y = 0; y != image.Height; y++)
                {
                    System.Drawing.Color oldPixelColor = image.GetPixel(x, y);
                    System.Drawing.Color newPixelColor;
                    if (oldBackgroundColor != null && oldBackgroundColor != System.Drawing.Color.Empty && oldPixelColor.ToArgb() == oldBackgroundColor.ToArgb())
                    {
                        newPixelColor = newBackgroundColor;
                    }
                    else if(oldForegroundColor != null && !oldForegroundColor.IsEmpty && oldForegroundColor != System.Drawing.Color.Empty && oldPixelColor.ToArgb() == oldForegroundColor.ToArgb())
                    {
                        newPixelColor = newForegroundColor;
                    }
                    else
                    {
                        //newPixelColor = oldPixelColor;
                        continue;
                    }
                    image.SetPixel(x, y, newPixelColor);
                }
            }

            MemoryStream ms = new MemoryStream();

            image.Save(ms, theFormat);

            return ms;
        }

        public static int GetImageWidth(string imageFilename)
        {
            Bitmap image = new Bitmap(imageFilename);
            return image.Width;
        }

        public static int GetImageHeight(string imageFilename)
        {
            Bitmap image = new Bitmap(imageFilename);
            return image.Height;
        }

        public static System.Drawing.Imaging.ImageFormat ExtensionToImageFormat(string extension)
        {
            System.Drawing.Imaging.ImageFormat format = null;

            if(extension.ToLower().EndsWith("bmp"))
            {
                format = System.Drawing.Imaging.ImageFormat.Bmp;
            }
            else if (extension.ToLower().EndsWith("emf"))
            {
                format = System.Drawing.Imaging.ImageFormat.Emf;
            }
            else if (extension.ToLower().EndsWith("gif"))
            {
                format = System.Drawing.Imaging.ImageFormat.Gif;
            }
            else if (extension.ToLower().EndsWith("ico"))
            {
                format = System.Drawing.Imaging.ImageFormat.Icon;
            }
            else if (extension.ToLower().EndsWith("jpg") || extension.ToLower().EndsWith("jpeg"))
            {
                format = System.Drawing.Imaging.ImageFormat.Jpeg;
            }
            else if (extension.ToLower().EndsWith("png"))
            {
                format = System.Drawing.Imaging.ImageFormat.Png;
            }
            else if (extension.ToLower().EndsWith("tif") || extension.ToLower().EndsWith("tiff"))
            {
                format = System.Drawing.Imaging.ImageFormat.Tiff;
            }
            else if (extension.ToLower().EndsWith("wmf"))
            {
                format = System.Drawing.Imaging.ImageFormat.Wmf;
            } else
            {
                format = null;
            }

            return format;
        }

        public static void CreateNewShapeFile(string filename, int? width = null, int? height = null, System.Drawing.Color? colorFill = null,
            System.Drawing.Imaging.ImageFormat format = null)
        {
            Bitmap bitmap;
            if (width != null && height != null && width > 0 && height > 0)
            {
                bitmap = new Bitmap(width.Value, height.Value);
            } else
            {
                bitmap = new Bitmap(int.Parse(Resources.DefaultShapeWidth), int.Parse(Resources.DefaultShapeHeight));
            }

            System.Drawing.Color fill;
            if(colorFill == null)
            {
                fill = System.Drawing.Color.White;
            } else
            {
                fill = colorFill.Value;
            }

            System.Drawing.Imaging.ImageFormat fileFormat;
            if(format == null)
            {
                fileFormat = ExtensionToImageFormat(Resources.DefaultImageTypeExtension);
            } else
            {
                fileFormat = format;
            }

            for(int x = 0; x != bitmap.Width; x++)
            {
                for(int y = 0; y != bitmap.Height; y++)
                {
                    bitmap.SetPixel(x, y, fill);
                }
            }

            bitmap.Save(filename, fileFormat);
        }

        public static void ShapeMapToBitmap(GraphMap shapeMap, Shape shape, string path = null,
            System.Drawing.Imaging.ImageFormat format = null)
        {
            System.Drawing.Imaging.ImageFormat fileFormat;
            if (format == null)
            {
                fileFormat = ExtensionToImageFormat(shape.FileName);
            }
            else
            {
                fileFormat = format;
            }
            string filename;
            if (path == null)
            {
                filename = Resources.ImageFilePath + shape.FileName;
            }
            else
            {
                filename = path + shape.FileName;
            }
            if(File.Exists(filename))
            {
                File.Delete(filename);
            }
            MapElement shapePixel;
            System.Drawing.Color pixelColor = System.Drawing.Color.Empty;
            Bitmap bitmap = new Bitmap(shapeMap.Columns, shapeMap.Rows);
            for (int x = 0; x != shapeMap.Columns; x++)
            {
                for(int y = 0; y != shapeMap.Rows; y++)
                {
                    shapePixel = shapeMap.MapElements.First(s => s.Row == y && s.Column == x);
                    if(shapePixel.ForegroundColor.Name == "Black")
                    {
                        pixelColor = System.Drawing.Color.Black;
                    } else if(shapePixel.ForegroundColor.Name == "White")
                    {
                        pixelColor = System.Drawing.Color.White;
                    } else
                    {
                        pixelColor = System.Drawing.Color.FromArgb(shapePixel.ForegroundColor.Red, shapePixel.ForegroundColor.Green, shapePixel.ForegroundColor.Blue);
                    }
                    bitmap.SetPixel(x, y, pixelColor);
                }
            }

            bitmap.Save(filename, fileFormat);
        }
    }
}