using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NBA.Models
{
  public class Team
  {
    public Team()
    {
      this.Players = new HashSet<Player>();
    }

    public int TeamId { get; set; }

    [Required]
    [StringLength(60)]
    public string TeamName { get; set; }

    [Required]
    public string Location { get; set; }
    [Range(0, 255, ErrorMessage = "Number of Nba Championships should be between 0 and 255.")]
    public int NbaTeamsChampionships { get; set; }

    // [ForeignKey("TeamId")]
    public virtual ICollection<Player> Players { get; set; }

    }
}