using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using tournamentAPI.Models;
using tournamentAPI.Utilities;


namespace tournamentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly TournamentContext _context;

        public TournamentController(TournamentContext context) {
            _context = context;
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
            item.GeneratePassword();
            _context.Tournaments.Add(item);
            _context.SaveChanges();

            
            return new JsonResult(new {
                id = item.Id,
                password = item.TourneyPassword
            });
            /* return CreatedAtRoute("GetTournament", new { id = item.Id, password = item.GetPassword() }, item); */
        }

        [HttpDelete("{pass}")]
        public IActionResult Delete(string pass) {
            var tournament = _context.Tournaments.FirstOrDefault(t => t.TourneyPassword == pass);
            if (tournament == null) {
                return NotFound();
            }

            _context.Tournaments.Remove(tournament);
            _context.SaveChanges();
            return NoContent();
        }
    }
}