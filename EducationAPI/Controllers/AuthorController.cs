using Microsoft.AspNetCore.Mvc;
using EducationAPI.Services;
using EducationAPI.Models.Author;
using EducationAPI.Data.Exceptions;
using EducationAPI.Data.Exceptions;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;

namespace EducationAPI.Controllers
{
    [Route("api/authors")]
    [ApiController]
    [Authorize(Roles = "Admin")]
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
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<AuthorDTO>))]

        public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAllAuthorsAsync([FromQuery] string? searchPhrase, string? direction)
        {
            var authors = await _authorService.GetAllAuthorsAsync(searchPhrase, direction);
            return Ok(authors);
        }

        /// <summary>
        /// Get an author by id
        /// </summary> 
        [HttpGet("{authorID}")]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(AuthorDTO))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<AuthorDTO>> GetAuthorAsync([FromRoute] int authorID)
        {
            var author = await _authorService.GetAuthorByIDAsync(authorID);
            return Ok(author);
        }

        /// <summary>
        /// Add new author 
        /// </summary>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(AuthorDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> CreateAuthorAsync([FromBody] CreateAuthorDTO createAuthorDTO)
        {
            var newAuthorDTO = await _authorService.CreateAuthorAsync(createAuthorDTO);
            return Created($"{Request.Scheme}://{Request.Host}{Request.Path}/{newAuthorDTO.AuthorID}", newAuthorDTO);
        }


        /// <summary>
        /// Update all fields of author by id
        /// </summary> 
        [HttpPut("{authorID}")]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(AuthorDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PutAuthorAsync([FromBody] PutAuthorDTO putAuthorDTO, [FromRoute] int authorID)
        {
            var updateAuthor = await _authorService.PutAuthorAsync(putAuthorDTO, authorID);
            return Ok(updateAuthor);
        }



        /// <summary>
        /// Delete an author by id
        /// </summary> 
        [HttpDelete("{authorID}")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> DeleteAuthorAsync([FromRoute] int authorID)
        {
            await _authorService.DeleteAuthorAsync(authorID);
            return NoContent();
        }


        /// <summary>
        /// Update an author by id
        /// </summary> 
        [HttpPatch("{authorID}")]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(AuthorDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> UpdateAuthorAsync([FromBody] UpdateAuthorDTO updateAuthorDTO, [FromRoute] int authorID)
        {
            var updateAuthor = await _authorService.UpdateAuthorAsync(updateAuthorDTO, authorID);
            return Ok(updateAuthor);
        }

    }
}
