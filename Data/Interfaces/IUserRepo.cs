using Microsoft.AspNetCore.Identity.Data;
using TopStyleAPI.Domain.Entities;

namespace TopStyleAPI.Data.Interfaces
{
    public interface IUserRepo
    {
        Task<User?> CreateUser(User user);
        Task<User?> Login(string email, string password);
    }
}
