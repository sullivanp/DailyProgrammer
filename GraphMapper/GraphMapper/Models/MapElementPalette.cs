using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GraphMapper.Models
{
    public class MapElementPalette
    {
        public int ID { get; set; }
        [StringLength(64)]
        public string Name { get; set; }
        public int Order { get; set; }
        [Range(0, 1000)]
        public int Rows { get; set; }
        [Range(0, 1000)]
        public int Columns { get; set; }
        public virtual GraphMapperUser Owner { get; set; }
        public virtual GraphMapperUser Creator { get; set; }
        public virtual ICollection<MapElement> MapElements { get; set; }
    }
}