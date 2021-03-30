using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NBA.Models
{
  public class Player
  {
    public int PlayerId { get; set; }

    [Required]
    [StringLength(60)]
    public string PlayerName { get; set; }
    
    [Required]
    public string Position { get; set; }

    [Required]
    [Range(0, 100, ErrorMessage = "Jersey Number should be between 0 and 100.")]
    public int JerseyNumber { get; set; }

    [Required]
    [Range(0, 60, ErrorMessage = "Number of Nba Championships should be between 0 and 60.")]
    public int NbaPlayersChampionships { get; set; }

    [Required]
    [Range(0, 60, ErrorMessage = "Number of Nba PlayOffs should be between 0 and 60.")]
    public int PlayOffs { get; set; }

    [Required]
    [Range(0, 60, ErrorMessage = "Number of Nba Allstar appearences should be between 0 and 60.")]
    public int AllStars { get; set; }
    
    public virtual Team Team { get; set; }
  }
}