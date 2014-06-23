using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphMapper.Models
{
    public class GraphMapperUser : ApplicationUser
    {
        public virtual ColorPalette DefaultColorPalette { get; set; }
        public virtual ColorPalette DefaultShapePalette { get; set; }
        public virtual ICollection<ColorPalette> ColorPalettes { get; set; }
        public virtual ICollection<ShapePalette> ShapePalettes { get; set; }
    }
}