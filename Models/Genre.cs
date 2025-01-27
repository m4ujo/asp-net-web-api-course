using System.Text.Json.Serialization;

namespace asp_net_web_api_course.Models
{
  public class Genre
  {
    public int Id { get; set; }
    public required string Name { get; set; }
    
    [JsonIgnore]
    public List<VideoGame>? VideoGames { get; set; }
  }
}
