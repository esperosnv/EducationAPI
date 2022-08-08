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
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAllAuthorsAsync([FromQuery] string? searchPhrase)
        {
            var authors = await _authorService.GetAllAuthorsAsync(searchPhrase);
            return Ok(authors);
        }

        /// <summary>
        /// Get an author by id
        /// </summary> 
        [HttpGet("{authorID}")]
        public async Task<ActionResult<AuthorDTO>> GetAuthorAsync([FromRoute] int authorID)
        {
            var author = await _authorService.GetAuthorByIDAsync(authorID);
            return Ok(author);
        }

        /// <summary>
        /// Add new author 
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> CreateAuthorAsync([FromBody] CreateAuthorDTO createAuthorDTO)
        {
            await _authorService.CreateAuthorAsync(createAuthorDTO);
            return Ok();
        }


        /// <summary>
        /// Delete an author by id
        /// </summary> 
        [HttpDelete("{authorID}")]
        public async Task<ActionResult> DeleteAuthorAsync([FromRoute] int authorID)
        {
            await _authorService.DeleteAuthorAsync(authorID);
            return NoContent();
        }


        /// <summary>
        /// Update an author by id
        /// </summary> 
        [HttpPatch("{authorID}")]

        public async Task<ActionResult> UpdateAuthorAsync([FromBody] UpdateAuthorDTO updateAuthorDTO, [FromRoute] int authorID)
        {
            await _authorService.UpdateAuthorAsync(updateAuthorDTO, authorID);
            return Ok();
        }

    }
}
