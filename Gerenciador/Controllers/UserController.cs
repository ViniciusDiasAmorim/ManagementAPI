using Gerenciador.Models;
using Gerenciador.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var users = await _userRepository.GetAll();
            
            return Ok(users); 
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var user = await _userRepository.GetById(id);
            
            if(user == null)
            {
                return NotFound("User not found.");
            }

            return Ok(user);
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("search/{queryString}")]
        public async Task<ActionResult> GetByName(string queryString)
        {
            var users = await _userRepository.GetByName(queryString.ToLower());

            if (users == null)
            {
                return NotFound("User not found.");
            }

            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] User user)
        {
            if(user == null)
            {
                return BadRequest("The user is null");
            }

            var newUser = await _userRepository.Post(user);

            return Ok(newUser);
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] User user)
        {
            var userChange = await _userRepository.Put(id, user);

            if(userChange == null)
            {
                return BadRequest("User not found or past values are invalid.");
            }

            return Ok(userChange);
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deletedUser = await _userRepository.Delete(id);
            if(deletedUser == null)
            {
                return NotFound("User not found.");
            }

            return Ok(deletedUser);
        }
    }
}
