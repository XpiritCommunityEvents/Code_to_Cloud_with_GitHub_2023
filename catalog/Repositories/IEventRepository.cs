namespace GloboTicket.Catalog.Repositories;

public interface IEventRepository
{
  Task<IEnumerable<Event>> GetEvents();
  Task<Event> GetEventById(Guid eventId); 
  void UpdateSpecialOffer();
  Task<IEnumerable<Artist>> GetArtists();
  Task<Artist> AddArtist(string name, string genre);
}
