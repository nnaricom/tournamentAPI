using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using tournamentAPI.Models;
using Newtonsoft.Json;
using tournamentAPI.Utilities;
using System;


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
        public ActionResult<List<TournamentDTO>> GetAll() {
            var filteredTournaments = from t in _context.Tournaments
            select new TournamentDTO() {
                Id = t.Id,
                Name = t.Name,
                StartDate = t.StartDate,
                EndDate = t.EndDate,
                Description = t.Description,
                InfoURL = t.InfoURL          
            };

            return filteredTournaments.ToList();
        }

        [HttpGet("{id}", Name = "GetTournament")]
        public ActionResult<TournamentDTO> GetById(long id) {
            Tournament item = _context.Tournaments.Find(id);
            TournamentDTO tournament = new TournamentDTO {
                Id = item.Id,
                Name = item.Name,
                StartDate = item.StartDate,
                EndDate = item.EndDate,
                Description = item.Description,
                InfoURL = item.InfoURL      
            };
            if(item == null) {
                return NotFound();
            }
            return tournament;
        }

        [HttpPost]
        public IActionResult Create(Tournament item) {
            item.ResetProps();
            _context.Tournaments.Add(item);
            _context.SaveChanges();
            
             return Created(new Uri($"{Request.Path}/{item.Id}", UriKind.Relative), item);
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

        public string BuildURL(Tournament item) {
            return @"/api/tournament/" + item.Id;
        }
    }
}