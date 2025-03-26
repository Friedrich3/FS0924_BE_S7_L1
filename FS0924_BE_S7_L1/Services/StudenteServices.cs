using FS0924_BE_S7_L1.Data;
using FS0924_BE_S7_L1.DTOs.Studente;
using FS0924_BE_S7_L1.DTOs.StudentProfile;
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

        public async Task<bool> AddNew(AddStudentRequestDto studente)
        {
            try
            {
                var newstudent = new Studente()
                {
                    Nome = studente.Nome,
                    Cognome = studente.Cognome,
                    Email = studente.Email,

                };
                _context.Studenti.Add(newstudent);
                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }

        public async Task<ListUpdateStudenteDto?> GetAll()
        {
            try
            {
                var lista = new ListUpdateStudenteDto() {ListaStudenti = new List<UpdateStudenteRequestDto>() };
                var list = await _context.Studenti.Include(p=> p.StudenteProfile).ToListAsync();
                foreach (var item in list) 
                {
                    var studente = new UpdateStudenteRequestDto()
                    {
                        Nome = item.Nome,
                        Cognome = item.Cognome,
                        Email = item.Email,
                        StudentProfile = item.StudenteProfile!= null ? new AddStudentProfileDto()
                        {
                            FirstName = item.StudenteProfile.FirstName,
                            LastName = item.StudenteProfile.LastName,
                            FiscalCode = item.StudenteProfile.FiscalCode,
                            BirthDate = item.StudenteProfile.BirthDate

                        }: null,
                    };
                    lista.ListaStudenti.Add(studente);
                }
                return lista;
            }
            catch
            {
               return null;
            }
        }

        public async Task<ByEmailStudentResponseDto?> FindByEmail(string email) {
            try
            {
                var result = await _context.Studenti.FirstOrDefaultAsync(p => p.Email == email);
                if (result == null) {  return null; }
                var studente = new ByEmailStudentResponseDto() 
                { 
                    Nome= result.Nome,
                    Cognome= result.Cognome,
                    Email= result.Email,
                };
                return studente;
            }
            catch
            {
                return null;
            }
        }

      public async Task<bool> PutStudente(string email, UpdateStudenteRequestDto updateStudent)
        {
            try
            {
                var toUpdateStudent = await _context.Studenti.FirstOrDefaultAsync(p => p.Email == email);
                if (toUpdateStudent == null)
                {
                    return false;
                }
                toUpdateStudent.Nome = updateStudent.Nome;
                toUpdateStudent.Cognome = updateStudent.Cognome;
                toUpdateStudent.Email = updateStudent.Email;
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteStudente (string email)
        {
            try
            {
                var studente = await _context.Studenti.FirstOrDefaultAsync(p => p.Email == email);
                if(studente == null)
                {
                    return false;
                }
                _context.Studenti.Remove(studente);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                return false;
            }
        }



    }
}
