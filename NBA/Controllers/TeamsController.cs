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
  public class TeamsController : ControllerBase
  {
    private readonly NBAContext _db;
    public TeamsController(NBAContext db)
    {
      _db = db;
    }

    // GET api/teams
    [HttpGet]
    public ActionResult<IEnumerable<Team>> Get(string location, string teamName, int nbaTeamsChampionships)
    {
      var query = _db.Teams.AsQueryable();
      if(location != null)
      {
        query = query.Where(team => team.Location == location);
      }

      if(teamName != null)
      {
        query = query.Where(team => team.TeamName == teamName);
      }

      if(nbaTeamsChampionships.ToString() != null)
      {
        query = query.Where(team => team.NbaTeamsChampionships == nbaTeamsChampionships);
      }

      return query.ToList();
    }
  }
}