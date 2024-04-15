using TopStyleAPI.Domain.Models.User;

namespace TopStyleAPI.Core.Interfaces
{
    public interface IUserService
    {
        UserResponse? CreateUser(UserRequest userRequest);
        LoginResponse? GetUser(LoginRequest loginRequest);
    }
}
