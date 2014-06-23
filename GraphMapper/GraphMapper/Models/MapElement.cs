using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphMapper.Models
{
    public class MapElement
    {
        public int ID { get; set; }
        public int GraphMapID { get; set; }
        public int BackgroundRed { get; set; }
        public int BackgroundGreen { get; set; }
        public int BackgroundBlue { get; set; }
        public int ForegroundRed { get; set; }
        public int ForegroundGreen { get; set; }
        public int ForegroundBlue { get; set; }
        public Shape Shape { get; set; }
    }
}