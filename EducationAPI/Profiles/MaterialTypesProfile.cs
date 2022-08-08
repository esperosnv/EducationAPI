using AutoMapper;
using EducationAPI.Models.MaterialType;
using EducationAPI.Data.Entities;

namespace EducationAPI.Profiles
{
    public class MaterialTypesProfile : Profile
    {
        public MaterialTypesProfile()
        {
            CreateMap<MaterialType, MaterialTypeDTO>();
            CreateMap<MaterialType, MaterialTypeDTOForAnotherDTO>();


        }
    }
}
