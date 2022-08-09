using Microsoft.AspNetCore.Mvc;
using EducationAPI.Services;
using EducationAPI.Models.Material;
using System.Net.Mime;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;

namespace EducationAPI.Controllers
{
    [Route("api/materials")]
    [ApiController]

    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _materialService;
        public MaterialController(IMaterialService materialServic)
        {
            _materialService = materialServic;
        }

        /// <summary>
        /// Get all materials
        /// </summary> 

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<MaterialDTO>))]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<IEnumerable<MaterialDTO>>> GetAllAuthorsAsync([FromQuery] string? searchPhrase, string? direction)
        {
            var materials = await _materialService.GetAllMaterialsAsync(searchPhrase, direction);
            return Ok(materials);
        }

        /// <summary>
        /// Get a material by id
        /// </summary> 
        [HttpGet("{materialID}")]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(MaterialDTO))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<MaterialDTO>> GetMaterialAsync([FromRoute] int materialID)
        {
            var material = await _materialService.GetMaterialByIDAsync(materialID);
            return Ok(material);
        }

        /// <summary>
        /// Add new author 
        /// </summary>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(MaterialDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> CreateMaterialAsync([FromBody] CreateMaterialDTO createMaterialDTO)
        {
            var newMaterialDTO = await _materialService.CreateMaterialAsync(createMaterialDTO);
            return Created($"{Request.Scheme}://{Request.Host}{Request.Path}/{newMaterialDTO.MaterialID}", newMaterialDTO);
        }

        /// <summary>
        /// Update all fields of material by id
        /// </summary> 
        [HttpPut("{materialID}")]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(MaterialDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> PutMaterialAsync([FromBody] PutMaterialsDTO putMaterialsDTO, [FromRoute] int materialID)
        {
            var updateMaterial = await _materialService.PutMaterialAsync(putMaterialsDTO, materialID);
            return Ok(updateMaterial);
        }


        /// <summary>
        /// Delete a material by id
        /// </summary> 
        [HttpDelete("{materialID}")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteMaterialAsync([FromRoute] int materialID)
        {
            await _materialService.DeleteMaterialAsync(materialID);
            return NoContent();
        }


        /// <summary>
        /// Update a material by id
        /// </summary> 
        [HttpPatch("{materialID}")]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(MaterialDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateMaterialAsync([FromBody] UpdateMaterialDTO updateMaterialDTO, [FromRoute] int materialID)
        {
            var updateMaterial = await _materialService.UpdateMaterialAsync(updateMaterialDTO, materialID);
            return Ok(updateMaterial);
        }

        /// <summary>
        /// Get materials by selected type
        /// </summary> 
        [HttpGet("type/{typeName}")]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<MaterialDTO>))]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<MaterialDTO>>> GetMaterialsByType([FromRoute] string typeName)
        {
            var materials = await _materialService.GetMaterialsFromSelectedType(typeName);
            return Ok(materials);
        }


    }
}
