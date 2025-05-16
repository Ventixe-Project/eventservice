using Application.Interfaces;
using Application.Models;
using Persistence.Entities;
using Persistence.Interfaces;

namespace Application.Services
{
    public class EventService(IEventRepository eventRepository) : IEventService
    {
        private readonly IEventRepository _eventRepository = eventRepository;

        public async Task<EventResult> CreateEventAsync(CreateEventRequest request)
        {
            try
            {
                var eventEntity = new EventEntity
                {
                    EventImage = request.EventImage,
                    EventName = request.EventName,
                    EventDescription = request.EventDescription,
                    EventDate = request.EventDate,
                    EventLocation = request.EventLocation,
                };
                var result = await _eventRepository.AddAsync(eventEntity);
                return result.Success
                    ? new EventResult { Success = true }
                    : new EventResult { Success = false, Error = result.Error };
            }
            catch (Exception ex)
            {
                return new EventResult { Success = false, Error = ex.Message };
            }
        }

        public async Task<EventResult<IEnumerable<Event>>> GetEventsAsync()
        {
            var result = await _eventRepository.GetAllAsync();
            var events = result.Result?.Select(x => new Event
            {
                Id = x.Id,
                EventImage = x.EventImage,
                EventName = x.EventName,
                EventDescription = x.EventDescription,
                EventDate = x.EventDate,
                EventLocation = x.EventLocation,
            });

            return new EventResult<IEnumerable<Event>> { Success = true, Result = events };
        }

        public async Task<EventResult<Event?>> GetEventAsync(string eventId)
        {
            var result = await _eventRepository.GetAsync(x => x.Id == eventId);
            if (result.Success && result.Result != null)
            {
                var currentEvent = new Event
                {
                    Id = result.Result.Id,
                    EventImage = result.Result.EventImage,
                    EventName = result.Result.EventName,
                    EventDescription = result.Result.EventDescription,
                    EventDate = result.Result.EventDate,
                    EventLocation = result.Result.EventLocation,
                };

                return new EventResult<Event?> { Success = true, Result = currentEvent };
            }
            return new EventResult<Event?> { Success = false, Error = "Event not found" };
        }
    }
}
