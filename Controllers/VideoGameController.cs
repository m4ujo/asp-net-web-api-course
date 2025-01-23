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
      new VideoGame { Id = 3, Title = "The Witcher 3: Wild Hunt", Platform = "PlayStation 4", Developer = "CD Projekt Red", Publisher = "CD Projekt" }
    };

    [HttpGet]
    public ActionResult<List<VideoGame>> GetVideoGames()
    {
      return Ok(videoGames);
    }
  }
}
