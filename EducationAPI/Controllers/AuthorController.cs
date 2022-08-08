using Microsoft.AspNetCore.Mvc;
using EducationAPI.Services;
using EducationAPI.Models.Author;

namespace EducationAPI.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        /// <summary>
        /// Get all authors
        /// </summary> 

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAllAuthorsAsync()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            return Ok(authors);
        }

    }
}
