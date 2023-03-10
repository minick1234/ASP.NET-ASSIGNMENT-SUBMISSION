using Microsoft.EntityFrameworkCore;

using DZ_LAB1.Models;
namespace DZ_LAB1.Data
{
    public class UsersDBContext : DbContext
    {
        public UsersDBContext(DbContextOptions<UsersDBContext> options) : base(options)
        {

        }

        public DbSet<UserProfile> Users { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<RoutePath> Routes { get; set; }


    }
}
