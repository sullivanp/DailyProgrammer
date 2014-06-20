using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Drawing.Bitmap;
//using System.Drawing.Color;
using System.Drawing;
using System.ComponentModel.DataAnnotations;

namespace GraphMapper.Models
{
    public class Tile
    {
        [Key]
        public int ID { get; set; }
        public string Shape { get; set; }
        public Color Color { get; set; }
        public Bitmap Icon { get; set; }

        // overloaded constructor
        public Tile(string Shape, Color Color)
        {
            this.Shape = Shape;
            this.Color = Color;
            Icon = CreateBitmap(Shape, Color);
        }

        // default constructor
        public Tile()
        {
            this.Shape = "Blank.bmp";
            this.Color = Color.Empty;
            CreateBitmap("Blank.bmp", Color.Empty);
        }


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

     


    }


    
    
}