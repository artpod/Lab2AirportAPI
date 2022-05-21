namespace AirportAPIWebApp.Models
{
    public class Airport
    {
        public Airport()
        {
            Flights = new HashSet<Flight>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CityId { get; set; }

        public virtual City? City { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
