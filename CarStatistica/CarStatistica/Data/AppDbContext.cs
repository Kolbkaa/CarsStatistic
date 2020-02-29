using CarStatistica.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarStatistica.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany<Car>(model => model.Cars).WithOne(model => model.User).IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Car>().HasMany<Refueling>(model => model.Refuelings).WithOne(model => model.Car)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Car> Cars { get; set; }
       
        public DbSet<Refueling> Refuelings { get; set; }
    }
}
