using AutoMapper;
using EducationAPI.Data.DAL.Interfaces;
using EducationAPI.Data.Entities;
using EducationAPI.Models.Material;
using EducationAPI.Data.Exceptions;

namespace EducationAPI.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Material> _materialRepository;
        private readonly IBaseRepository<MaterialType> _materialTypeRepository;
        private readonly IBaseRepository<Author> _authorRepository;
        private readonly ILogger<MaterialService> _logger;



        public MaterialService(IMapper mapper, IBaseRepository<Material> materialRepository, IBaseRepository<MaterialType> materialTypeRepository,
                            IBaseRepository<Author> authorRepository, ILogger<MaterialService> logger)
        {
            _mapper = mapper;
            _materialRepository = materialRepository;
            _materialTypeRepository = materialTypeRepository;
            _authorRepository = authorRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<MaterialDTO>> GetAllMaterialsAsync(string? searchPhrase, string? direction)
        {
            _logger.LogInformation($"{DateTime.UtcNow} UTC - Request to get all materials");

            if (direction != null) direction = direction.ToLower();
            if (direction != null && direction != "asc" && direction != "desc") throw new BadRequestExeption("Not correct direction");

            var materials = await _materialRepository.GetAllAsync(searchPhrase, direction);
            var materialsDTO = _mapper.Map<List<MaterialDTO>>(materials);
            return materialsDTO;
        }

        public async Task<MaterialDTO> GetMaterialByIDAsync(int materialID)
        {
            _logger.LogInformation($"{DateTime.UtcNow} UTC - Request to get material with id {materialID}");

            var material = await _materialRepository.GetSingleAsync(m => m.MaterialID == materialID);
            if (material is null) throw new ResourceNotFoundException($"Material with ID {materialID} not found");

            var materialDTO = _mapper.Map<MaterialDTO>(material);
            return materialDTO;
        }

        public async Task<MaterialDTO> CreateMaterialAsync(CreateMaterialDTO createMaterialDTO)
        {
            _logger.LogInformation($"{DateTime.UtcNow} UTC - Request to create a new material");

            var newMaterial = _mapper.Map<Material>(createMaterialDTO);

            var author = await _authorRepository.GetSingleAsync(A => A.AuthorID == createMaterialDTO.AuthorID);
            if (author is null) throw new ResourceNotFoundException($"Author with ID {createMaterialDTO.AuthorID} not found");

            var materialType = await _materialTypeRepository.GetSingleAsync(t => t.MaterialTypeID == createMaterialDTO.MaterialTypeID);
            if (materialType is null) throw new ResourceNotFoundException($"Type of materials with ID {createMaterialDTO.MaterialTypeID} not found");

            _materialRepository.Add(newMaterial);
            await _materialRepository.SaveAsync();
            return await GetMaterialByIDAsync(newMaterial.MaterialID);
        }

        public async Task DeleteMaterialAsync(int materialID)
        {
            _logger.LogInformation($"{DateTime.UtcNow} UTC - Request to delete a material with id {materialID}");

            var material = await _materialRepository.GetSingleAsync(m => m.MaterialID == materialID);
            if (material is null) throw new ResourceNotFoundException($"Material with ID {materialID} not found");

            _materialRepository.Delete(material);
            await _materialRepository.SaveAsync();
        }

        public async Task<MaterialDTO> UpdateMaterialAsync(UpdateMaterialDTO updateMaterialDTO, int materialID)
        {
            _logger.LogInformation($"{DateTime.UtcNow} UTC - Patch request to update material with id {materialID}");

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
            return await GetMaterialByIDAsync(materialID);
        }

        public async Task<MaterialDTO> PutMaterialAsync(PutMaterialsDTO putMaterialsDTO, int materialID)
        {
            _logger.LogInformation($"{DateTime.UtcNow} UTC - Put request to update material with id {materialID}");

            var material = await _materialRepository.GetSingleAsync(m => m.MaterialID == materialID);
            if (material is null) throw new ResourceNotFoundException($"Material with ID {materialID} not found");

            material.Description = putMaterialsDTO.Description;
            material.Title = putMaterialsDTO.Title;
            material.Location = putMaterialsDTO.Location;

            var author = await _authorRepository.GetSingleAsync(A => A.AuthorID == putMaterialsDTO.AuthorID);
            if (author is null) throw new ResourceNotFoundException($"Author with ID {putMaterialsDTO.AuthorID} not found");
            material.AuthorID = putMaterialsDTO.AuthorID;

            var materialType = await _materialTypeRepository.GetSingleAsync(t => t.MaterialTypeID == putMaterialsDTO.MaterialTypeID);
            if (materialType is null) throw new ResourceNotFoundException($"Type of materials with ID {putMaterialsDTO.MaterialTypeID} not found");
            material.MaterialTypeID = putMaterialsDTO.MaterialTypeID;
            material.PublishingDate = putMaterialsDTO.PublishingDate;

            await _materialRepository.SaveAsync();
            return await GetMaterialByIDAsync(materialID);
        }

        public async Task<IEnumerable<MaterialDTO>> GetMaterialsFromSelectedType(string typeName)
        {
            _logger.LogInformation($"{DateTime.UtcNow} UTC - Get materials by {typeName} type");

            var materials = await _materialRepository.GetAllAsync(null, null);
            var selectedMaterials = materials.Where(m => m.MaterialType.Name.ToLower() == typeName.ToLower()).ToList();
            var materialsDTO = _mapper.Map<List<MaterialDTO>>(selectedMaterials);
            return materialsDTO;
        }



    }
}
