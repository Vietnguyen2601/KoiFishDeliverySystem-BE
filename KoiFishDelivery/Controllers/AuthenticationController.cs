using Microsoft.AspNetCore.Mvc;
using KoiFishDelivery.Models;
using KoiFishDelivery.Services;

namespace KoiFishDelivery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly JwtService _jwtService;
        public AuthenticationController(IAuthenticationService authenticationService, JwtService jwtService)
        {
            _authenticationService = authenticationService;
            _jwtService = jwtService;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _authenticationService.ValidateLogin(request);
            if (user == null)
            {
                return Unauthorized(new { message = "Email hoặc mật khẩu không đúng!" });
            }
            var token = _jwtService.GenerateToken(user);
            return Ok(new
            {
                message = "Đăng nhập thành công!",
                token,
                user = new
                {
                    user.UserId,
                    user.FullName,
                    user.Email,
                    user.Role
                }
            });
        }
    }
}
