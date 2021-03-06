﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GraphMapper.Models
{
    public class GraphMap
    {
        public int ID { get; set; }
        public int Order { get; set; }
        [Range(0, 1000)]
        public int Rows { get; set; }
        [Range(0, 1000)]
        public int Columns { get; set; }
        [StringLength(64)]
        public string Name { get; set; }
        public virtual GraphMapperUser Owner { get; set; }
        public virtual GraphMapperUser Creator { get; set; }
        public virtual ShapePalette DefaultShapePalette { get; set; }
        public virtual ColorPalette DefaultColorPalette { get; set; }
        public virtual ICollection<MapElement> MapElements { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Created { get; set; }

        private static int LastOrderUsed { get; set; }
        private static int UntitledNumber { get; set; }

        static GraphMap()
        {
            LastOrderUsed = 70000;
            UntitledNumber = 1;
        }

        public GraphMap()
        {
            Order = ++LastOrderUsed;
            Rows = Columns = 0;
            MapElements = new Collection<MapElement>();
            Created = Updated = DateTime.Now;
            Name = "Untitled GraphMap #" + ++UntitledNumber;
        }
    }
}