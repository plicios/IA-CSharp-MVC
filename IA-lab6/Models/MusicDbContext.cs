using System.Data.Entity;

namespace IA_lab6.Models
{
    public class MusicDbContext : DbContext
    {
        public MusicDbContext(): base("DefaultConnection") { }
        public DbSet<Song> Songs { get; set; }

        public DbSet<Genre> Genres { get; set; }
    }
}