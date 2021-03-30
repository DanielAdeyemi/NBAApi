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

      return await query.ToListAsync();
    }
  }
}