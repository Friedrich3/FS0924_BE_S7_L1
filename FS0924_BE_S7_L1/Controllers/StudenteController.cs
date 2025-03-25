using FS0924_BE_S7_L1.DTOs.Studente;
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
            if (ListStudenti.ListaStudenti == null)
            {
                return BadRequest(new
                {
                    message = "Bad Request"
                });
            }
            else if (!ListStudenti.ListaStudenti.Any())
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
        public async Task<IActionResult> AddStudent([FromBody] AddStudentRequestDto studente)
        {

            var result = await _studenteServices.AddNew(studente);

            if (!result)
            {
                return BadRequest(new
                {
                    message = "Ops qualcosa e' andato storto :( "
                });
            }
            return Ok(new
            {
                message = "Studente creato con successo!"
            });
        }

        [HttpGet("/byEmail")]
        public async Task<IActionResult> TrovaPerEmail([FromQuery] string email)
        {
            var result = await _studenteServices.FindByEmail(email);

            if(result == null)
            {
                return BadRequest(new
                {
                    message = "Ops qualcosa e' andato storto"
                });
            }
            return Ok(new {
                message = "Studente trovato con successo!" ,
                studente = result
            }); 
        }

        [HttpPut("/update")]
        public async Task<IActionResult> UpdateStudente([FromQuery] string email, [FromBody] UpdateStudenteRequestDto updateStudent)
        {
            var result = await _studenteServices.PutStudente(email , updateStudent);

            if (!result)
            {
                return BadRequest(new
                {
                    message = "Ops qualcosa e' andato storto"
                });
            }
            return Ok(new
            {
                message = "Studente aggiornato con successo"
            });
        }


        [HttpDelete("/delete")]
        public async Task<IActionResult> DeleteStudent([FromQuery] string email)
        {
            var result = await _studenteServices.DeleteStudente(email);
            if (!result)
            {
                return BadRequest(new
                {
                    message = "Qualcosa e' andato storto durante l'eliminazione"
                });
            }
            return Ok(new
            {
                message = "Studente rimosso con successo"
            });
        }

    }
}
