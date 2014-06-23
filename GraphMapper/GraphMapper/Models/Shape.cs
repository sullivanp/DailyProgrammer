using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphMapper.Models
{
    public abstract class Shape
    {
        public int ID { get; set; }
        public int OwnerID { get; set; }
        public bool OwnerIsMapElement { get; set; }
        public string ShortName { get; set; }
        public string TypeExtension { get; set; }
        public string FileNameExtensionSeparator { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public Shape()
        {
            this.FileNameExtensionSeparator = ".";
        }

        public string GetFileName()
        {
            return ShortName + FileNameExtensionSeparator + TypeExtension;
        }
    }
}