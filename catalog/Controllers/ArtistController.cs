using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.Catalog.Controllers;

[ApiController]
[Route("[controller]")]
public class ArtistController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Artist>), StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetAll()
    {
        // TODO: Implement logic to retrieve artist data
        return Ok(Enumerable.Empty<Artist>());
    }

    [HttpGet("{id}", Name = "GetArtistById")]
    [ProducesResponseType(typeof(Artist), StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetById(Guid id)
    {
        return NotFound();
    }

    [HttpPost]
    [ProducesResponseType(typeof(Artist), StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Add([FromBody] Artist artist)
    {
        // TODO: Implement logic to add the artist to the database and return the created object
        return CreatedAtRoute("GetArtistById", new { id = artist.Id }, artist);
    }

    [HttpPut]
    [ProducesResponseType(typeof(Artist), StatusCodes.Status202Accepted)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update([FromBody] Artist artist)
    {
        // TODO: Implement logic to update the artist in the database and return the updated object
        return Accepted(artist);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> DeleteById([FromRoute]Guid id)
    {
        // TODO: implement this controller action
        return NoContent();
    }
}

