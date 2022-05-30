using DevFreela.API.Models;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }

        // api/users/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // api/users
        [HttpPost]
        public IActionResult Post([FromBody] NewUserInputModel inputModel)
        {
            var userId = _userService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = userId }, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateUserInputModel inputModel)
        {
            _userService.Update(inputModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);

            return NoContent();
        }

        // api/users/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            return Ok();
        }
    }
}
