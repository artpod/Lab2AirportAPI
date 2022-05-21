namespace AirportAPIWebApp.Models
{
    public class Pilot
    {
        public Pilot()
        {
            Flights = new HashSet<Flight>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Birthday { get; set; }
         
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
