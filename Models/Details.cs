namespace asp_net_web_api_course.Models
{
  public class Details
  {
    public int Id { get; set; }
    public string? Description { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int VideoGameId { get; set; }
  }
}
