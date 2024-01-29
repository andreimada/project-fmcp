using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Data.Contexts {
    public  class SqliteContext : DbContext{

        public SqliteContext() { }

        public SqliteContext(DbContextOptions<SqliteContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<InventoryRecord> InventoryRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=D:/Faculta/Master/sem3/fmcp/project-fmcp/project-fmcp/Data/inventory.db");
    }
}
