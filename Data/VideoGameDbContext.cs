using asp_net_web_api_course.Models;
using Microsoft.EntityFrameworkCore;

namespace asp_net_web_api_course.Data
{
  public class VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : DbContext(options)
  {
    public DbSet<VideoGame> VideoGames => Set<VideoGame>();
    public DbSet<Details> Details => Set<Details>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<VideoGame>().HasData(
        new VideoGame
        {
          Id = 1,
          Title = "The Legend of Zelda: Breath of the Wild",
          Platform = "Nintendo Switch"
        },
        new VideoGame
        {
          Id = 2,
          Title = "Super Mario Odyssey",
          Platform = "Nintendo Switch"
        },
        new VideoGame
        {
          Id = 3,
          Title = "The Witcher 3: Wild Hunt",
          Platform = "PlayStation 4"
        }
      );
    }
  }
}
