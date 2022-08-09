using EducationAPI.Models.Material;

namespace EducationAPI.Services
{
    public interface IMaterialService
    {
        Task<MaterialDTO> CreateMaterialAsync(CreateMaterialDTO createMaterialDTO);
        Task DeleteMaterialAsync(int materialID);
        Task<IEnumerable<MaterialDTO>> GetAllMaterialsAsync(string? searchPhrase, string? direction);
        Task<MaterialDTO> GetMaterialByIDAsync(int materialID);
        Task<MaterialDTO> UpdateMaterialAsync(UpdateMaterialDTO updateMaterialDTO, int materialID);
        Task<MaterialDTO> PutMaterialAsync(PutMaterialsDTO putMaterialsDTO, int materialID);
        Task<IEnumerable<MaterialDTO>> GetMaterialsFromSelectedType(string typeName);
    }
}