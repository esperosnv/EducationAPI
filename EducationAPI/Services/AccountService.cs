using AutoMapper;
using EducationAPI.Data.DAL.Interfaces;
using EducationAPI.Data.Entities;
using Microsoft.AspNetCore.Identity;
using EducationAPI.Models.User;
using EducationAPI.Data.Exceptions;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace EducationAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly ILogger<AccountService> _logger;
        private readonly IBaseRepository<User> _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IMapper _mapper;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountService(IBaseRepository<User> userRepository, ILogger<AccountService> logger,
                                  IPasswordHasher<User> passwordHasher, IMapper mapper, AuthenticationSettings authenticationSettings)
        {
            _userRepository = userRepository;
            _logger = logger;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
            _authenticationSettings = authenticationSettings;
        }


        public async Task RegisterNewUser(RegisterUserDTO registerUserDTO)
        {
            var user = _mapper.Map<User>(registerUserDTO);
            var hasherPassword = _passwordHasher.HashPassword(user, registerUserDTO.Password);
            user.PasswordHash = hasherPassword;
             user.Role = Role.User;
            _userRepository.Add(user);
            await _userRepository.SaveAsync();
        }


        public async Task<string> GenerateJWT(LoginDTO dto)
        {
            var user = await _userRepository.GetSingleAsync(u => u.Login == dto.Login);
            if (user == null) throw new UnauthorizedException("Invalid login");

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed) throw new UnauthorizedException("Invalid password");

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer, _authenticationSettings.JwtIssuer,
                                                  claims, expires: expires, signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();


            return tokenHandler.WriteToken(token);
        }

    }
}
