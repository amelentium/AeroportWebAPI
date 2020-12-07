using Microsoft.AspNetCore.Mvc;
using SkillAppAdoDapperWebApi.BLL.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillAppAdoDapperWebApi.WEBAPI.Controllers
{
    public class UserController : ControllerBase
    {
        protected readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("/AccountsList")]
        public async Task<IActionResult> GetUsersList()
        {
            var result = await _userService.GetUsersList();
            return Ok(result);
        }

        [HttpPost("/Registration")]
        public async Task<IActionResult> UserRegistration(string UserEmail, string UserPassword)
        {
            if (await _userService.RegisterUser(UserEmail, UserPassword))

                return Ok("The user was successfully registered");
            else return BadRequest("Invalid values entered or user with the same phone number already exists");
        }

        [HttpPost("/GetToken")]
        public async Task<IActionResult> GetUserToken(string UserEmail, string UserPassword)
        {
            var result = await _userService.GetToken(UserEmail, UserPassword);

            if (string.IsNullOrEmpty(result))
                return BadRequest("Invalid values entered");
            else return Ok(result);

        }
    }
}
