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

            context.ShapePalettes.AddOrUpdate(p => p.Name,
                new ShapePalette
                {
                    Name = "Default Simple 4-Shape Palette", Columns = 2, Rows = 2, Order = 0, Shapes = new List<Shape>
                    {
                        new Shape { FileNameExtensionSeparator = ".", Row = 0, Column = 0, ShortName = "Circle", TypeExtension = "png" },
                        new Shape { FileNameExtensionSeparator = ".", Row = 0, Column = 1, ShortName = "HollowBox", TypeExtension = "png" },
                        new Shape { FileNameExtensionSeparator = ".", Row = 1, Column = 0, ShortName = "CenteredVerticalLine", TypeExtension = "png" },
                        new Shape { FileNameExtensionSeparator = ".", Row = 1, Column = 1, ShortName = "CenteredHorizontalLine", TypeExtension = "png" },
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
                        new MapElement
                        { 
                            Row = 0, Column = 0,
                            BackgroundColor = new Color { Name = "White", Order = 16, Red = 255, Green = 255, Blue = 255 },
                            ForegroundColor = new Color { Name = "Black", Order = 17, Red = 0, Green = 0, Blue = 0 },
                            Shape = new Shape { FileNameExtensionSeparator = ".", Row = 0, Column = 0, ShortName = "Circle", TypeExtension = "png" }
                        },
                        new MapElement
                        {
                            Row = 0, Column = 1,
                            BackgroundColor = new Color { Name = "White", Order = 18, Red = 255, Green = 255, Blue = 255 },
                            ForegroundColor = new Color { Name = "Black", Order = 19, Red = 0, Green = 0, Blue = 0 },
                            Shape = new Shape { FileNameExtensionSeparator = ".", Row = 0, Column = 0, ShortName = "Circle", TypeExtension = "png" }
                        },
                        new MapElement
                        {
                            Row = 1, Column = 0,
                            BackgroundColor = new Color { Name = "White", Order = 20, Red = 255, Green = 255, Blue = 255 },
                            ForegroundColor = new Color { Name = "Black", Order = 21, Red = 0, Green = 0, Blue = 0 },
                            Shape = new Shape { FileNameExtensionSeparator = ".", Row = 0, Column = 0, ShortName = "Circle", TypeExtension = "png" }
                        },
                        new MapElement
                        {
                            Row = 1, Column = 1,
                            BackgroundColor = new Color { Name = "White", Order = 22, Red = 255, Green = 255, Blue = 255 },
                            ForegroundColor = new Color { Name = "Black", Order = 23, Red = 0, Green = 0, Blue = 0 },
                            Shape = new Shape { FileNameExtensionSeparator = ".", Row = 0, Column = 0, ShortName = "Circle", TypeExtension = "png" }
                        },
                    },
                    DefaultColorPalette = new ColorPalette
                    {
                        Rows = 2, Columns = 2, Name = "Default Color Palette for 2x2", Order = 20,
                        Colors = new List<Color>
                        {
                            new Color { Red = 0, Green = 0, Blue = 0, Name = "Black", Order = 40 },
                            new Color { Red = 255, Green = 255, Blue = 255, Name = "White", Order = 60 }
                        }
                    },
                    DefaultShapePalette = new ShapePalette
                    {
                        Rows = 2, Columns = 2, Name = "Default Shape Palette for 2x2", Order = 80,
                        Shapes = new List<Shape>
                        {
                            new Shape { Row = 0, Column = 0, ShortName = "Circle", FileNameExtensionSeparator = ".", TypeExtension = "png" },
                            new Shape { Row = 0, Column = 1, ShortName = "Circle", FileNameExtensionSeparator = ".", TypeExtension = "png" },
                            new Shape { Row = 1, Column = 0, ShortName = "Circle", FileNameExtensionSeparator = ".", TypeExtension = "png" },
                            new Shape { Row = 1, Column = 1, ShortName = "Circle", FileNameExtensionSeparator = ".", TypeExtension = "png" }
                        }
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
                        new MapElement
                        {
                            Row = 0, Column = 0,
                            BackgroundColor = new Color { Name = "White", Order = 24, Red = 255, Green = 255, Blue = 255 },
                            ForegroundColor = new Color { Name = "Black", Order = 25, Red = 0, Green = 0, Blue = 0 },
                            Shape = new Shape { FileNameExtensionSeparator = ".", Row = 0, Column = 0, ShortName = "Circle", TypeExtension = "png" }
                        },
                        new MapElement
                        {
                            Row = 0, Column = 1,
                            BackgroundColor = new Color { Name = "White", Order = 26, Red = 255, Green = 255, Blue = 255 },
                            ForegroundColor = new Color { Name = "Black", Order = 27, Red = 0, Green = 0, Blue = 0 },
                            Shape = new Shape { FileNameExtensionSeparator = ".", Row = 0, Column = 1, ShortName = "CenteredVerticalLine", TypeExtension = "png" }
                        },
                        new MapElement
                        {
                            Row = 0, Column = 2,
                            BackgroundColor = new Color { Name = "White", Order = 28, Red = 255, Green = 255, Blue = 255 },
                            ForegroundColor = new Color { Name = "Black", Order = 29, Red = 0, Green = 0, Blue = 0 },
                            Shape = new Shape { FileNameExtensionSeparator = ".", Row = 0, Column = 0, ShortName = "Circle", TypeExtension = "png" }
                        },
                        new MapElement
                        {
                            Row = 1, Column = 0,
                            BackgroundColor = new Color { Name = "White", Order = 30, Red = 255, Green = 255, Blue = 255 },
                            ForegroundColor = new Color { Name = "Black", Order = 31, Red = 0, Green = 0, Blue = 0 },
                            Shape = new Shape { FileNameExtensionSeparator = ".", Row = 1, Column = 0, ShortName = "CenteredHorizontalLine", TypeExtension = "png" }
                        },
                        new MapElement
                        {
                            Row = 1, Column = 1,
                            BackgroundColor = new Color { Name = "White", Order = 32, Red = 255, Green = 255, Blue = 255 },
                            ForegroundColor = new Color { Name = "Black", Order = 33, Red = 0, Green = 0, Blue = 0 },
                            Shape = new Shape { FileNameExtensionSeparator = ".", Row = 1, Column = 1, ShortName = "HollowBox", TypeExtension = "png" }
                        },
                        new MapElement
                        {
                            Row = 1, Column = 2,
                            BackgroundColor = new Color { Name = "White", Order = 34, Red = 255, Green = 255, Blue = 255 },
                            ForegroundColor = new Color { Name = "Black", Order = 35, Red = 0, Green = 0, Blue = 0 },
                            Shape = new Shape { FileNameExtensionSeparator = ".", Row = 1, Column = 0, ShortName = "CenteredHorizontalLine", TypeExtension = "png" }
                        },
                        new MapElement
                        {
                            Row = 2, Column = 0,
                            BackgroundColor = new Color { Name = "White", Order = 36, Red = 255, Green = 255, Blue = 255 },
                            ForegroundColor = new Color { Name = "Black", Order = 37, Red = 0, Green = 0, Blue = 0 },
                            Shape = new Shape { FileNameExtensionSeparator = ".", Row = 0, Column = 0, ShortName = "Circle", TypeExtension = "png" }
                        },
                        new MapElement
                        {
                            Row = 2, Column = 1,
                            BackgroundColor = new Color { Name = "White", Order = 38, Red = 255, Green = 255, Blue = 255 },
                            ForegroundColor = new Color { Name = "Black", Order = 39, Red = 0, Green = 0, Blue = 0 },
                            Shape = new Shape { FileNameExtensionSeparator = ".", Row = 0, Column = 1, ShortName = "CenteredVerticalLine", TypeExtension = "png" }
                        },
                        new MapElement
                        {
                            Row = 2, Column = 2,
                            BackgroundColor = new Color { Name = "White", Order = 40, Red = 255, Green = 255, Blue = 255 },
                            ForegroundColor = new Color { Name = "Black", Order = 41, Red = 0, Green = 0, Blue = 0 },
                            Shape = new Shape { FileNameExtensionSeparator = ".", Row = 0, Column = 0, ShortName = "Circle", TypeExtension = "png" }
                        },
                    },
                    DefaultColorPalette = new ColorPalette
                    {
                        Rows = 3,
                        Columns = 2,
                        Name = "Default Color Palette for 3x3",
                        Order = 140,
                        Colors = new List<Color>
                        {
                            new Color { Red = 255, Green = 0, Blue = 0, Name = "Red", Order = 160 },
                            new Color { Red = 0, Green = 255, Blue = 0, Name = "Green", Order = 180 },
                            new Color { Red = 0, Green = 0, Blue = 255, Name = "Blue", Order = 200 },
                            new Color { Red = 0, Green = 0, Blue = 0, Name = "Black", Order = 220 },
                            new Color { Red = 255, Green = 255, Blue = 255, Name = "White", Order = 240 }
                        }
                    },
                    DefaultShapePalette = new ShapePalette
                    {
                        Rows = 2, Columns = 2, Name = "Default Shape Palette for 3x3", Order = 260,
                        Shapes = new List<Shape>
                        {
                            new Shape { Row = 0, Column = 0, ShortName = "Circle", FileNameExtensionSeparator = ".", TypeExtension = "png" },
                            new Shape { Row = 0, Column = 1, ShortName = "CenteredVerticalLine", FileNameExtensionSeparator = ".", TypeExtension = "png" },
                            new Shape { Row = 1, Column = 0, ShortName = "CenteredHorizontalLine", FileNameExtensionSeparator = ".", TypeExtension = "png" },
                            new Shape { Row = 1, Column = 1, ShortName = "HollowBox", FileNameExtensionSeparator = ".", TypeExtension = "png" }
                        }
                    }
                }
            );

            context.SaveChanges();

            // var graphMapID = (from d in context.GraphMaps where d.Name == "2x2 Sample Map" select d.ID).First();
            // var newGraphMapID = (from d in context.GraphMaps where d.Name == "3x3 Sample Map" select d.ID).First();

            context.ColorPalettes.AddOrUpdate(p => p.Name,
                new ColorPalette
                {
                    Name = "Default Simple 3-Color Palette", Order = 0, Columns = 2, Rows = 2,
                    Colors = new List<Color>
                    {
                        new Color { Order = 5, Red = 255, Green = 255, Blue = 0, Name = "Yellow" },
                        new Color { Order = 6, Red = 0, Green = 255, Blue = 255, Name = "Cyan" },
                        new Color { Order = 7, Red = 255, Green = 0, Blue = 255, Name = "Magenta" },
                    }
                },
                new ColorPalette
                {
                    Name = "Default Simple 5-Color Palette", Order = 1, Columns = 3, Rows = 2,
                    Colors = new List<Color>
                    {
                        new Color { Order = 0, Red = 255, Green = 0, Blue = 0, Name = "Red" },
                        new Color { Order = 1, Red = 0, Green = 255, Blue = 0, Name = "Green" },
                        new Color { Order = 2, Red = 0, Green = 0, Blue = 255, Name = "Blue" },
                        new Color { Order = 3, Red = 0, Green = 0, Blue = 0, Name = "Black" },
                        new Color { Order = 4, Red = 255, Green = 255, Blue = 255, Name = "White" },
                    }
                }
            );
            context.SaveChanges();
        }
    }
}
