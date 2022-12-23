using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskApi.Models;
using TaskApi.Repositories.Interfaces;

namespace TaskApi.Controllers
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

        [HttpGet]
        public async Task<ActionResult<List<User>>> FindAllUsers()
        {
           List<User> users = await _userRepository.FindAllUsers();
           return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> FindUserById(int id)
        {
            User user = await _userRepository.FindUserById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser([FromBody] User user)
        {
            User newUser = await _userRepository.AddUser(user);
            return Ok(newUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser([FromBody] User user, int id)
        {
            User updatedUser = await _userRepository.UpdateUser(user, id);
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteUser(int id)
        {
            bool isDeleted = await _userRepository.DeleteUser(id);
            return Ok(isDeleted);
        }
    }
}
