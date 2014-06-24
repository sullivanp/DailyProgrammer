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
                new Color { Order = 4, Red = 255, Green = 255, Blue = 255, Name = "White" },
            };

            var newColors = new List<Color>
            {
                new Color { Order = 5, Red = 255, Green = 255, Blue = 0, Name = "Yellow" },
                new Color { Order = 6, Red = 0, Green = 255, Blue = 255, Name = "Cyan" },
                new Color { Order = 7, Red = 255, Green = 0, Blue = 255, Name = "Magenta" },
            };

            var newNewColors = new List<Color>
            {
                new Color { Order = 8, Red = 255, Green = 0, Blue = 0, Name = "Red" },
                new Color { Order = 9, Red = 0, Green = 255, Blue = 0, Name = "Green" },
                new Color { Order = 10, Red = 0, Green = 0, Blue = 255, Name = "Blue" },
                new Color { Order = 11, Red = 0, Green = 0, Blue = 0, Name = "Black" },
                new Color { Order = 12, Red = 255, Green = 255, Blue = 255, Name = "White" },
                new Color { Order = 13, Red = 255, Green = 255, Blue = 0, Name = "Yellow" },
                new Color { Order = 14, Red = 0, Green = 255, Blue = 255, Name = "Cyan" },
                new Color { Order = 15, Red = 255, Green = 0, Blue = 255, Name = "Magenta" },
            };

            colors.ForEach(s => context.Colors.AddOrUpdate(p => new { p.Order, p.Name }, s));
            context.SaveChanges();

            newColors.ForEach(s => context.Colors.AddOrUpdate(p => new { p.Order, p.Name }, s));
            context.SaveChanges();

            newNewColors.ForEach(s => context.Colors.AddOrUpdate(p => new { p.Order, p.Name }, s));
            context.SaveChanges();

            var elementShapes = new List<Shape>
            {
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = true, Row = 0, Column = 0, ShortName = "Circle", TypeExtension = "png" },
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = true, Row = 1, Column = 0, ShortName = "Circle", TypeExtension = "png" },
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = true, Row = 0, Column = 1, ShortName = "Circle", TypeExtension = "png" },
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = true, Row = 1, Column = 1, ShortName = "Circle", TypeExtension = "png" },
            };

            var newElementShapes = new List<Shape>
            {
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = true, Row = 0, Column = 0, ShortName = "Circle", TypeExtension = "png" },
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = true, Row = 0, Column = 1, ShortName = "CenteredVerticalLine", TypeExtension = "png" },
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = true, Row = 0, Column = 2, ShortName = "Circle", TypeExtension = "png" },
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = true, Row = 1, Column = 0, ShortName = "CenteredHorizontalLine", TypeExtension = "png" },
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = true, Row = 1, Column = 1, ShortName = "HollowBox", TypeExtension = "png" },
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = true, Row = 1, Column = 2, ShortName = "CenteredHorizontalLine", TypeExtension = "png" },
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = true, Row = 2, Column = 0, ShortName = "Circle", TypeExtension = "png" },
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = true, Row = 2, Column = 1, ShortName = "CenteredVerticalLine", TypeExtension = "png" },
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = true, Row = 2, Column = 2, ShortName = "Circle", TypeExtension = "png" },
            };

            elementShapes.ForEach(s => context.Shapes.AddOrUpdate(p => new { p.OwnerID, p.OwnerIsMapElement, p.Row, p.Column }, s));
            context.SaveChanges();

            newElementShapes.ForEach(s => context.Shapes.AddOrUpdate(e => new { e.OwnerID, e.OwnerIsMapElement, e.Row, e.Column }, s));
            context.SaveChanges();

            context.ShapePalettes.AddOrUpdate(p => p.Name,
                new ShapePalette
                {
                    Name = "Default Simple 4-Shape Palette", Columns = 2, Rows = 2, Order = 0, Shapes = new List<Shape>
                    {
                        new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = false, Row = 0, Column = 0, ShortName = "Circle", TypeExtension = "png" },
                        new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = false, Row = 0, Column = 1, ShortName = "HollowBox", TypeExtension = "png" },
                        new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = false, Row = 1, Column = 0, ShortName = "CenteredVerticalLine", TypeExtension = "png" },
                        new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = false, Row = 1, Column = 1, ShortName = "CenteredHorizontalLine", TypeExtension = "png" },
                    }
                }
            );
            context.SaveChanges();

            context.GraphMaps.AddOrUpdate(g => g.Name,
                new GraphMap
                {
                    Order = 0,
                    Columns = 2,
                    Rows = 2,
                    Name = "2x2 Sample Map",
                    MapElements = new List<MapElement>
                    {
                        new MapElement { Row = 0, Column = 0, BackgroundColor = (from d in context.Colors where d.Name == "White" select d).First(), ForegroundColor = (from d in context.Colors where d.Name == "Black" select d).First() },
                        new MapElement { Row = 0, Column = 1, BackgroundColor = (from d in context.Colors where d.Name == "White" select d).First(), ForegroundColor = (from d in context.Colors where d.Name == "Black" select d).First() },
                        new MapElement { Row = 1, Column = 0, BackgroundColor = (from d in context.Colors where d.Name == "White" select d).First(), ForegroundColor = (from d in context.Colors where d.Name == "Black" select d).First() },
                        new MapElement { Row = 1, Column = 1, BackgroundColor = (from d in context.Colors where d.Name == "White" select d).First(), ForegroundColor = (from d in context.Colors where d.Name == "Black" select d).First() },
                    }
                },
                new GraphMap
                {
                    Order = 1,
                    Columns = 3,
                    Rows = 3,
                    Name = "3x3 Sample Map",
                    MapElements = new List<MapElement>
                    {
                        new MapElement { Row = 0, Column = 0, BackgroundColor = (from d in context.Colors where d.Name == "White" select d).First(), ForegroundColor = (from d in context.Colors where d.Name == "Black" select d).First() },
                        new MapElement { Row = 0, Column = 1, BackgroundColor = (from d in context.Colors where d.Name == "White" select d).First(), ForegroundColor = (from d in context.Colors where d.Name == "Black" select d).First() },
                        new MapElement { Row = 0, Column = 2, BackgroundColor = (from d in context.Colors where d.Name == "White" select d).First(), ForegroundColor = (from d in context.Colors where d.Name == "Black" select d).First() },
                        new MapElement { Row = 1, Column = 0, BackgroundColor = (from d in context.Colors where d.Name == "White" select d).First(), ForegroundColor = (from d in context.Colors where d.Name == "Black" select d).First() },
                        new MapElement { Row = 1, Column = 1, BackgroundColor = (from d in context.Colors where d.Name == "White" select d).First(), ForegroundColor = (from d in context.Colors where d.Name == "Black" select d).First() },
                        new MapElement { Row = 1, Column = 2, BackgroundColor = (from d in context.Colors where d.Name == "White" select d).First(), ForegroundColor = (from d in context.Colors where d.Name == "Black" select d).First() },
                        new MapElement { Row = 2, Column = 0, BackgroundColor = (from d in context.Colors where d.Name == "White" select d).First(), ForegroundColor = (from d in context.Colors where d.Name == "Black" select d).First() },
                        new MapElement { Row = 2, Column = 1, BackgroundColor = (from d in context.Colors where d.Name == "White" select d).First(), ForegroundColor = (from d in context.Colors where d.Name == "Black" select d).First() },
                        new MapElement { Row = 2, Column = 2, BackgroundColor = (from d in context.Colors where d.Name == "White" select d).First(), ForegroundColor = (from d in context.Colors where d.Name == "Black" select d).First() },
                    }
                }
            );

            context.SaveChanges();

            var graphMapID = (from d in context.GraphMaps where d.Name == "2x2 Sample Map" select d.ID).First();
            var newGraphMapID = (from d in context.GraphMaps where d.Name == "3x3 Sample Map" select d.ID).First();

            context.ColorPalettes.AddOrUpdate(p => p.Name,
                new ColorPalette { Name = "Default Simple 5-Color Palette", Order = 0, Columns = 3, Rows = 2, Colors = colors },
                new ColorPalette { Name = "Default Simple 3-Color Palette", Order = 1, Columns = 2, Rows = 2, Colors = newColors }
                );
            context.SaveChanges();
        }
    }
}
