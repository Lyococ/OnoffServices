using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Onoff.Dto;
using Onoff.Services;

namespace Onoff.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtService _jwtService;

        public AuthController(UserManager<IdentityUser> userManager, JwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var token = _jwtService.GenerateToken(user);
                return Ok(new { token });
            }

            return Unauthorized("Credenciales inválidas");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok("Usuario creado correctamente");
            }

            return BadRequest(result.Errors);
        }
    }
}

