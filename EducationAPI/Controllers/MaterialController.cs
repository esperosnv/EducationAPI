﻿using Microsoft.AspNetCore.Mvc;
using EducationAPI.Services;
using EducationAPI.Models.Material;
using EducationAPI.Data.Entities;
using EducationAPI.Models;
using EducationAPI.Data.Exceptions;


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
        public async Task<ActionResult<IEnumerable<MaterialDTO>>> GetAllAuthorsAsync([FromQuery] string? searchPhrase, string? direction)
        {
            if (direction != null && direction != "ASC" && direction != "DESC") throw new ResourceNotFoundException("Not correct direction");
            var materials = await _materialService.GetAllMaterialsAsync(searchPhrase, direction);
            return Ok(materials);
        }


        /// <summary>
        /// Get a material by id
        /// </summary> 
        [HttpGet("{materialID}")]
        public async Task<ActionResult<MaterialDTO>> GetMaterialAsync([FromRoute] int materialID)
        {
            var material = await _materialService.GetMaterialByIDAsync(materialID);
            return Ok(material);
        }

        /// <summary>
        /// Add new author 
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> CreateMaterialAsync([FromBody] CreateMaterialDTO createMaterialDTO)
        {
            await _materialService.CreateMaterialAsync(createMaterialDTO);
            return Ok();
        }

        /// <summary>
        /// Delete a material by id
        /// </summary> 
        [HttpDelete("{materialID}")]
        public async Task<ActionResult> DeleteMaterialAsync([FromRoute] int materialID)
        {
            await _materialService.DeleteMaterialAsync(materialID);
            return NoContent();
        }


        /// <summary>
        /// Update a material by id
        /// </summary> 
        [HttpPatch("{materialID}")]
        public async Task<ActionResult> UpdateMaterialAsync([FromBody] UpdateMaterialDTO updateMaterialDTO, [FromRoute] int materialID)
        {
            await _materialService.UpdateMaterialAsync(updateMaterialDTO, materialID);
            return Ok();
        }

    }
}
