using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GraphMapper.Models
{
    public class ShapePalette
    {
        public int ID { get; set; }
        [StringLength(32)]
        public string Name { get; set; }
        public int Order { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public virtual GraphMapperUser Owner { get; set; }
        public virtual GraphMapperUser Creator { get; set; }
        public virtual ICollection<Shape> Shapes { get; set; }
    }
}