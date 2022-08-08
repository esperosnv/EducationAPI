using AutoMapper;
using EducationAPI.Models.Material;
using EducationAPI.Data.Entities;

namespace EducationAPI.Profiles
{
    public class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            CreateMap<Material, MaterialDTO>();
            CreateMap<Material, MaterialsDTOForAnotherDTO>();

            CreateMap<CreateMaterialDTO, Material>();


        }
    }
}
