using Microsoft.EntityFrameworkCore;
using TopStyleAPI.Data.Interfaces;
using TopStyleAPI.Domain.Entities;

namespace TopStyleAPI.Data.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly TopStyleContext _context;

        public UserRepo(TopStyleContext context)
        {
            _context = context;
        }

        public async Task<User?> CreateUser(User user)
        {
            bool userExists = await _context.Users.AnyAsync(u => u.UserEmail == user.UserEmail);
            if (userExists) return null;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> Login(string email, string password)
        {
            User? user = await _context.Users.SingleOrDefaultAsync(u => u.UserEmail == email && u.UserPassword == password);
            return user;
        }
    }
}
