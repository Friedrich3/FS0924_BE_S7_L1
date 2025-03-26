using FS0924_BE_S7_L1.DTOs.StudentProfile;
using FS0924_BE_S7_L1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FS0924_BE_S7_L1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentProfileController : ControllerBase
    {
        private readonly StudentProfileServices _studentProfileServices;
        public StudentProfileController(StudentProfileServices studentProfileServices)
        {
            _studentProfileServices = studentProfileServices;
        }

        [HttpPost("/newprofile")]
        public async Task<IActionResult> AddProfile ([FromQuery]string email, [FromBody]AddStudentProfileDto addStudentProfileDto)
        {
            var result= await _studentProfileServices.CreateProfile(addStudentProfileDto, email);

            if (!result)
            {
                return BadRequest(new { message = "Ops,qualcosa e' andato storto durante la creazione" });
            }
            return Ok(new {message="Profilo Studente creato con successo"});
            
        }


    }
}
    