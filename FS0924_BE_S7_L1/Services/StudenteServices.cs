using FS0924_BE_S7_L1.Data;
using FS0924_BE_S7_L1.Models;
using Microsoft.EntityFrameworkCore;

namespace FS0924_BE_S7_L1.Services
{
    public class StudenteServices
    {
        private readonly ApplicationDbContext _context;
        public StudenteServices(ApplicationDbContext context)
        {
            _context = context;
        }

        private async Task<bool> SaveAsync()
        {
            try {
                var righe = await _context.SaveChangesAsync();
                if (righe > 0)
                { return true; } else { return false; }
            } catch { return false; }
        }

        public async Task<bool> AddNew(Studente studente)
        {
            try
            {
                _context.Studenti.Add(studente);
                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Studente>?> GetAll()
        {
            try
            {
                var list = await _context.Studenti.ToListAsync();
                return list;
            }
            catch
            {
               return null;
            }

        }


    }
}
