using FS0924_BE_S7_L1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FS0924_BE_S7_L1.Models.Auth;
using Microsoft.AspNetCore.Identity;

namespace FS0924_BE_S7_L1.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string> >
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }

        public DbSet<Studente> Studenti { get; set; }
        public DbSet<StudentProfile> StudentProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUserRole>().HasOne(p=> p.User).WithMany(p=> p.ApplicationUserRole).HasForeignKey(p=>p.UserId);
            modelBuilder.Entity<ApplicationUserRole>().HasOne(p=> p.Role).WithMany(p=> p.ApplicationUserRole).HasForeignKey(p=>p.RoleId);
            modelBuilder.Entity<ApplicationUserRole>().Property(p => p.Date).HasDefaultValueSql("GETDATE()").IsRequired(true);

            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole() { Id = "14650285-4BD6-4009-8836-B1C61090F1E2", Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "14650285-4BD6-4009-8836-B1C61090F1E2" });
            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole() { Id = "7065CF28-3402-4751-8B37-406D2DE5214B", Name = "User", NormalizedName = "USER", ConcurrencyStamp = "7065CF28-3402-4751-8B37-406D2DE5214B" });


            modelBuilder.Entity<StudentProfile>().HasOne(p => p.Student).WithOne(p => p.StudenteProfile).HasForeignKey<StudentProfile>(p => p.StudentId);

            modelBuilder.Entity<Studente>().HasIndex(p => p.Email).IsUnique();
        }

    }
}
