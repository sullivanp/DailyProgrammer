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
            AutomaticMigrationsEnabled = false;
            ContextKey = "GraphMapper.Models.GraphMapperContext";
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

            /*
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

            newNewColors.ForEach(s => context.Colors.AddOrUpdate(p => new { p.Order, p.Name }, s));
            context.SaveChanges();
             

            context.Shapes.AddOrUpdate(s => new { s.OwnerID, s.OwnerIsMapElement, s.Row, s.Column },
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = true, Row = 0, Column = 0, ShortName = "Circle", TypeExtension = "png" },
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = true, Row = 1, Column = 0, ShortName = "Circle", TypeExtension = "png" },
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = true, Row = 0, Column = 1, ShortName = "Circle", TypeExtension = "png" },
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = true, Row = 1, Column = 1, ShortName = "Circle", TypeExtension = "png" },

                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = true, Row = 0, Column = 0, ShortName = "Circle", TypeExtension = "png" },
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = true, Row = 0, Column = 1, ShortName = "CenteredVerticalLine", TypeExtension = "png" },
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = true, Row = 0, Column = 2, ShortName = "Circle", TypeExtension = "png" },
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = true, Row = 1, Column = 0, ShortName = "CenteredHorizontalLine", TypeExtension = "png" },
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = true, Row = 1, Column = 1, ShortName = "HollowBox", TypeExtension = "png" },
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = true, Row = 1, Column = 2, ShortName = "CenteredHorizontalLine", TypeExtension = "png" },
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = true, Row = 2, Column = 0, ShortName = "Circle", TypeExtension = "png" },
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = true, Row = 2, Column = 1, ShortName = "CenteredVerticalLine", TypeExtension = "png" },
                new Shape { FileNameExtensionSeparator = ".", OwnerIsMapElement = true, Row = 2, Column = 2, ShortName = "Circle", TypeExtension = "png" }
            );
            context.SaveChanges();
            */

            context.ShapePalettes.AddOrUpdate(p => new { p.Name, p.Updated },
                new ShapePalette
                {
                    Updated = new DateTime(2014, 6, 26, 8, 32, 2),
                    Name = "Default Simple 4-Shape Palette",
                    Columns = 2,
                    Rows = 2,
                    Order = 0,
                    Shapes = new List<Shape>
                    {
                        new Shape { Row = 0, Column = 0, ShortName = "Circle" },
                        new Shape { Row = 0, Column = 1, ShortName = "HollowBox" },
                        new Shape { Row = 1, Column = 0, ShortName = "CenteredVerticalLine" },
                        new Shape { Row = 1, Column = 1, ShortName = "CenteredHorizontalLine" },
                    }
                }
            );
            context.SaveChanges();

            context.GraphMaps.AddOrUpdate(g => new { g.Name, g.Updated },
                new GraphMap
                {
                    Order = 0,
                    Columns = 2,
                    Rows = 2,
                    Name = "2x2 Sample Map",
                    Updated = new DateTime(2014, 6, 26, 8, 32, 0),
                    MapElements = new List<MapElement>
                    {
                        new MapElement
                        { 
                            Row = 0, Column = 0,
                            BackgroundColor = new Color { Name = "White", Order = 16, Red = 255, Green = 255, Blue = 255 },
                            ForegroundColor = new Color { Name = "Black", Order = 17, Red = 0, Green = 0, Blue = 0 },
                            Shape = new Shape { Row = 0, Column = 0, ShortName = "SolidFilledBox" }
                        },
                        new MapElement
                        {
                            Row = 0, Column = 1,
                            BackgroundColor = new Color { Name = "White", Order = 18, Red = 255, Green = 255, Blue = 255 },
                            ForegroundColor = new Color { Name = "Red", Order = 19, Red = 255, Green = 0, Blue = 0 },
                            Shape = new Shape { Row = 0, Column = 0, ShortName = "SolidFilledBox" }
                        },
                        new MapElement
                        {
                            Row = 1, Column = 0,
                            BackgroundColor = new Color { Name = "White", Order = 20, Red = 255, Green = 255, Blue = 255 },
                            ForegroundColor = new Color { Name = "Green", Order = 21, Red = 0, Green = 255, Blue = 0 },
                            Shape = new Shape { Row = 0, Column = 0, ShortName = "SolidFilledBox" }
                        },
                        new MapElement
                        {
                            Row = 1, Column = 1,
                            BackgroundColor = new Color { Name = "White", Order = 22, Red = 255, Green = 255, Blue = 255 },
                            ForegroundColor = new Color { Name = "Blue", Order = 23, Red = 0, Green = 0, Blue = 255 },
                            Shape = new Shape { Row = 0, Column = 0, ShortName = "SolidFilledBox" }
                        },
                    },
                    DefaultColorPalette = new ColorPalette
                    {
                        Rows = 2,
                        Columns = 2,
                        Name = "Default Color Palette for 2x2",
                        Order = 20,
                        Updated = new DateTime(2014, 6, 26, 8, 32, 15),
                        Colors = new List<Color>
                        {
                            new Color { Row = 0, Column = 0, Red = 0, Green = 0, Blue = 0, Name = "Black", Order = 40 },
                            new Color { Row = 0, Column = 1, Red = 255, Green = 255, Blue = 255, Name = "White", Order = 60 }
                        }
                    },
                    DefaultShapePalette = new ShapePalette
                    {
                        Rows = 2,
                        Columns = 2,
                        Name = "Default Shape Palette for 2x2",
                        Order = 80,
                        Updated = new DateTime(2014, 6, 26, 8, 32, 20),
                        Shapes = new List<Shape>
                        {
                            new Shape { Row = 0, Column = 0, ShortName = "Circle" },
                            new Shape { Row = 0, Column = 1, ShortName = "Circle" },
                            new Shape { Row = 1, Column = 0, ShortName = "Circle" },
                            new Shape { Row = 1, Column = 1, ShortName = "Circle" }
                        }
                    }
                },
                new GraphMap
                {
                    Order = 1,
                    Columns = 3,
                    Rows = 3,
                    Name = "3x3 Sample Map",
                    Updated = new DateTime(2014, 6, 26, 18, 35, 21),
                    MapElements = new List<MapElement>
                    {
                        new MapElement
                        {
                            Row = 0, Column = 0,
                            BackgroundColor = new Color { Name = "White", Order = 24, Red = 255, Green = 255, Blue = 255 },
                            ForegroundColor = new Color { Name = "Black", Order = 25, Red = 0, Green = 0, Blue = 0 },
                            Shape = new Shape {  Row = 0, Column = 0, ShortName = "Circle" }
                        },
                        new MapElement
                        {
                            Row = 0, Column = 1,
                            BackgroundColor = new Color { Name = "Red", Order = 26, Red = 255, Green = 0, Blue = 0 },
                            ForegroundColor = new Color { Name = "Black", Order = 27, Red = 0, Green = 0, Blue = 0 },
                            Shape = new Shape {  Row = 0, Column = 1, ShortName = "CenteredVerticalLine" }
                        },
                        new MapElement
                        {
                            Row = 0, Column = 2,
                            BackgroundColor = new Color { Name = "White", Order = 28, Red = 255, Green = 255, Blue = 255 },
                            ForegroundColor = new Color { Name = "Black", Order = 29, Red = 0, Green = 0, Blue = 0 },
                            Shape = new Shape {  Row = 0, Column = 0, ShortName = "Circle" }
                        },
                        new MapElement
                        {
                            Row = 1, Column = 0,
                            BackgroundColor = new Color { Name = "Blue", Order = 30, Red = 0, Green = 0, Blue = 255 },
                            ForegroundColor = new Color { Name = "Black", Order = 31, Red = 0, Green = 0, Blue = 0 },
                            Shape = new Shape {  Row = 1, Column = 0, ShortName = "CenteredHorizontalLine" }
                        },
                        new MapElement
                        {
                            Row = 1, Column = 1,
                            BackgroundColor = new Color { Name = "Red", Order = 32, Red = 255, Green = 0, Blue = 0 },
                            ForegroundColor = new Color { Name = "Blue", Order = 33, Red = 0, Green = 0, Blue = 255 },
                            Shape = new Shape { Row = 1, Column = 1, ShortName = "HollowBox" }
                        },
                        new MapElement
                        {
                            Row = 1, Column = 2,
                            BackgroundColor = new Color { Name = "Blue", Order = 34, Red = 0, Green = 0, Blue = 255 },
                            ForegroundColor = new Color { Name = "Black", Order = 35, Red = 0, Green = 0, Blue = 0 },
                            Shape = new Shape { Row = 1, Column = 0, ShortName = "CenteredHorizontalLine" }
                        },
                        new MapElement
                        {
                            Row = 2, Column = 0,
                            BackgroundColor = new Color { Name = "White", Order = 36, Red = 255, Green = 255, Blue = 255 },
                            ForegroundColor = new Color { Name = "Black", Order = 37, Red = 0, Green = 0, Blue = 0 },
                            Shape = new Shape { Row = 0, Column = 0, ShortName = "Circle" }
                        },
                        new MapElement
                        {
                            Row = 2, Column = 1,
                            BackgroundColor = new Color { Name = "Red", Order = 38, Red = 255, Green = 0, Blue = 0 },
                            ForegroundColor = new Color { Name = "Black", Order = 39, Red = 0, Green = 0, Blue = 0 },
                            Shape = new Shape { Row = 0, Column = 1, ShortName = "CenteredVerticalLine" }
                        },
                        new MapElement
                        {
                            Row = 2, Column = 2,
                            BackgroundColor = new Color { Name = "White", Order = 40, Red = 255, Green = 255, Blue = 255 },
                            ForegroundColor = new Color { Name = "Black", Order = 41, Red = 0, Green = 0, Blue = 0 },
                            Shape = new Shape { Row = 0, Column = 0, ShortName = "Circle" }
                        },
                    },
                    DefaultColorPalette = new ColorPalette
                    {
                        Rows = 3,
                        Columns = 2,
                        Name = "Default Color Palette for 3x3",
                        Order = 140,
                        Updated = new DateTime(2014, 6, 26, 18, 33, 11),
                        Colors = new List<Color>
                        {
                            new Color { Row = 0, Column = 0, Red = 255, Green = 0, Blue = 0, Name = "Red", Order = 160 },
                            new Color { Row = 0, Column = 1, Red = 0, Green = 255, Blue = 0, Name = "Green", Order = 180 },
                            new Color { Row = 1, Column = 0, Red = 0, Green = 0, Blue = 255, Name = "Blue", Order = 200 },
                            new Color { Row = 1, Column = 1, Red = 0, Green = 0, Blue = 0, Name = "Black", Order = 220 },
                            new Color { Row = 2, Column = 0, Red = 255, Green = 255, Blue = 255, Name = "White", Order = 240 }
                        }
                    },
                    DefaultShapePalette = new ShapePalette
                    {
                        Rows = 2,
                        Columns = 2,
                        Name = "Default Shape Palette for 3x3",
                        Order = 260,
                        Updated = new DateTime(2014, 6, 26, 8, 32, 50),
                        Shapes = new List<Shape>
                        {
                            new Shape { Row = 0, Column = 0, ShortName = "Circle" },
                            new Shape { Row = 0, Column = 1, ShortName = "CenteredVerticalLine" },
                            new Shape { Row = 1, Column = 0, ShortName = "CenteredHorizontalLine" },
                            new Shape { Row = 1, Column = 1, ShortName = "HollowBox" }
                        }
                    }
                }
            );

            context.SaveChanges();

            // var graphMapID = (from d in context.GraphMaps where d.Name == "2x2 Sample Map" select d.ID).First();
            // var newGraphMapID = (from d in context.GraphMaps where d.Name == "3x3 Sample Map" select d.ID).First();

            context.ColorPalettes.AddOrUpdate(p => new { p.Name, p.Updated },
                new ColorPalette
                {
                    Name = "Default Simple 3-Color Palette",
                    Order = 0,
                    Columns = 2,
                    Rows = 2,
                    Updated = new DateTime(2014, 6, 26, 8, 34, 1),
                    Colors = new List<Color>
                    {
                        new Color { Row = 0, Column = 0, Order = 5, Red = 255, Green = 255, Blue = 0, Name = "Yellow" },
                        new Color { Row = 0, Column = 1, Order = 6, Red = 0, Green = 255, Blue = 255, Name = "Cyan" },
                        new Color { Row = 1, Column = 0, Order = 7, Red = 255, Green = 0, Blue = 255, Name = "Magenta" },
                    }
                },
                new ColorPalette
                {
                    Name = "Default Simple 5-Color Palette",
                    Order = 1,
                    Columns = 3,
                    Rows = 2,
                    Updated = new DateTime(2014, 6, 26, 9, 43, 10),
                    Colors = new List<Color>
                    {
                        new Color { Row = 0, Column = 0, Order = 0, Red = 255, Green = 0, Blue = 0, Name = "Red" },
                        new Color { Row = 0, Column = 1, Order = 1, Red = 0, Green = 255, Blue = 0, Name = "Green" },
                        new Color { Row = 0, Column = 2, Order = 2, Red = 0, Green = 0, Blue = 255, Name = "Blue" },
                        new Color { Row = 1, Column = 0, Order = 3, Red = 0, Green = 0, Blue = 0, Name = "Black" },
                        new Color { Row = 1, Column = 1, Order = 4, Red = 255, Green = 255, Blue = 255, Name = "White" },
                    }
                }
            );
            context.SaveChanges();
        }
    }
}
