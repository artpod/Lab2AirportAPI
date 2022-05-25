using System.ComponentModel.DataAnnotations;

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
        [Range(1955,2004, ErrorMessage="Age should be between 1955 and 2004")]
        public int? Birthday { get; set; }
         
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
