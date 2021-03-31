using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBA.Models;
using System.Linq;
using System;
using System.IO;

namespace NBA.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TeamsController : ControllerBase
  {
    private readonly NBAContext _db;
    public TeamsController(NBAContext db)
    {
      _db = db;
    }

    // GET api/Teams
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Team>>> Get(string location, string teamName, string nbaTeamsChampionships)
    {
      var query = _db.Teams
        .Include(entry => entry.Players)
        .AsQueryable();

      if(location != null)
      {
        query = query.Where(team => team.Location == location);
      }

      if(teamName != null)
      {
        query = query.Where(team => team.TeamName == teamName);
      }

      if(Int32.TryParse(nbaTeamsChampionships, out int numberOfC))
      {
        query = query.Where(team => team.NbaTeamsChampionships == numberOfC);
      }

      return await query.ToListAsync();
    }

    // GET: api/Teams/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Team>> GetTeam(int id)
    {
        var team = await _db.Teams
          .Include(entry => entry.Players)
          .FirstOrDefaultAsync(team => team.TeamId == id);
        var thisTeam = await _db.Teams.FindAsync(team.TeamId);

        if (thisTeam == null)
        {
            return NotFound();
        }
        return thisTeam;
    }

    // PUT: api/teams/5
    [HttpPut("{id}")]
    public async Task<ActionResult<Team>> Put(int id, Team team)
    {
      if(id != team.TeamId)
      {
        return BadRequest();
      }
      _db.Entry(team).State = EntityState.Modified;
      try
      {
          await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
          if(!TeamExists(id))
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
    // POST: /api/teams
    [HttpPost]
    public async Task<ActionResult<Team>> Post(Team team)
    {
      _db.Teams.Add(team);
      await _db.SaveChangesAsync();
      return CreatedAtAction("Post", new { id = team.TeamId}, team);
    }
    
    //  DELETE: /api/teams/delete/id
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeam(int id)
    {
      var team = await _db.Teams.FindAsync(id);
      var faTeam = await _db.Teams.FirstOrDefaultAsync(team => team.TeamName == "Free Agents");

      foreach(Player player in _db.Teams.Players)
      {
        faTeam.Players.Add(Player);
      }

      if(team == null)
      {
        return NotFound();
      }
      
      _db.Teams.Remove(team);
      await _db.SaveChangesAsync();
      return NoContent();
    }
    
    private bool TeamExists(int id)
    {
      return _db.Teams.Any(e => e.TeamId == id);
    }
  }
}