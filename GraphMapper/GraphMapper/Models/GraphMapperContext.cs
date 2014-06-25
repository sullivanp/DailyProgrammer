using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            //modelBuilder.Entity<MapElement>().Property(m => m.GraphMapID).IsOptional();
            modelBuilder.Entity<MapElement>()
                .HasOptional(t => t.GraphMap)
                .WithMany(t => t.MapElements)
                .HasForeignKey(d => d.GraphMapID)
                .WillCascadeOnDelete(true);
        }
    }
}