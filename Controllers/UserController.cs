using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasswordHashing.DTOs;
using PasswordHashing.Services;
using System.ComponentModel.DataAnnotations;

namespace PasswordHashing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult AddUser(UserDTO userDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(" ; ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }
            var userId = _userService.Add(userDto);
            return Ok(userId);
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDTO loginDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(" ; ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }

            var isLoginSuccessful = _userService.CheckPassword(loginDto);
            return isLoginSuccessful ? Ok("Login Successful") : BadRequest("Invalid Credentials");
        }
    }
}
