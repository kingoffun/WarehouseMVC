using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace sklad.Models
{
    public class WarehouseContext : DbContext
    {
        public DbSet<Thing> Things { get; set; }
        //public DbSet<Thing> Includes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Thing>()
                .HasMany(m => m.Includes)
                .WithMany()
                .Map(x => x.ToTable("Includes"));
        }
    }
}