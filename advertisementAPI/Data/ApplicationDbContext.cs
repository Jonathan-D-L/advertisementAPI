using advertisementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace advertisementAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Advert> Adverts { get; set; }
    }
}
