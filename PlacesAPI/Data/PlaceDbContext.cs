using Microsoft.EntityFrameworkCore;
using PlacesAPI.Models.Entities;

namespace PlacesAPI.Data
{
    public class PlaceDbContext : DbContext
    {
        public PlaceDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Places> places { get; set; }
    }
}
