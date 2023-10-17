using GloboTicket.Catalog.Infrastructure;

namespace GloboTicket.Catalog.Repositories;

public class EventRepository : IEventRepository
{
    private readonly ILogger<EventRepository> logger;

    public EventRepository(ILogger<EventRepository> logger)
    {
        this.logger = logger;
    }

    public Task<IEnumerable<Event>> GetEvents()
    {
        // this just returning an in-memory list for now
        return Task.FromResult((IEnumerable<Event>)Database.Events);
    }

    public Task<Event> GetEventById(Guid eventId)
    {
        var @event = Database.Events.FirstOrDefault(e => e.EventId == eventId);
        if (@event == null)
        {
            throw new InvalidOperationException("Event not found");
        }
        return Task.FromResult(@event);
    }

    // scheduled task calls this periodically to put one random item on special offer
    public void UpdateSpecialOffer()
    {
        Database.LoadSampleData();
        // pick a random one to put on special offer
        var random = new Random();
        var specialOfferEvent = Database.Events[random.Next(0, Database.Events.Count)];
        // 20 percent off
        specialOfferEvent.Price = (int)(specialOfferEvent.Price * 0.8);
    }

    public Task<Artist> AddArtist(string name, string genre)
    {
        var artist = new Artist(Guid.NewGuid(), name, genre);
        Database.Artists.Add(artist);
        return Task.FromResult(artist);
    }

    public Task<IEnumerable<Artist>> GetArtists()
    {
        return Task.FromResult((IEnumerable<Artist>)Database.Artists);
    }
}
