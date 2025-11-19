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
    }
}
