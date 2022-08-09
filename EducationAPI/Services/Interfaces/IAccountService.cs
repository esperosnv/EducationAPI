using EducationAPI.Models.User;
using EducationAPI.Data.Entities;

namespace EducationAPI.Services
{
    public interface IAccountService
    {
        Task<string> GenerateJWT(LoginDTO dto);
        Task RegisterNewUser(RegisterUserDTO registerUserDTO, Role role);
    }
}