using Core.Services;
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
    }
}
