using FS0924_BE_S7_L1.Models;
using Microsoft.EntityFrameworkCore;

namespace FS0924_BE_S7_L1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Studente> Studenti { get; set; }
        public DbSet<StudentProfile> StudentProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentProfile>().HasOne(p => p.Student).WithOne(p => p.StudenteProfile).HasForeignKey<StudentProfile>(p => p.StudentId);

            modelBuilder.Entity<Studente>().HasIndex(p => p.Email).IsUnique();
        }

    }
}
