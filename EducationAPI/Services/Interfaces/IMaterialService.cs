﻿using EducationAPI.Models.Material;

namespace EducationAPI.Services
{
    public interface IMaterialService
    {
        Task CreateMaterialAsync(CreateMaterialDTO createMaterialDTO);
        Task DeleteMaterialAsync(int materialID);
        Task<IEnumerable<MaterialDTO>> GetAllMaterialsAsync();
        Task<MaterialDTO> GetMaterialByIDAsync(int materialID);
    }
}