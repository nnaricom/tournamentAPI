using Microsoft.EntityFrameworkCore;

namespace tournamentAPI.Models
{
    public class TournamentContext : DbContext
    {
        public TournamentContext(DbContextOptions<TournamentContext> options) : base(options)
        {
            
        }

        public DbSet<Tournament> Tournaments { get; set; }
    }
}