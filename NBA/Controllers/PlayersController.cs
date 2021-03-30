using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBA.Models;
using System.Linq;

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
    public async Task<ActionResult<IEnumerable<Player>>> Get()
    {
      var query = _db.Players.AsQueryable();

      foreach(Player player in query)
      {
        player.Team = _db.Teams.FirstOrDefault(team => team.TeamId == player.TeamId);
      }

      return await query.ToListAsync();
    }

    // POST: /api/players
    [HttpPost]
    public async Task<ActionResult<Player>> Post(Player player, int teamId)
    {
      var teamSelected = _db.Teams.FirstOrDefault(e => e.TeamId == teamId);
      _db.Players.Add(player);
      await _db.SaveChangesAsync();
      return CreatedAtAction("Post", new { id = player.PlayerId, teamSelected = player.Team }, player);
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
    
    //  DELETE: /api/teams/delete/id
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlayer(int id)
    {
      var player = await _db.Players.FindAsync(id);
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