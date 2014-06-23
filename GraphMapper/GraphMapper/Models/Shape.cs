using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace GraphMapper.Models
{
    public class Shape
    {
        [Key]
        public int ShapeID { get; set; }
        public String Name { get; set; }
        public String Extension { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Color Foreground { get; set; }
        public Color Background { get; set; }

        public Shape(string name, string extension, int width, int height, Color foreground, Color background) : this(name, extension, foreground, background)
        {
            this.Width = width;
            this.Height = height;
        }

        public Shape(string name, string extension = "png")
        {
            this.Name = name;
            this.Extension = extension;
            Foreground = Color.Black;
            Background = Color.White;
        }

        public Shape(string name, string extension, Color foreground, Color background) : this(name, extension)
        {
            this.Foreground = foreground;
            this.Background = background;
        }

        public Shape(string name) : this(name, "png") { }

        public Shape()
        {
            this.Extension = "png";
            this.Foreground = Color.Black;
            this.Background = Color.White;
        }

        public Shape(Shape copy) : this(copy.Name, copy.Extension, copy.Width, copy.Height, copy.Foreground, copy.Background) { }

        public String GetFilename()
        {
            return this.Name + "." + this.Extension;
        }
    }
}