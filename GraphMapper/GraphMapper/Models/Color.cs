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
        [StringLength(32)]
        public string Name { get; set; }
        [Range(0, 255)]
        public int Red { get; set; }
        [Range(0, 255)]
        public int Green { get; set; }
        [Range(0, 255)]
        public int Blue { get; set; }
    }
}