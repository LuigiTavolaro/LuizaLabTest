using Microsoft.EntityFrameworkCore;

namespace LuizaLabTest.Model
{
    public class LuizaLabContext : DbContext
    {
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
