using DPA.Store.DOMAIN.Core.Entities;
using DPA.Store.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DPA.Store.API.Controllers
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

        [HttpGet("GetAll")]
        
        public async Task<IActionResult> GetAll()
        {
            var user = await _userRepository.GetAll();
            return Ok(user);
        }

        [HttpPost("CrearUsuario")]

        public async Task<IActionResult> Create(User user)
        {
            var result = await _userRepository.Insert(user);
            return Ok(result);
        }

        [HttpDelete("Eliminar Usuario/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userRepository.Delete(id);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
