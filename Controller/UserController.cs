using AuthorizationMicroservice.DTO;
using AuthorizationMicroservice.Service;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AuthorizationMicroservice.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(
            [FromBody] IdentityDto request)
        {
            await _userService.Registry(request);
            return Ok();
        }
        public record LoginUserRequest([Required]string Email,
            [Required]string Password);

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            [FromBody] LoginUserRequest request)
        {
            var token = await _userService.Login(request.Email,
                request.Password);
            return Ok(token);
        }
    }
}
