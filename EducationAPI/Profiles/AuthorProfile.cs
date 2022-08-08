using AutoMapper;
using EducationAPI.Models.Author;
using EducationAPI.Data.Entities;

namespace EducationAPI.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDTO>()
                .ForMember(d => d.MaterialsCount, a => a.MapFrom(m => m.Materials.Count()));

            CreateMap<Author, AuthorDTOForAnotherDTO>()
                .ForMember(d => d.Materials, a => a.MapFrom(m => m.Materials.Select(t => t.Title)))
                .ForMember(d => d.MaterialsCount, a => a.MapFrom(m => m.Materials.Count()));


            CreateMap<CreateAuthorDTO, Author>();
        }
    }
}
