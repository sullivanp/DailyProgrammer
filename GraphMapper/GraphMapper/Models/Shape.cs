using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GraphMapper.Models
{
    public abstract class Shape
    {
        public int ID { get; set; }
        public int OwnerID { get; set; }
        public bool OwnerIsMapElement { get; set; }
        public int Order { get; set; }
        [StringLength(32)]
        public string ShortName { get; set; }
        [StringLength(3)]
        public string TypeExtension { get; set; }
        [StringLength(1)]
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