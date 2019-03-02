using Microsoft.EntityFrameworkCore;

namespace LuizaLabTest.Model
{
    public class LuizaLabContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public LuizaLabContext(DbContextOptions options) : base(options)
        {


        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
