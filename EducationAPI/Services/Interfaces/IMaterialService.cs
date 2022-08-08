using EducationAPI.Models.Material;
using EducationAPI.Models;
using EducationAPI.Data.Entities;



namespace EducationAPI.Services
{
    public interface IMaterialService
    {
        Task CreateMaterialAsync(CreateMaterialDTO createMaterialDTO);
        Task DeleteMaterialAsync(int materialID);
        Task<IEnumerable<MaterialDTO>> GetAllMaterialsAsync(string? searchPhrase, string? direction);
        Task<MaterialDTO> GetMaterialByIDAsync(int materialID);
        Task UpdateMaterialAsync(UpdateMaterialDTO updateMaterialDTO, int materialID);
    }
}