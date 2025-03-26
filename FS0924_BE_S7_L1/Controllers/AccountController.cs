using FS0924_BE_S7_L1.DTOs.Account;
using FS0924_BE_S7_L1.Models.Auth;
using FS0924_BE_S7_L1.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


namespace FS0924_BE_S7_L1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly Jwt _jwtSettings;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AccountController(IOptions<Jwt> jwtSettings, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _jwtSettings = jwtSettings.Value;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }


        [HttpPost("/[controller]/register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequest)
        {

            if (registerRequest == null)
            {
                return BadRequest(new
                {
                    message = "Ops qualcosa e' andato storto"
                });
            }
            var newUser = new ApplicationUser()
            {
                Email = registerRequest.Email,
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName,
                UserName = registerRequest.Email
            };
            var result = await _userManager.CreateAsync(newUser, registerRequest.Password);
            if (!result.Succeeded) 
                {
                    return BadRequest(new
                    {
                        message = "Ops qualcosa e' andato storto"
                    });
                }
            var user = await _userManager.FindByEmailAsync(newUser.Email);
                if (user == null) 
                {
                    return BadRequest(new
                    {
                        message = "Ops qualcosa e' andato storto"
                    });
                }
            await _userManager.AddToRoleAsync(user, "Admin");
            return Ok(new
            {
                message = "Utente Registrato Correttamente"
            });

        }



    }
}
