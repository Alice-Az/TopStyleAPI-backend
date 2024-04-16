using AutoMapper;
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

        public UserService(IUserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<UserResponse?> CreateUser(UserRequest userRequest)
        {
            User? user = await _userRepo.CreateUser(_mapper.Map<User>(userRequest));
            if (user is null) return null;
            return _mapper.Map<UserResponse>(user);
        }

        public async Task<LoginResponse?> Login(LoginRequest loginRequest)
        {
            User? user = await _userRepo.Login(loginRequest.LoginEmail, loginRequest.LoginPassword);
            if (user == null) return null;
            return _mapper.Map<LoginResponse>(user);
        }
    }
}
