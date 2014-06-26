using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GraphMapper.Models
{
    public class ColorPalette
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
        public virtual ICollection<Color> Colors { get; set; }

        public DateTime Updated { get; set; }
        public DateTime Created { get; set; }

        private static int LastOrderUsed { get; set; }
        private static int UntitledNumber { get; set; }

        static ColorPalette()
        {
            LastOrderUsed = 60000;
            UntitledNumber = 1;
        }

        public ColorPalette()
        {
            Order = ++LastOrderUsed;
            Rows = Columns = 0;
            Colors = new Collection<Color>();
            Created = Updated = DateTime.Now;
            Name = "Untitled Color Palette #" + ++UntitledNumber;
        }
    }
}