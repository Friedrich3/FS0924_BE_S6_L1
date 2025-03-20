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
            

            modelBuilder.Entity<ApplicationUserRole>().HasOne(ur => ur.User).WithMany(u => u.ApplicationUserRole).HasForeignKey(ur=> ur.UserId);
            modelBuilder.Entity<ApplicationUserRole>().HasOne(ur => ur.Role).WithMany(u => u.ApplicationUserRole).HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<ApplicationUserRole>().Property(p=>p.Date).HasDefaultValueSql("GETDATE()").IsRequired(true);

            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole() { Id = "E47D581A-E477-40DA-AC5D-276F07F59142", Name = "Admin", NormalizedName="ADMIN", ConcurrencyStamp= "E47D581A-E477-40DA-AC5D-276F07F59142" });
            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole() { Id = "EB589A41-5B71-41E7-A754-81764E7CCA23", Name = "Docente", NormalizedName = "DOCENTE", ConcurrencyStamp = "EB589A41-5B71-41E7-A754-81764E7CCA23" });
            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole() { Id = "DB5AE2D5-1966-4885-82BF-05FB79EEDDF5", Name = "Studente", NormalizedName = "STUDENTE", ConcurrencyStamp = "DB5AE2D5-1966-4885-82BF-05FB79EEDDF5" });
        }

    }
}
