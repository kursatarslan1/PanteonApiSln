using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using PanteonApi.Application.Dtos;
using PanteonApi.Application.Services;
using PanteonApi.Domain.Entities;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace PanteonApi.UI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IUserService _userService;
		private readonly IConfiguration _configuration;
		public AuthController(IUserService userService, IConfiguration configuration)
		{
			_userService = userService;
			_configuration = configuration;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] UserDto model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var userExists = await _userService.GetUserByUsernameAsync(model.Username);
			if(userExists != null)
			{
				return BadRequest("User already exists!");
			}

			var user = new User
			{
				Username = model.Username,
				Email = model.Email,
				Password = BCrypt.Net.BCrypt.HashPassword(model.Password)
			};

			await _userService.CreateUserAsync(user);

			var token = GenerateJwtToken(user);

			return Ok(new { Token = token });
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] UserDto model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var user = await _userService.GetUserByUsernameAsync(model.Username);
			if(user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
			{
				return Unauthorized();
			}

			var token = GenerateJwtToken(user);

			return Ok(new { Token = token });
		}

		private string GenerateJwtToken(User user)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, user.Username),
					new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
				}),
				Expires = System.DateTime.UtcNow.AddHours(2),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}

}

