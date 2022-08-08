using EducationAPI.Models.MaterialType;
using EducationAPI.Data.Entities;

namespace EducationAPI.Services
{
    public interface IMaterialTypeService
    {
        Task<IEnumerable<MaterialTypeDTO>> GetAllMaterialsTypeAsync(string searchPhrase);
        Task<MaterialTypeDTO> GetMaterialsTypeByIDAsync(int typeID);
    }
}