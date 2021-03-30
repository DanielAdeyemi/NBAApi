using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace NBA.Models
{
  public class NBAContext : DbContext
  {

    public NBAContext(DbContextOptions<NBAContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Team>()
        .HasData(
          new Team { TeamId = 1, TeamName = "Hawks", Location = "Atlanta", NbaTeamsChampionships = 7},
          new Team { TeamId = 2, TeamName = "Celtics", Location = "Boston", NbaTeamsChampionships = 7 },
          new Team { TeamId = 3, TeamName = "Nets", Location = "Brooklyn", NbaTeamsChampionships = 7 },
          new Team { TeamId = 4, TeamName = "Hornets", Location = "Hornets", NbaTeamsChampionships = 7 },
          new Team { TeamId = 5, TeamName = "Bulls", Location = "Chicago", NbaTeamsChampionships = 7 },
          new Team { TeamId = 6, TeamName = "Cavaliers", Location = "Cleveland", NbaTeamsChampionships = 7 },
          new Team { TeamId = 7, TeamName = "Mavericks", Location = "Dallas", NbaTeamsChampionships = 7 },
          new Team { TeamId = 8, TeamName = "Nuggets", Location = "Denver", NbaTeamsChampionships = 7 },
          new Team { TeamId = 9, TeamName = "Pistons", Location = "Detroit", NbaTeamsChampionships = 7 },
          new Team { TeamId = 10, TeamName = "Warriors", Location = "Golden State", NbaTeamsChampionships = 7 },
          new Team { TeamId = 11, TeamName = "Rockets", Location = "Houston", NbaTeamsChampionships = 7 },
          new Team { TeamId = 12, TeamName = "Pacers", Location = "Indiana", NbaTeamsChampionships = 7 },
          new Team { TeamId = 13, TeamName = "Clippers", Location = "Los Angeles", NbaTeamsChampionships = 7 },
          new Team { TeamId = 14, TeamName = "Lakers", Location = "Los Angeles", NbaTeamsChampionships = 7 },
          new Team { TeamId = 15, TeamName = "Grizzlies", Location = "Memphis", NbaTeamsChampionships = 7 },
          new Team { TeamId = 16, TeamName = "Heat", Location = "Miami", NbaTeamsChampionships = 7 },
          new Team { TeamId = 17, TeamName = "Bucks", Location = "Milwaukee", NbaTeamsChampionships = 7 },
          new Team { TeamId = 18, TeamName = "Timberwolves", Location = "Minnesota", NbaTeamsChampionships = 7 },
          new Team { TeamId = 19, TeamName = "Hornets", Location = "Charlotte", NbaTeamsChampionships = 7 },
          new Team { TeamId = 20, TeamName = "Knicks", Location = "New York", NbaTeamsChampionships = 7 },
          new Team { TeamId = 21, TeamName = "Thunder", Location = "Oklakhoma", NbaTeamsChampionships = 7 },
          new Team { TeamId = 22, TeamName = "Spurs", Location = "San Antonio", NbaTeamsChampionships = 7 },
          new Team { TeamId = 23, TeamName = "Magic", Location = "Orlando", NbaTeamsChampionships = 7 },
          new Team { TeamId = 24, TeamName = "76ers", Location = "Philadelphia", NbaTeamsChampionships = 7 },
          new Team { TeamId = 25, TeamName = "Suns", Location = "Phoenix", NbaTeamsChampionships = 7 },
          new Team { TeamId = 26, TeamName = "Trail Blazers", Location = "Portland", NbaTeamsChampionships = 7 },
          new Team { TeamId = 27, TeamName = "Kings", Location = "Sacramento", NbaTeamsChampionships = 7 },
          new Team { TeamId = 28, TeamName = "Raptors", Location = "Toronto", NbaTeamsChampionships = 7 },
          new Team { TeamId = 29, TeamName = "Jazz", Location = "Utah", NbaTeamsChampionships = 7 },
          new Team { TeamId = 30, TeamName = "Wizards", Location = "Washington", NbaTeamsChampionships = 7 },
          new Team { TeamId = 31, TeamName = "Free Agents", Location = "NBA", NbaTeamsChampionships = 7 }
        );
      // builder.Entity<Player>()
      //   .HasData(
      //     new Player { PlayerId = 1, PlayerName = "LeBron James",Position = "Forward", JerseyNumber = 23, NbaPlayersChampionships = 5, PlayOffs = 16, AllStars = 14, Team = Teams.FirstOrDefault(e => e.TeamId == 14)},
      //     new Player { PlayerId = 2, PlayerName = "Kevin Durant", Position = "Small Forward", JerseyNumber = 7, NbaPlayersChampionships = 2, PlayOffs = 10, AllStars = 11, Team = Teams.FirstOrDefault(e => e.TeamId == 3)},
      //     new Player { PlayerId = 3, PlayerName = "Stephen Cuury",Position = "Point Guard", JerseyNumber = 32, NbaPlayersChampionships = 3, PlayOffs = 11, AllStars = 7, Team = Teams.FirstOrDefault(e => e.TeamId == 10)}
      //   );
    }

    public virtual DbSet<Team> Teams { get; set; }
    public DbSet<Player> Players { get; set; }
  }
}