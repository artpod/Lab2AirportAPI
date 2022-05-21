namespace AirportAPIWebApp.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public TimeSpan? Time { get; set; }
        public int? PilotId { get; set; }
        public int? AirportId { get; set; }
        public int? PlaneId { get; set; }

        public virtual Airport? Airport { get; set; }
        public virtual Pilot? Pilot { get; set; }
        public virtual Plane? Plane { get; set; }
    }
}
