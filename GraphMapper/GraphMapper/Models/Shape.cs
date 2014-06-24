using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GraphMapper.Models
{
    public class Shape
    {
        public int ID { get; set; }
        public int OwnerID { get; set; }
        public bool OwnerIsMapElement { get; set; }
        [StringLength(32), Required]
        public string ShortName { get; set; }
        [StringLength(3)]
        public string TypeExtension { get; set; }
        [StringLength(1)]
        public string FileNameExtensionSeparator { get; set; }
        [Range(0, 1000)]
        public int Row { get; set; }
        [Range(0, 1000)]
        public int Column { get; set; }

        public string FileName
        {
            get
            {
                return ShortName + FileNameExtensionSeparator + TypeExtension;
            }
        }

        public Shape()
        {
            this.FileNameExtensionSeparator = ".";
        }
    }
}