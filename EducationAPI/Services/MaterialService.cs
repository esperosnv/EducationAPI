using AutoMapper;
using EducationAPI.Data.DAL.Interfaces;
using EducationAPI.Data.Entities;
using EducationAPI.Models.Material;
using EducationAPI.Data.Exceptions;
using EducationAPI.Models.Author;
using EducationAPI.Data.Entities;

namespace EducationAPI.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Material> _materialRepository;
        private readonly IBaseRepository<MaterialType> _materialTypeRepository;
        private readonly IBaseRepository<Author> _authorRepository;


        public MaterialService(IMapper mapper, IBaseRepository<Material> materialRepository, IBaseRepository<MaterialType> materialTypeRepository, IBaseRepository<Author> authorRepository)
        {
            _mapper = mapper;
            _materialRepository = materialRepository;
            _materialTypeRepository = materialTypeRepository;
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<MaterialDTO>> GetAllMaterialsAsync()
        {
            var materials = await _materialRepository.GetAllAsync();
            var materialsDTO = _mapper.Map<List<MaterialDTO>>(materials);
            return materialsDTO;
        }

        public async Task<MaterialDTO> GetMaterialByIDAsync(int materialID)
        {
            var material = await _materialRepository.GetSingleAsync(m => m.MaterialID == materialID);
            if (material is null) throw new ResourceNotFoundException($"Material with ID {materialID} not found");

            var materialDTO = _mapper.Map<MaterialDTO>(material);
            return materialDTO;
        }

        public async Task CreateMaterialAsync(CreateMaterialDTO createMaterialDTO)
        {
            var newMaterial = _mapper.Map<Material>(createMaterialDTO);

            var author = await _authorRepository.GetSingleAsync(A => A.AuthorID == createMaterialDTO.AuthorID);
            if (author is null) throw new ResourceNotFoundException($"Author with ID {createMaterialDTO.AuthorID} not found");

            var materialType = await _materialTypeRepository.GetSingleAsync(t => t.MaterialTypeID == createMaterialDTO.MaterialTypeID);
            if (materialType is null) throw new ResourceNotFoundException($"Type of materials with ID {createMaterialDTO.MaterialTypeID} not found");

            _materialRepository.Add(newMaterial);
            await _materialRepository.SaveAsync();
        }

        public async Task DeleteMaterialAsync(int materialID)
        {
            var material = await _materialRepository.GetSingleAsync(m => m.MaterialID == materialID);
            if (material is null) throw new ResourceNotFoundException($"Material with ID {materialID} not found");

            _materialRepository.Delete(material);
            await _materialRepository.SaveAsync();
        }

        public async Task UpdateMaterialAsync(UpdateMaterialDTO updateMaterialDTO, int materialID)
        {

            var material = await _materialRepository.GetSingleAsync(m => m.MaterialID == materialID);
            if (material is null) throw new ResourceNotFoundException($"Material with ID {materialID} not found"); 

            if (updateMaterialDTO.Description != null) material.Description = updateMaterialDTO.Description;
            if (updateMaterialDTO.Title != null) material.Title = updateMaterialDTO.Title;
            if (updateMaterialDTO.Location != null) material.Location = updateMaterialDTO.Location;
            if (updateMaterialDTO.AuthorID != null)
            {
                var author = await _authorRepository.GetSingleAsync(A => A.AuthorID == updateMaterialDTO.AuthorID);
                if (author is null) throw new ResourceNotFoundException($"Author with ID {updateMaterialDTO.AuthorID} not found");
                material.AuthorID = (int)updateMaterialDTO.AuthorID;
            }
            if (updateMaterialDTO.MaterialTypeID != null)
            {
                var materialType = await _materialTypeRepository.GetSingleAsync(t => t.MaterialTypeID == updateMaterialDTO.MaterialTypeID);
                if (materialType is null) throw new ResourceNotFoundException($"Type of materials with ID {updateMaterialDTO.MaterialTypeID} not found");
                material.MaterialTypeID = (int)updateMaterialDTO.MaterialTypeID;
            }
            if (updateMaterialDTO.PublishingDate != null) material.PublishingDate = (DateTime)updateMaterialDTO.PublishingDate;

            await _materialRepository.SaveAsync();
        }



    }
}
