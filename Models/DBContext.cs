using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShopBridgeWebAPI.Models
{
    public class DBContext : DbContext
    {

        public DBContext() : base("conn") { }
        public DbSet<Inventory> Inventorys { get; set; }
    }
}