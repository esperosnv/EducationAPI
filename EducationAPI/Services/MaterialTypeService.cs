using AutoMapper;
using EducationAPI.Data.DAL.Interfaces;
using EducationAPI.Data.Entities;
using EducationAPI.Models.MaterialType;
using EducationAPI.Data.Exceptions;

namespace EducationAPI.Services
{
    public class MaterialTypeService : IMaterialTypeService
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<MaterialType> _materialTypeRepository;
        private readonly ILogger<MaterialTypeService> _logger;


        public MaterialTypeService(IMapper mapper, IBaseRepository<MaterialType> materialTypeRepository, ILogger<MaterialTypeService> logger)
        {
            _mapper = mapper;
            _materialTypeRepository = materialTypeRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<MaterialTypeDTO>> GetAllMaterialsTypeAsync()
        {
            _logger.LogInformation($"{DateTime.UtcNow} UTC - Request to get all materials type");

            var materialTypes = await _materialTypeRepository.GetAllAsync(null, null);
            var materialTypesDTO = _mapper.Map<IEnumerable<MaterialTypeDTO>>(materialTypes);
            return materialTypesDTO;
        }

        public async Task<MaterialTypeDTO> GetMaterialsTypeByIDAsync(int typeID)
        {
            _logger.LogInformation($"{DateTime.UtcNow} UTC - Request to get materials type with id {typeID}");

            var materialType = await _materialTypeRepository.GetSingleAsync(t => t.MaterialTypeID == typeID);
            if (materialType is null) throw new ResourceNotFoundException($"Type of materials with ID {typeID} not found");

            var materialTypeDTO = _mapper.Map<MaterialTypeDTO>(materialType);
            return materialTypeDTO;
        }

    }
}
