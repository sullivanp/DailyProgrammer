using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Web;

namespace GraphMapper.Models
{
    public class Shape
    {
        public int ID { get; set; }
        [StringLength(64), Required]
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

        private static int UntitledNumber { get; set; }

        static Shape()
        {
            UntitledNumber = 1;
        }

        public Shape()
        {
            this.FileNameExtensionSeparator = Resources.DefaultFileExtensionSeparator;
            this.TypeExtension = Resources.DefaultImageTypeExtension;
            Row = Column = 0;
            ShortName = "Untitled Shape #" + ++UntitledNumber;
        }

        public Shape(string shortName, string typeExtension) : this()
        {
            ShortName = shortName;
            TypeExtension = typeExtension;
        }
    }
}