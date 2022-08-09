using AutoMapper;
using EducationAPI.Models.User;
using EducationAPI.Data.Entities;

namespace EducationAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterUserDTO, User>()
                 .ForMember(u => u.PasswordHash, e => e.MapFrom(d => d.Password));
        }
  
    }
}
