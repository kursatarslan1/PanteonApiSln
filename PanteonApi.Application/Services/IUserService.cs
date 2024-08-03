using System;
using PanteonApi.Domain.Entities;

namespace PanteonApi.Application.Services
{
	public interface IUserService
	{
		Task<User> GetUserByUsernameAsync(string username);
		Task CreateUserAsync(User user);
	}
}

