using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.ComponentModel.DataAnnotations;

namespace GraphMapper.Models
{
    public class MapElement
    {
        [Key]
        public int MapElementID { get; set; }
        public virtual Shape Shape { get; set; }
        public Color ForegroundColor { get; set; }
        public Color BackgroundColor { get; set; }

        public virtual int MapID { get; set; }
        public virtual Map Map { get; set; }

        // overloaded constructor
        public MapElement(Shape Shape, Color ForegroundColor, Color BackgroundColor, int MapID)
        {
            this.Shape = Shape;
            this.ForegroundColor = ForegroundColor;
            this.BackgroundColor = BackgroundColor;
            this.MapID = MapID;
        }

        public MapElement(int gridRow, int gridCol, int mapID) : this(new Shape("Circle"), Color.Black, Color.White, mapID) { }

        public MapElement(int gridRow, int gridCol) : this(-1, gridRow, gridCol) { }

        // default constructor
        public MapElement() : this(new Shape("Circle"), Color.Black, Color.White, -1) { }

        // copy constructor
        public MapElement(MapElement copy) : this(null, copy.ForegroundColor, copy.BackgroundColor, copy.MapID)
        {
            this.Shape = new Shape(copy.Shape);
        }

        /*
        // replaces template color with selected color on selected shape
        public Bitmap CreateBitmap(string Shape, Color color)
        {
            Bitmap Bitmap = new Bitmap(Shape);
           
            for (int x = 0; x < Bitmap.Width; x++)
            {
                for(int y = 0; y < Bitmap.Height; y++)
                {
                    Color gotColor = Bitmap.GetPixel(x, y);
                    gotColor = Color.FromArgb(gotColor.R, gotColor.G, gotColor.B);
                    Bitmap.SetPixel(x, y, gotColor);
                }
            }
            return Bitmap;
        }
         */
    }
}