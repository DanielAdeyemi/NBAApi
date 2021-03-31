using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBA.Models;
using System.Linq;
using System;

namespace NBA.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PlayersController : ControllerBase
  {
    private readonly NBAContext _db;
    public PlayersController(NBAContext db)
    {
      _db = db;
    }

    // GET api/players
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Player>>> Get(string playerId, string playerName, string position, string jerseyNumber, string nbaChampionships, string allstars, string teamId)
    {
      var query = _db.Players.AsQueryable();

      if(playerName != null)
      {
        query = query.Where(player => player.PlayerName == playerName);
      }

      if(Int32.TryParse(teamId, out int parseTeamId))
      {
        query = query.Where(player => player.TeamId == parseTeamId);
      }

      return await query.ToListAsync();
    }

    // POST: /api/players/?teamId=14
    [HttpPost]
    public async Task<ActionResult<Player>> Post(Player player, int teamId)
    {
      var thisTeam = _db.Teams
        .Include(entry => entry.Players)
        .FirstOrDefault(entry => entry.TeamId == teamId);

      if(thisTeam != null)
      {
        player.TeamId = thisTeam.TeamId;
        player.Team = thisTeam.TeamName;
        _db.Players.Add(player);
        await _db.SaveChangesAsync();
      }
      else
      {
        return BadRequest();
      }

      return CreatedAtAction("Post", new { id = player.PlayerId}, player);
    }

    // PUT: api/players/5
    [HttpPut("{id}")]
    public async Task<ActionResult<Player>> Put(int id, Player player)
    {
      if(id != player.PlayerId)
      {
        return BadRequest();
      }
      _db.Entry(player).State = EntityState.Modified;
      try
      {
          await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
          if(!PlayerExists(id))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
      }
      return NoContent();
    }
    
    //  DELETE: /api/players/delete/id
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlayer(int id)
    {
      var player = await _db.Players.FindAsync(id);
      // var thisPlayer =  await _db.Players.FindAsync(player.PlayerId);
      Console.WriteLine("TEST TEST");
      Console.WriteLine("Player: " + player.PlayerName);

      if(player == null)
      {
        return NotFound();
      }
      
      _db.Players.Remove(player);
      await _db.SaveChangesAsync();
      return NoContent();
    }
    
    private bool PlayerExists(int id)
    {
      return _db.Players.Any(e => e.PlayerId == id);
    }
  }
}