using System;
using Newtonsoft.Json;
using tournamentAPI.Utilities;

namespace tournamentAPI.Models
{
    public class TournamentDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string InfoURL { get; set; }
        
    }
}