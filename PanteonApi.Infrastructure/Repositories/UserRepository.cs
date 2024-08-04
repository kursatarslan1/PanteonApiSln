using PanteonApi.Domain.Entities;
using PanteonApi.Domain.Infra.Interfaces;
using Microsoft.Extensions.Options;
using PanteonApi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace PanteonApi.Infrastructure.Repositories{
    public class UserRepository : IUserRepository {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context){
            _context = context;
        }

        public async Task<User> GetUserByUsernameAsync(string username){
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task CreateUserAsync(User user){
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}