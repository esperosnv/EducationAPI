﻿using Microsoft.AspNetCore.Mvc;
using EducationAPI.Services;
using EducationAPI.Models.User;
using EducationAPI.Data.Exceptions;
using EducationAPI.Data.Exceptions;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace EducationAPI.Controllers
{

    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] RegisterUserDTO registerUserDTO)
        {
            _accountService.RegisterNewUser(registerUserDTO);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            string token = await _accountService.GenerateJWT(loginDTO);

            return Ok(token);
        }

    }
}
