using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using tournamentAPI.Models;

namespace tournamentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly TournamentContext _context;

        public TournamentController(TournamentContext context) {
            _context = context;

            if(_context.Tournaments.Count() == 0) {
                _context.Tournaments.Add(new Tournament { Name = "Test1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Tournament>> GetAll() {
            return _context.Tournaments.ToList();
        }

        [HttpGet("{id}", Name = "GetTournament")]
        public ActionResult<Tournament> GetById(long id) {
            var item = _context.Tournaments.Find(id);
            if(item == null) {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(Tournament item) {
            _context.Tournaments.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTournament", new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id) {
            var tournament = _context.Tournaments.Find(id);
            if (tournament == null) {
                return NotFound();
            }

            _context.Tournaments.Remove(tournament);
            _context.SaveChanges();
            return NoContent();
        }
    }
}