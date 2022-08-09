using Microsoft.AspNetCore.Mvc;
using EducationAPI.Services;
using EducationAPI.Models.MaterialType;
using EducationAPI.Data.Entities;
using EducationAPI.Models;
using EducationAPI.Data.Exceptions;
using System.Net.Mime;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;

namespace EducationAPI.Controllers
{
    [Route("api/types")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class MaterialTypeController  : ControllerBase
    {
        private readonly IMaterialTypeService _materialTypeService;

        public MaterialTypeController(IMaterialTypeService materialTypeService)
        {
            _materialTypeService = materialTypeService;
        }

        /// <summary>
        /// Get all types of materials
        /// </summary> 
       
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<MaterialTypeDTO>))]
        [Authorize(Roles = "Admin, User")]

        public async Task<ActionResult<IEnumerable<MaterialTypeDTO>>> GetAllMaterialsTypeAsync([FromQuery] string? searchPhrase, string? direction)
        {
            var materialsTypes = await _materialTypeService.GetAllMaterialsTypeAsync(searchPhrase, direction);
            return Ok(materialsTypes);
        }

        /// <summary>
        /// Get a type of materials by id
        /// </summary> 
        [HttpGet("{typeID}")]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(MaterialTypeDTO))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<MaterialTypeDTO>> GetMaterialsTypeAsync([FromRoute] int typeID)
        {
            var materialsType = await _materialTypeService.GetMaterialsTypeByIDAsync(typeID);
            return Ok(materialsType);
        }

    }
}
