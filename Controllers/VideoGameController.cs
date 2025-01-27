using asp_net_web_api_course.Data;
using asp_net_web_api_course.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp_net_web_api_course.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VideoGameController(VideoGameDbContext context) : ControllerBase
  {
    private readonly VideoGameDbContext _context = context;

    [HttpGet]
    public async Task<ActionResult<List<VideoGame>>> GetVideoGames()
    {
      return Ok(await _context.VideoGames
        .Include(g => g.Details)
        .Include(g => g.Developer)
        .Include(g => g.Publisher)
        .Include(g => g.Genres)
        .ToListAsync<VideoGame>());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<VideoGame>> GetVideoGameById(int id)
    {
      var videoGame = await _context.VideoGames.FindAsync(id);
      if (videoGame is null)
        return NotFound();

      return Ok(videoGame);
    }

    [HttpPost]
    public async Task<ActionResult<VideoGame>> AddVideoGame(VideoGame newGame)
    {
      if (newGame is null)
        return BadRequest();

      _context.VideoGames.Add(newGame);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetVideoGameById), new { id = newGame.Id }, newGame);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVideoGame(int id, VideoGame updatedGame)
    {
      var videoGame = await _context.VideoGames.FindAsync(id);
      if (videoGame is null)
        return NotFound();

      videoGame.Title = updatedGame.Title;
      videoGame.Publisher = updatedGame.Publisher;
      videoGame.Developer = updatedGame.Developer;
      videoGame.Platform = updatedGame.Platform;

      await _context.SaveChangesAsync();

      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVideoGame(int id)
    {
      var videoGame = await _context.VideoGames.FindAsync(id);
      if (videoGame is null)
        return NotFound();

      _context.VideoGames.Remove(videoGame);
      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}
