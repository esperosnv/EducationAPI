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

        public MaterialTypeService(IMapper mapper, IBaseRepository<MaterialType> materialTypeRepository)
        {
            _mapper = mapper;
            _materialTypeRepository = materialTypeRepository;
        }

        public async Task<IEnumerable<MaterialTypeDTO>> GetAllMaterialsTypeAsync()
        {
            var materialTypes = await _materialTypeRepository.GetAllAsync();
            var materialTypesDTO = _mapper.Map<IEnumerable<MaterialTypeDTO>>(materialTypes);
            return materialTypesDTO;
        }

        public async Task<MaterialTypeDTO> GetMaterialsTypeByIDAsync(int typeID)
        {
            var materialType = await _materialTypeRepository.GetSingleAsync(t => t.MaterialTypeID == typeID);
            if (materialType is null) throw new ResourceNotFoundException($"Type of materials with ID {typeID} not found");

            var materialTypeDTO = _mapper.Map<MaterialTypeDTO>(materialType);
            return materialTypeDTO;
        }


    }
}
