namespace AirportAPIWebApp.Models
{
    public class City
    {
        public City()
        {
            Airports = new HashSet<Airport>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Airport> Airports { get; set; }
    }
}
