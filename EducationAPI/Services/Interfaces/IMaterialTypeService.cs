using EducationAPI.Models.MaterialType;
using EducationAPI.Data.Entities;

namespace EducationAPI.Services
{
    public interface IMaterialTypeService
    {
        Task<IEnumerable<MaterialTypeDTO>> GetAllMaterialsTypeAsync();
    }
}