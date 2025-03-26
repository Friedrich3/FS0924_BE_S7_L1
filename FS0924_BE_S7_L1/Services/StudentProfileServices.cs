using FS0924_BE_S7_L1.Data;
using FS0924_BE_S7_L1.DTOs.StudentProfile;
using FS0924_BE_S7_L1.Models;
using Microsoft.EntityFrameworkCore;

namespace FS0924_BE_S7_L1.Services
{
    public class StudentProfileServices
    {
        private readonly ApplicationDbContext _context;
        public StudentProfileServices(ApplicationDbContext context)
        {
            _context = context;
        }
        private async Task<bool> SaveAsync()
        {
            try
            {
                var righe = await _context.SaveChangesAsync();
                if (righe > 0)
                { return true; }
                else { return false; }
            }
            catch { return false; }
        }

        public async Task<bool> CreateProfile( AddStudentProfileDto addstudentProfile, string email)
        {
            try
            {
                var studente = await _context.Studenti.FirstOrDefaultAsync(p=> p.Email == email);
                if (studente == null) {
                    return false;
                }
                var profile = new StudentProfile()
                {
                    FirstName = addstudentProfile.FirstName,
                    LastName = addstudentProfile.LastName,
                    FiscalCode = addstudentProfile.FiscalCode,
                    BirthDate = addstudentProfile.BirthDate,
                    StudentId = studente.Id
                };
                _context.StudentProfiles.Add(profile);
                


                return await SaveAsync();
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
