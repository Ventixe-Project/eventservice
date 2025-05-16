namespace Application.Models
{
    public class Event
    {
        public string Id { get; set; } = null!;
        public string EventName { get; set; } = null!;
        public string EventDescription { get; set; } = null!;
        public string EventLocation { get; set; } = null!;

        public DateTime EventDate { get; set; }
        public string EventImage { get; set; } = null!;
        public string EventCategory { get; set; } = null!;
    }
}
