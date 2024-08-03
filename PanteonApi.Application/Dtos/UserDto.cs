using System;
using PanteonApi.Domain.Entities;
namespace PanteonApi.Application.Dtos
{
	public class UserDto
	{
		public UserDto()
		{
		}

		public UserDto(User user)
		{
			Id = user.Id;
			Username = user.Username;
			Password = user.Password;
			Email = user.Email;
		}

		public int Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
	}
}


