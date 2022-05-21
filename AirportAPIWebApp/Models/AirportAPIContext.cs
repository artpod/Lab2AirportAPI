using Microsoft.EntityFrameworkCore;

namespace AirportAPIWebApp.Models
{
    public class AirportAPIContext : DbContext
    {
        public virtual DbSet<Airport> Airports { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Pilot> Pilots { get; set; }
        public virtual DbSet<Plane> Planes { get; set; }
        public AirportAPIContext(DbContextOptions<AirportAPIContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
