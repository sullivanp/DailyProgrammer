using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphMapper.Models
{
    public class ColorPalette
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public virtual GraphMapperUser Owner { get; set; }
        public virtual GraphMapperUser Creator { get; set; }
        public virtual ICollection<Color> Colors { get; set; }
    }
}