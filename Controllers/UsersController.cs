using Microsoft.AspNetCore.Mvc;
using KoiFishDeliverySystem.Models;
using KoiFishDeliverySystem.Services;
using System.Threading.Tasks;
using KoiFishDeliverySystem.Services.Interfaces;

namespace KoiFishDeliverySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                var users = await _usersService.GetAllAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(string id)
        {
            try
            {
                var user = await _usersService.GetByIdAsync(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                if (ex.Message == "User not found")
                {
                    return NotFound();
                }
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] User user)
        {
            try
            {
                var createdUser = await _usersService.CreateAsync(user);
                return CreatedAtAction(nameof(GetUser), new { id = createdUser.UserId }, createdUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(string id, [FromBody] User user)
        {
            try
            {
                await _usersService.UpdateAsync(id, user);
                return NoContent();
            }
            catch (Exception ex)
            {
                if (ex.Message == "User not found" || ex.Message == "ID mismatch")
                {
                    return BadRequest(ex.Message);
                }
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            try
            {
                await _usersService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                if (ex.Message == "User not found")
                {
                    return NotFound();
                }
                return StatusCode(500, ex.Message);
            }
        }
    }
}
