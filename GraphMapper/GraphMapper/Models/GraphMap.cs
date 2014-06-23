using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphMapper.Models
{
    public class GraphMap
    {
        public int ID { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public string Name { get; set; }
        public virtual GraphMapperUser Owner { get; set; }
        public virtual GraphMapperUser Creator { get; set; }
        public virtual ShapePalette DefaultShapePalette { get; set; }
        public virtual ColorPalette DefaultColorPalette { get; set; }
        public virtual ICollection<MapElement> MapElements { get; set; }
    }
}