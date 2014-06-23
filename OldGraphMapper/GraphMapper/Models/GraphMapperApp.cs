using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Web;

namespace GraphMapper.Models
{
    public class GraphMapperApp
    {
        [Key]
        public int GraphMapperID { get; set; }
        public virtual Map Map { get; set; }

        public GraphMapperApp()
        {
            this.Map = new Map();
        }
    }

    public class GraphMapperDBContext : DbContext
    {
        public DbSet<Map> Maps { get; set; }
        public DbSet<MapElement> MapElements { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }

        public System.Data.Entity.DbSet<GraphMapper.Models.GraphMapperApp> GraphMappers { get; set; }
    }
}