using TopStyleAPI.Domain.Models.User;

namespace TopStyleAPI.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse?> CreateUser(UserRequest userRequest);
        Task<LoginResponse?> Login(LoginRequest loginRequest);
    }
}
