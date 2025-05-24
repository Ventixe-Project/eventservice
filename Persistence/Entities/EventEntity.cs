using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Entities
{
    public class EventEntity
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string EventName { get; set; } = null!;
        public string EventDescription { get; set; } = null!;
        public string EventLocation { get; set; } = null!;

        [Column(TypeName = "datetime2")]
        public DateTime EventDate { get; set; }
        public string EventImage { get; set; } = null!;
        public string EventCategory { get; set; } = null!;
    }
}
