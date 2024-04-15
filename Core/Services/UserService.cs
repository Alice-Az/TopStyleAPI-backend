using TopStyleAPI.Core.Interfaces;
using TopStyleAPI.Data;
using TopStyleAPI.Domain.Entities;
using TopStyleAPI.Domain.Models.User;

namespace TopStyleAPI.Core.Services
{
    public class UserService : IUserService
    {
        public UserResponse? CreateUser(UserRequest userRequest)
        {
            using TopStyleContext db = new();

            User user = new()
            {
                UserEmail = userRequest.UserEmail,
                UserPassword = userRequest.UserPassword,
            };

            bool userExists = db.Users.Any(u => u.UserEmail == userRequest.UserEmail);
            if (!userExists) db.Users.Add(user);
            else return null;

            db.SaveChanges();

            UserResponse response = new()
            {
                UserId = user.Id,
                UserEmail = user.UserEmail
            };
            return response;
        }

        public LoginResponse? GetUser(LoginRequest loginRequest)
        {
            using TopStyleContext db = new();

            User? user = db.Users.SingleOrDefault(u => u.UserEmail == loginRequest.LoginEmail && u.UserPassword == loginRequest.LoginPassword);
            if (user == null) return null;
            else
            {
                LoginResponse loginResponse = new()
                {
                    UserId = user.Id,
                    UserEmail = user.UserEmail,
                };
                return loginResponse;
            };
        }
    }
}
