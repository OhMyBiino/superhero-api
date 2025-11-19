using Microsoft.EntityFrameworkCore;
using SuperHero.API.Models;

namespace SuperHero.API.DBContext
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<SuperHeroModel> SuperHeroModels { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SuperHeroModel>().HasData(
                new SuperHeroModel
                {
                    Id = 1,
                    Name = "Peter Parker",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Location = "New York City"
                },
                new SuperHeroModel
                {
                    Id = 2,
                    Name = "Tony Stark",
                    FirstName = "Tony",
                    LastName = "Stark",
                    Location = "Malibu"
                },
                new SuperHeroModel 
                {
                    Id = 3,
                    Name = "Captain America",
                    FirstName = "Steve",
                    LastName = "Rogers",
                    Location = "Brooklyn"
                });
        }
    }
}
