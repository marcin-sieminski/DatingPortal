using Microsoft.AspNetCore.Mvc;
using Portal.API.Data;
using Portal.API.Dtos;
using Portal.API.Models;
using System.Threading.Tasks;

namespace Portal.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repository;
        public AuthController(IAuthRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();
            if (await _repository.UserExists(userForRegisterDto.Username))
            {
                return BadRequest("U¿ytkownik o takiej nazwie istnieje.");
            }

            var userToCreate = new User(){Username = userForRegisterDto.Username};
            var createdUser = await _repository.Register(userToCreate, userForRegisterDto.Password);
            return Ok(createdUser);
        }
    }
}