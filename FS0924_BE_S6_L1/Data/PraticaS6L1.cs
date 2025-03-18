using FS0924_BE_S6_L1.Models;
using Microsoft.EntityFrameworkCore;

namespace FS0924_BE_S6_L1.Data
{
    public class PraticaS6L1 : DbContext
    {
        public PraticaS6L1(DbContextOptions<PraticaS6L1> options): base(options) { }

        public DbSet<Studente> Studenti { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Studente>().HasData(
                new Studente()
                {
                   StudenteId = Guid.Parse("7B3C3520-95C5-4E9B-B7CE-D29EEE9319C1"),
                   Nome = "Federico",
                   Cognome="Tonti",
                   Email = "federico.tonti@gmail.com",
                   DataDiNascita = new DateTime(1996,10,29)
                }
                );
        }

    }
}
