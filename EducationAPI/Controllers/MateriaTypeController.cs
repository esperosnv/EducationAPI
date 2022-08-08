using Microsoft.AspNetCore.Mvc;
using EducationAPI.Services;
using EducationAPI.Models.MaterialType;
using EducationAPI.Data.Entities;

namespace EducationAPI.Controllers
{
    [Route("api/type")]
    [ApiController]
    public class MateriaTypeController  : ControllerBase
    {
        private readonly IMaterialTypeService _materialTypeService;

        public MateriaTypeController(IMaterialTypeService materialTypeService)
        {
            _materialTypeService = materialTypeService;
        }

        /// <summary>
        /// Get all type of materials
        /// </summary> 
       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialTypeDTO>>> GetAllMaterialsTypeAsync()
        {
            var materialsType = await _materialTypeService.GetAllMaterialsTypeAsync();
            return Ok(materialsType);
        }

    }
}
