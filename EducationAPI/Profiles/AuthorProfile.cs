using AutoMapper;
using EducationAPI.Models.Author;
using EducationAPI.Data.Entities;

namespace EducationAPI.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDTO>();

            CreateMap<CreateAuthorDTO, Author>();
        }
    }
}
