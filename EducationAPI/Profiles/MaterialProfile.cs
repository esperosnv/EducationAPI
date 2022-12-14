using AutoMapper;
using EducationAPI.Models.Material;
using EducationAPI.Data.Entities;

namespace EducationAPI.Profiles
{
    public class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            CreateMap<Material, MaterialDTO>()
                    .ForMember(d => d.Author, a => a.MapFrom(m => m.Author.Name))
                    .ForMember(d => d.MaterialType, a => a.MapFrom(m => m.MaterialType.Name));

            CreateMap<Material, MaterialsDTOForAnotherDTO>();

            CreateMap<CreateMaterialDTO, Material>();


        }
    }
}
