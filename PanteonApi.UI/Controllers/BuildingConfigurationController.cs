using System;
using Microsoft.AspNetCore.Mvc;
using PanteonApi.Application.Dtos;
using PanteonApi.Application.Services;

namespace PanteonApi.UI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BuildingConfigurationController : ControllerBase
	{
		private readonly IBuildingConfigurationService _buildingConfigurationService;
		public BuildingConfigurationController(IBuildingConfigurationService buildingConfigurationService)
		{
			_buildingConfigurationService = buildingConfigurationService;
		}

		[HttpGet]
		public async Task<ActionResult<List<BuildingConfigurationDto>>> GetBuildingConfigurations()
		{
			var configurations = await _buildingConfigurationService.GetBuildingConfigurationsAsync();
			return Ok(configurations);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<BuildingConfigurationDto>> GetBuildingConfigurationById(string id)
		{
			var configuration = await _buildingConfigurationService.GetBuildingConfigurationByIdAsync(id);
			if(configuration == null)
			{
				return NotFound();
			}
			return Ok(configuration);
		}

		[HttpPost]
		public async Task<ActionResult> CreateBuildingConfiguration([FromBody] BuildingConfigurationDto buildingConfiguration)
		{
			await _buildingConfigurationService.CreateBuildingConfigurationAsync(buildingConfiguration);
			return CreatedAtAction(nameof(GetBuildingConfigurationById), new { id = buildingConfiguration.BuildingId }, buildingConfiguration);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateBuildingConfiguration(string id, [FromBody] BuildingConfigurationDto buildingConfiguration)
		{
			if (id != buildingConfiguration.BuildingId)
			{
				return BadRequest("ID mismatch");
			}

			var existingBuildingConfiguration = await _buildingConfigurationService.GetBuildingConfigurationByIdAsync(id);
			if(existingBuildingConfiguration == null)
			{
				return NotFound("Building configuration not found");
			}

			existingBuildingConfiguration.BuildingType = buildingConfiguration.BuildingType;
			existingBuildingConfiguration.BuildingCost = buildingConfiguration.BuildingCost;
			existingBuildingConfiguration.ConstructionTime = buildingConfiguration.ConstructionTime;

			await _buildingConfigurationService.UpdateBuildingConfigurationAsync(existingBuildingConfiguration);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteBuildingConfigurations(string id)
		{
			await _buildingConfigurationService.DeleteBuildingConfigurationAsync(id);
			return NoContent();
		}
	}
}

