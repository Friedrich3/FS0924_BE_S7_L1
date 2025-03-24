using FS0924_BE_S7_L1.Models;
using FS0924_BE_S7_L1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FS0924_BE_S7_L1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudenteController : ControllerBase
    {
        private readonly StudenteServices _studenteServices;
        public StudenteController(StudenteServices studenteServices)
        {
            _studenteServices = studenteServices;
        }


        [HttpGet("/all")]
        public async Task<IActionResult> GetAllStudents()
        {
            var ListStudenti = await _studenteServices.GetAll();
            if (ListStudenti == null)
            {
                return BadRequest(new
                {
                    message = "BadRequest"
                });
            }
            else if (!ListStudenti.Any())
            {
                return NotFound(new
                {
                    message = "Nessuno Studente trovato"
                });
            }
            return Ok(new
            {
                message = "Lista trovata con successo",
                studenti = ListStudenti
            });

        }

        [HttpPost("/add")] 
        public async Task<IActionResult> AddStudent([FromBody] Studente studente)
        {
            var result = await _studenteServices.AddNew(studente);

            if (!result)
            {
                return BadRequest(new
                {
                    message = "Qualcosa e' andato storto!"
                });
            }
            return Ok(new
            {
                message = "Studente creato con successo!"
            });

        }




    }
}
