using FS0924_BE_S6_L1.Models;
using Microsoft.EntityFrameworkCore;

namespace FS0924_BE_S6_L1.Data
{
    public class PraticaS6L1 : DbContext
    {
        public PraticaS6L1(DbContextOptions<PraticaS6L1> options): base(options) { }

        public DbSet<Studente> Studenti { get; set; }

    }
}
