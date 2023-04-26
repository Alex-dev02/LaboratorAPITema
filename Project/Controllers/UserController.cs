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
        private StudentService studentService { get; set; }

        public UserController(UserService userService, StudentService student)
        {
            this.userService = userService;
            this.studentService = studentService;
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

        [HttpGet("/get-all-students-grades")]
        [Authorize(Roles = "Professor")]
        public ActionResult<List<GradeDto>> GetAllStudentsGrades()
        {
            return Ok(studentService.GetAllStudentsGrades());
        }

        [HttpGet("/get-all-grades-by-student-id")]
        [Authorize(Roles = "Professor")]
        public ActionResult<List<GradeDto>> GetAllGradesByStudentId(int studentId)
        {
            return Ok(studentService.GetAllGrades(studentId));
        }

        [HttpGet("/some")]
        [Authorize(Roles = "Professor")]
        public ActionResult<string> Some()
        {
            return Ok("SALUT");
        }
    }
}
