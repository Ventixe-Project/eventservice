using Application.Models;

namespace Application.Interfaces
{
    public interface IEventService
    {
        Task<EventResult> CreateEventAsync(CreateEventRequest request);
        Task<EventResult<IEnumerable<Event>>> GetEventsAsync();
        Task<EventResult<Event?>> GetEventAsync(string eventId);
    }
}
