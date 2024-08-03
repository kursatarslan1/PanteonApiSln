using System;
using Microsoft.AspNetCore.Mvc;
using PanteonApi.Application.Dtos;
using PanteonApi.Application.Services;

namespace PanteonApi.UI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ConfigurationController : ControllerBase
	{
		private readonly IConfigurationService _configurationService;
		public ConfigurationController(IConfigurationService configurationService)
		{
			_configurationService = configurationService;
		}

		[HttpGet]
		public async Task<ActionResult<List<ConfigurationDto>>> GetConfigurations()
		{
			var configurations = await _configurationService.GetConfigurationsAsync();
			return Ok(configurations);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ConfigurationDto>> GetConfigurationById(string id)
		{
			var configuration = await _configurationService.GetConfigurationByIdAsync(id);
			if(configuration == null)
			{
				return NotFound();
			}
			return Ok(configuration);
		}

		[HttpPost]
		public async Task<ActionResult> CreateConfiguration([FromBody] ConfigurationDto configuration)
		{
			await _configurationService.CreateConfigurationAsync(configuration);
			return CreatedAtAction(nameof(GetConfigurationById), new { id = configuration.ConfigurationId }, configuration);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateConfiguration(string id, [FromBody] ConfigurationDto configuration)
		{
			if (id != configuration.ConfigurationId)
			{
				return BadRequest("ID mismatch");
			}

			var existingConfiguration = await _configurationService.GetConfigurationByIdAsync(id);
			if(existingConfiguration == null)
			{
				return NotFound("Configuration not found");
			}

			existingConfiguration.ConfigurationName = configuration.ConfigurationName;
			existingConfiguration.ConfigurationParameter = configuration.ConfigurationParameter;

			await _configurationService.UpdateConfigurationAsync(configuration);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteConfiguration(string id)
		{
			await _configurationService.DeleteConfigurationAsync(id);
			return NoContent();
		}
	}
}

