using EducationAPI.Models.User;

namespace EducationAPI.Services
{
    public interface IAccountService
    {
        Task<string> GenerateJWT(LoginDTO dto);
        Task RegisterNewUser(RegisterUserDTO registerUserDTO);
    }
}