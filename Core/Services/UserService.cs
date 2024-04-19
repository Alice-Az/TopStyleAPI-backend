using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TopStyleAPI.Configuration;
using TopStyleAPI.Core.Interfaces;
using TopStyleAPI.Data.Interfaces;
using TopStyleAPI.Domain.Entities;
using TopStyleAPI.Domain.Models.User;

namespace TopStyleAPI.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UserService(IUserRepo userRepo, IMapper mapper, IConfiguration config)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _config = config;
        }

        public async Task<UserResponse?> CreateUser(UserRequest userRequest)
        {
            User? user = await _userRepo.CreateUser(_mapper.Map<User>(userRequest));
            if (user is null) return null;
            return _mapper.Map<UserResponse>(user);
        }

        public async Task<string?> Login(LoginRequest loginRequest)
        {
            User? user = await _userRepo.Login(loginRequest.LoginEmail, loginRequest.LoginPassword);

            if (user != null)
            {
                SecurityOptions security = _config.GetSection("Security").Get<SecurityOptions>() ?? new();
                List<Claim> claims = new()
                {
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.UserEmail)
                };

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(security.Key));
                var signInCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer: security.Issuer,
                    audience: security.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(20),

                    signingCredentials: signInCredentials
                    );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return tokenString;
            }
            return null;
            
        }
    }
}
