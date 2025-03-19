using FS0924_BE_S6_L1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FS0924_BE_S6_L1.Data
{
    public class PraticaS6L1 : IdentityDbContext<ApplicationUser,ApplicationRole,string,
        IdentityUserClaim<string>,ApplicationUserRole,IdentityUserLogin<string>,IdentityRoleClaim<string>,IdentityUserToken<string>>
    {
        public PraticaS6L1(DbContextOptions<PraticaS6L1> options): base(options) { }

        public DbSet<Studente> Studenti { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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

            modelBuilder.Entity<ApplicationUserRole>().HasOne(ur => ur.User).WithMany(u => u.ApplicationUserRole).HasForeignKey(ur=> ur.UserId);
            modelBuilder.Entity<ApplicationUserRole>().HasOne(ur => ur.Role).WithMany(u => u.ApplicationUserRole).HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<ApplicationUserRole>().Property(p=>p.Date).HasDefaultValueSql("GETDATE()").IsRequired(true);
        }

    }
}
