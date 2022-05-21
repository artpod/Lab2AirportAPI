namespace AirportAPIWebApp.Models
{
    public class Plane
    {
        public Plane()
        {
            Flights = new HashSet<Flight>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}
