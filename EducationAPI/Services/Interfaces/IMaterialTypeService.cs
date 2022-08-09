using EducationAPI.Models.MaterialType;

namespace EducationAPI.Services
{
    public interface IMaterialTypeService
    {
        Task<IEnumerable<MaterialTypeDTO>> GetAllMaterialsTypeAsync();
        Task<MaterialTypeDTO> GetMaterialsTypeByIDAsync(int typeID);
    }
}