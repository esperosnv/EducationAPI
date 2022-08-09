using Microsoft.AspNetCore.Mvc;
using EducationAPI.Services;
using EducationAPI.Models.User;
using Swashbuckle.AspNetCore.Annotations;
using EducationAPI.Data.Entities;
using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// Register a new user
        /// </summary> 
        [HttpPost("register")]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status201Created)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterUserDTO registerUserDTO)
        {
            await _accountService.RegisterNewUser(registerUserDTO, Role.User);
            return Ok();
        }

        /// <summary>
        /// Register a new admin by existing admin
        /// </summary>
        [HttpPost("register/admin")]
        [Authorize(Roles = "Admin")]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status201Created)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> RegisterAdmin([FromBody] RegisterUserDTO registerUserDTO)
        {
            await _accountService.RegisterNewUser(registerUserDTO, Role.Admin);
            return Ok();
        }
        /// <summary>
        /// Login user and admin
        /// </summary>
        [HttpPost("login")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Text.Plain)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            string token = await _accountService.GenerateJWT(loginDTO);
            return Ok(token);
        }

    }
}
