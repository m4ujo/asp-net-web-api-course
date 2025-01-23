using asp_net_web_api_course.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace asp_net_web_api_course.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VideoGameController : ControllerBase
  {
    static private List<VideoGame> videoGames = new List<VideoGame>
    {
      new VideoGame { Id = 1, Title = "The Legend of Zelda: Breath of the Wild", Platform = "Nintendo Switch", Developer = "Nintendo EPD", Publisher = "Nintendo" },
      new VideoGame { Id = 2, Title = "Super Mario Odyssey", Platform = "Nintendo Switch", Developer = "Nintendo EPD", Publisher = "Nintendo" },
      new VideoGame { Id = 3, Title = "The Witcher 3: Wild Hunt", Platform = "PlayStation 4", Developer = "CD Projekt Red", Publisher = "CD Projekt" },
    };

    [HttpGet]
    public ActionResult<List<VideoGame>> GetVideoGames()
    {
      return Ok(videoGames);
    }

    [HttpGet("{id}")]
    public ActionResult<VideoGame> GetVideoGameById(int id)
    {
      var videoGame = videoGames.FirstOrDefault(game => game.Id == id);

      if (videoGame is null)
        return NotFound();

      return Ok(videoGame);
    }

    [HttpPost]
    public ActionResult<VideoGame> AddVideoGame(VideoGame newGame)
    {
      if (newGame is null)
        return BadRequest();

      newGame.Id = videoGames.Max(game => game.Id) + 1;
      videoGames.Add(newGame);

      return CreatedAtAction(nameof(GetVideoGameById), new { id = newGame.Id }, newGame);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateVideoGame(int id, VideoGame updatedGame)
    {
      var videoGame = videoGames.FirstOrDefault(game => game.Id == id);

      if (videoGame is null)
        return NotFound();

      videoGame.Title = updatedGame.Title;
      videoGame.Publisher = updatedGame.Publisher;
      videoGame.Developer = updatedGame.Developer;
      videoGame.Platform = updatedGame.Platform;

      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteVideoGame(int id)
    {
      var videoGame = videoGames.FirstOrDefault(game => game.Id == id);

      if (videoGame is null)
        return NotFound();

      videoGames.Remove(videoGame);

      return NoContent();
    }
  }
}
