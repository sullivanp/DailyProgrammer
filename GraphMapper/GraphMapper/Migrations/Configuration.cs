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
        }
    }
}
