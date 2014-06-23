using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GraphMapper.Models
{
    public class GraphMapperContext : DbContext
    {
        public DbSet<Color> Colors { get; set; }
        public DbSet<ColorPalette> ColorPalettes { get; set; }
        public DbSet<GraphMap> GraphMaps { get; set; }
        public DbSet<MapElement> MapElements { get; set; }
        public DbSet<MapElementPalette> MapElementPalettes { get; set; }
        public DbSet<Shape> Shapes { get; set; }
        public DbSet<ShapePalette> ShapePalettes { get; set; }
    }
}