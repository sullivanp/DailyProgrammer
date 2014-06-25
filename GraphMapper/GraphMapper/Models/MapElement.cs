using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GraphMapper.Models
{
    public class MapElement
    {
        public int ID { get; set; }
        public int? GraphMapID { get; set; }
        public virtual GraphMap GraphMap { get; set; }
        [Range(0, 1000)]
        public int Row { get; set; }
        [Range(0, 1000)]
        public int Column { get; set; }
        public virtual Color BackgroundColor { get; set; }
        public virtual Color ForegroundColor { get; set; }
        public virtual Shape Shape { get; set; }
    }
}