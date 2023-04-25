using Core.Dtos;
using Core.Services;
using DataLayer.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class UserController : ControllerBase
    {
        private UserService userService { get; set; }

        public UserController(UserService userService)
        {
            this.userService = userService;
        }
        [HttpPost("/register")]
        [AllowAnonymous]
        public IActionResult Register(RegisterDto payload)
        {
            userService.Register(payload);
            return Ok();
        }

        [HttpPost("/login")]
        [AllowAnonymous]
        public IActionResult Login(LoginDto payload)
        {
            var jwtToken = userService.ValidateLogin(payload);

            return Ok(new { token = jwtToken });
        }
        [HttpGet("/some")]
        [Authorize(Roles = "Professor")]
        public ActionResult<string> Some()
        {
            return Ok("SALUT");
        }
    }
}
