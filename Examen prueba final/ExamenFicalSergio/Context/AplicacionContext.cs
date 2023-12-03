using ExamenFicalSergio.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamenFicalSergio.Context
{
    public class AplicacionContext : DbContext
    {
        public AplicacionContext(DbContextOptions<AplicacionContext> options)
            : base(options)
        {

        }
        public DbSet<Disco> Disco { get; set; }
        public DbSet<Musica> Musica { get; set; }

    }
}
