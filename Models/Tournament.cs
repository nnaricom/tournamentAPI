using System;
using Newtonsoft.Json;
using tournamentAPI.Utilities;

namespace tournamentAPI.Models
{
    public class Tournament
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string InfoURL { get; set; }
        public DateTime AddDate { get; set; }
        public string TourneyPassword { get; set; }

        public Tournament() {
            ResetProps();
        }

        public void GeneratePassword() {
            this.TourneyPassword = Utils.GetUniqueKey(10);
        }

        public void ResetProps() {
            this.AddDate = DateTime.Now;
            GeneratePassword();
        }
        
    }
}