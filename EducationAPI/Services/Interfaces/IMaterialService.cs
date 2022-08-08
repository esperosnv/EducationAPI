using EducationAPI.Models.Material;

namespace EducationAPI.Services
{
    public interface IMaterialService
    {
        Task CreateMaterialAsync(CreateMaterialDTO createMaterialDTO);
        Task DeleteMaterialAsync(int materialID);
        Task<IEnumerable<MaterialDTO>> GetAllMaterialsAsync(string searchPhrase);
        Task<MaterialDTO> GetMaterialByIDAsync(int materialID);
        Task UpdateMaterialAsync(UpdateMaterialDTO updateMaterialDTO, int materialID);
    }
}