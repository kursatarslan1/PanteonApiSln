using PanteonApi.Domain.Entities;
namespace PanteonApi.Domain.Infra.Interfaces{
    public interface IUserRepository{
        Task<User> GetUserByUsernameAsync(string username);
        Task CreateUserAsync(User user);
    }
}