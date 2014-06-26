using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GraphMapper.Models
{
    public class Color
    {
        public int ID { get; set; }
        public int Order { get; set; }
        [Range(0, 1000)]
        public int Row { get; set; }
        [Range(0, 1000)]
        public int Column { get; set; }
        [StringLength(64)]
        public string Name { get; set; }
        [Range(0, 255)]
        public int Red { get; set; }
        [Range(0, 255)]
        public int Green { get; set; }
        [Range(0, 255)]
        public int Blue { get; set; }

        private static int LastOrderUsed { get; set; }
        private static int UntitledNumber { get; set; }

        static Color()
        {
            LastOrderUsed = 50000;
            UntitledNumber = 1;
        }

        public Color()
        {
            Order = ++LastOrderUsed;
            Name = "Untitled Color #" + ++UntitledNumber;
            Row = Column = 0;
            Red = Green = Blue = 0;
            Name = "Black";
        }

        public System.Drawing.Color ToSystemColor()
        {
            return System.Drawing.Color.FromArgb(Red, Green, Blue);
        }

        public void FromSystemColor(System.Drawing.Color systemColor)
        {
            Red = systemColor.R;
            Green = systemColor.G;
            Blue = systemColor.B;
            if (systemColor.IsNamedColor)
            {
                Name = systemColor.Name;
            } else
            {
                Name = "Untitled Color #" + ++UntitledNumber;
            }
        }
    }
}