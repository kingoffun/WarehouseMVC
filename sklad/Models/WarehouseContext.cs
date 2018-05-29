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
    }
}