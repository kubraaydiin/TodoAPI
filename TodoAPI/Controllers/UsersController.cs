using Azure.Messaging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Text;
using TodoAPI.Business.Operations;
using TodoAPI.Data.Entities;
using TodoAPI.Model;
using TodoAPI.Utils;

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserOperations _userOperations;
        private readonly IConfiguration _configuration;
        public UsersController(IUserOperations userOperations, IConfiguration configuration)
        {
            _userOperations = userOperations;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterModel registerModel)
        {
            var passwordErrorMessage = Helper.CheckPassword(registerModel.Password);
            if (!string.IsNullOrEmpty(passwordErrorMessage))
            {
                return BadRequest(passwordErrorMessage);
            }
            var hashedPassw = Helper.Hash(registerModel.Password);

            var isExistEmail = _userOperations.IsExistEmail(registerModel.Email);
            if (isExistEmail)
            {
                return Conflict();
            }

            var userItem = new Users
            {
                Name = registerModel.Name,
                Department = registerModel.Department,
                Email = registerModel.Email,
                Password = hashedPassw
            };

            _userOperations.AddUser(userItem);
            return StatusCode(201);
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginModel loginModel)
        {
            var userItem = new Users
            {
                Email = loginModel.Email,
                Password = loginModel.Password
            };

            var user = _userOperations.GetUserByEmail(userItem.Email);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            if (user.Password != Helper.Hash(loginModel.Password))
            {
                return BadRequest("User not found");
            }

            var secretKey = Encoding.ASCII.GetBytes(_configuration.GetSection("Appsettings:Token").Value);
            var token = Helper.CreateToken(secretKey, user);

            return Ok(token);
        }
    }
}