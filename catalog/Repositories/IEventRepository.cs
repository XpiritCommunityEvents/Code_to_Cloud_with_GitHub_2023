namespace GloboTicket.Catalog.Repositories;

public interface IEventRepository
{
  Task<IEnumerable<Event>> GetEvents();
  Task<Event> GetEventById(Guid eventId); 
  void UpdateSpecialOffer();
  Task<IEnumerable<Artist>> GetArtists();
  Task<Artist> GetArtistById(Guid artistId);

  Task<Artist> AddArtist(string name, string genre);

  Task<Event> AddEvent(Event @event);
}
