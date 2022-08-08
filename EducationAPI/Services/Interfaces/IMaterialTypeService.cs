using EducationAPI.Models.MaterialType;
using EducationAPI.Models;
using EducationAPI.Data.Entities;


namespace EducationAPI.Services
{
    public interface IMaterialTypeService
    {
        Task<IEnumerable<MaterialTypeDTO>> GetAllMaterialsTypeAsync(string? searchPhrase, string? direction);
        Task<MaterialTypeDTO> GetMaterialsTypeByIDAsync(int typeID);
    }
}