using EstudoAPI.Models;
using EstudoAPI.Service.JwtService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstudoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AutheticationController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public AutheticationController(ITokenService tokenService, IConfiguration configuration)
        {
            _tokenService = tokenService;
            _configuration = configuration;
        }

        [HttpPost("/login")]
        public ActionResult Login(UserModel userModel)
        {
            if (userModel == null)
            {
                return BadRequest("Usuario Inválio");
            }

            if (userModel.Username == "pedro" && userModel.Password == "pedro123")
            {
                var tokenString = _tokenService.GetToken(_configuration["Jwt:Key"],
                                                         _configuration["Jwt:Issuer"], 
                                                         _configuration["Jwt:Assuer"], 
                                                         userModel);
                return Ok(new { tokenString });
            }
            else
            {
                return BadRequest("Usuario invalido");
            }
        }
    }
}
