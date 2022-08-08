﻿using Microsoft.AspNetCore.Mvc;
using EducationAPI.Services;
using EducationAPI.Models.MaterialType;
using EducationAPI.Data.Entities;

namespace EducationAPI.Controllers
{
    [Route("api/type")]
    [ApiController]
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
        public async Task<ActionResult<IEnumerable<MaterialTypeDTO>>> GetAllMaterialsTypeAsync()
        {
            var materialsTypes = await _materialTypeService.GetAllMaterialsTypeAsync();
            return Ok(materialsTypes);
        }

        /// <summary>
        /// Get a type of materials by id
        /// </summary> 
        [HttpGet("{typeID}")]
        public async Task<ActionResult<MaterialTypeDTO>> GetMaterialsTypeAsync([FromRoute] int typeID)
        {
            var materialsType = await _materialTypeService.GetMaterialsTypeByIDAsync(typeID);
            return Ok(materialsType);
        }

    }
}