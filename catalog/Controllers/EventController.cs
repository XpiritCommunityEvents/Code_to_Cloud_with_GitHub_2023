using Microsoft.AspNetCore.Mvc;
using GloboTicket.Catalog.Repositories;

namespace GloboTicket.Catalog.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController : ControllerBase
{
    private readonly IEventRepository _eventRepository;

    private static int callcounter = 0;
    private readonly ILogger<EventController> _logger;

    public EventController(IEventRepository eventRepository, ILogger<EventController> logger)
    {
        _eventRepository = eventRepository;
        _logger = logger;
    }

    [HttpGet(Name = "GetEvents")]
    public async Task<IActionResult> GetAll()
    {
        // let 1 out of 4 requests fail
        if (callcounter++ % 4 == 0)
        {
            Thread.Sleep(2000);
            HttpContext.Abort();
            return Ok();
        }
        else
            return  Ok(await _eventRepository.GetEvents());
    }

    [HttpGet("{id}", Name = "GetById")]
    public async Task<IActionResult> GetById(Guid id)
    {        
        var evt = await _eventRepository.GetEventById(id);
        return Ok(evt);
    }

    [HttpPost(Name = "AddEvent")]
    public async Task<IActionResult> AddEvent(Event @event)
    {
        var newEvent = await _eventRepository.AddEvent(@event);
        return CreatedAtRoute("GetById", new { id = newEvent.EventId }, newEvent);
    }

    [HttpGet("artists", Name = "GetArtists")]
    public async Task<IActionResult> GetArtists()
    {
        return Ok(await _eventRepository.GetArtists());
    }

    [HttpGet("artists/{id}", Name = "GetArtistById")]
    public async Task<IActionResult> GetArtistById(Guid id)
    {
        var artist = await _eventRepository.GetArtistById(id);
        return Ok(artist);
    }

    [HttpPost("artists", Name = "AddArtist")]
    public async Task<IActionResult> AddArtist(Artist artist)
    {
        var newArtist = await _eventRepository.AddArtist(artist.Name, artist.Genre);
        return CreatedAtRoute("GetArtistById", new { id = newArtist.Id }, newArtist);
    }

}
