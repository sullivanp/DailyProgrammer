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
        public int Rows { get; set; }
        public int Columns { get; set; }
        public GraphMapperUser Owner { get; set; }
        public GraphMapperUser Creator { get; set; }
    }
}