using Microsoft.EntityFrameworkCore;

namespace LuizaLabTest.Model
{
    public class LuizaLabContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Wish> Wishes { get; set; }

        public LuizaLabContext(DbContextOptions options) : base(options)
        {


        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Wish>()
                .HasKey(k => new { k.ProductId, k.UserId});

        }


    }
}
