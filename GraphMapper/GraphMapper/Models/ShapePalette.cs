using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GraphMapper.Models
{
    public class ShapePalette
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
        public virtual ICollection<Shape> Shapes { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Created { get; set; }

        private static int LastOrderUsed { get; set; }
        private static int UntitledNumber { get; set; }

        static ShapePalette()
        {
            LastOrderUsed = 80000;
            UntitledNumber = 1;
        }

        public ShapePalette()
        {
            Order = ++LastOrderUsed;
            Rows = Columns = 0;
            Shapes = new Collection<Shape>();
            Created = Updated = DateTime.Now;
            Name = "Untitled Shape Palette #" + ++UntitledNumber;
        }
    }
}