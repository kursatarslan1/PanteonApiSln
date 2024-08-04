using System;
using PanteonApi.Domain.Entities;

namespace PanteonApi.Application.Services
{
	public interface IUserService
	{
		Task<User> GetUserByUsernameAsync(string username);
		Task<User> GetUserByEmailAsync(string email);
		Task<User> GetUserByIdAsync(int id);
		Task CreateUserAsync(User user);
	}
}

