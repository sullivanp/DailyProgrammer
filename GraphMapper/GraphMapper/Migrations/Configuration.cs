namespace GraphMapper.Migrations
{
    using GraphMapper.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GraphMapper.Models.GraphMapperContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GraphMapperContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var colors = new List<Color>
            {
                new Color { Order = 0, Red = 255, Green = 0, Blue = 0, Name = "Red" },
                new Color { Order = 1, Red = 0, Green = 255, Blue = 0, Name = "Green" },
                new Color { Order = 2, Red = 0, Green = 0, Blue = 255, Name = "Blue" },
                new Color { Order = 3, Red = 0, Green = 0, Blue = 0, Name = "Black" },
                new Color { Order = 4, Red = 255, Green = 255, Blue = 255, Name = "White" }
            };

            colors.ForEach(s => context.Colors.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var graphMaps = new List<GraphMap>
            {
                new GraphMap { Columns = 2, Rows = 2, Name = "2x2 Sample Map" }
            };

            graphMaps.ForEach(s => context.GraphMaps.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var elementShapes = new List<Shape>
            {
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = true, OwnerID = 0, Row = 0, Column = 0, ShortName = "Circle", TypeExtension = "png" },
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = true, OwnerID = 1, Row = 1, Column = 0, ShortName = "Circle", TypeExtension = "png" },
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = true, OwnerID = 2, Row = 0, Column = 1, ShortName = "Circle", TypeExtension = "png" },
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = true, OwnerID = 3, Row = 1, Column = 1, ShortName = "Circle", TypeExtension = "png" },
            };

            var paletteShapes = new List<Shape>
            {
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = false, /* OwnerID = 4, */ Row = 0, Column = 0, ShortName = "Circle", TypeExtension = "png" },
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = false, /* OwnerID = 4, */ Row = 0, Column = 1, ShortName = "HollowBox", TypeExtension = "png" },
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = false, /* OwnerID = 4, */ Row = 1, Column = 0, ShortName = "CenteredVerticalLine", TypeExtension = "png" },
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = false, /* OwnerID = 4, */ Row = 1, Column = 1, ShortName = "CenteredHorizontalLine", TypeExtension = "png" },
            };

            foreach (Shape shape in elementShapes)
            {
                context.Shapes.AddOrUpdate(p => new { p.OwnerID, p.OwnerIsMapElement, p.Row, p.Column }, shape);
            }
            context.SaveChanges();

            var graphMapID = (from d in context.GraphMaps where d.Name == "2x2 Sample Map" select d.ID).First();

            foreach(Shape shape in context.Shapes.ToList())
            {
                MapElement newMapElement = new MapElement { Shape = shape, Row = shape.Row, Column = shape.Column, GraphMapID = graphMapID,
                    BackgroundColor = (from d in context.Colors where d.Name == "White" select d).First(),
                    ForegroundColor = (from d in context.Colors where d.Name == "Black" select d).First(),
                };
                context.MapElements.AddOrUpdate(p => new { p.GraphMapID, p.Row, p.Column }, newMapElement);
                context.SaveChanges();
            }
            context.SaveChanges();

            context.ColorPalettes.AddOrUpdate(p => p.Name,
                new ColorPalette { Name = "Default Simple 5-Color Palette", Order = 0, Columns = 3, Rows = 2, Colors = colors });
            context.SaveChanges();

            var shapePalette = new ShapePalette
            {
                Name = "Default Simple 4-Shape Palette", Columns = 2, Rows = 2, Order = 0
            };
            context.ShapePalettes.AddOrUpdate(p => p.Name, shapePalette);
            context.SaveChanges();

            foreach (Shape shape in paletteShapes)
            {
                shape.OwnerID = (from d in context.ShapePalettes where d.Name == "Default Simple 4-Shape Palette" select d.ID).First();
                context.Shapes.AddOrUpdate(p => new { p.OwnerID, p.OwnerIsMapElement, p.Row, p.Column }, shape);
            }
            context.SaveChanges();
        }
    }
}
