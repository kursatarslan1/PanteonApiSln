using PanteonApi.Domain.Entities;
namespace PanteonApi.Domain.Infra.Interfaces{
    public interface IUserRepository{
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByIdAsync(int id);
        Task CreateUserAsync(User user);
    }
}