using FS0924_BE_S7_L1.Models;
using Microsoft.EntityFrameworkCore;

namespace FS0924_BE_S7_L1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Studente> Studenti { get; set; }

    }
}
