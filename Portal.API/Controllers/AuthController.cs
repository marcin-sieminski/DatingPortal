using Microsoft.AspNetCore.Mvc;
using Portal.API.Data;
using Portal.API.Models;
using System.Threading.Tasks;

namespace Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repository;
        public AuthController(IAuthRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password)
        {
            username = username.ToLower();
            if (await _repository.UserExists(username))
            {
                return BadRequest("U¿ytkownik o takiej nazwie istnieje.");
            }

            var userToCreate = new User(){Username = username};
            var createdUser = await _repository.Register(userToCreate, password);
            return StatusCode(201);
        }
    }
}