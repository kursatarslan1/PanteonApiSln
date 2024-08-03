using System;
using PanteonApi.Application.Dtos;
using PanteonApi.Domain.Entities;
using PanteonApi.Domain.Infra.Interfaces;

namespace PanteonApi.Application.Services
{
	public class BuildingConfigurationService : IBuildingConfigurationService
	{
		private readonly IBuildingConfigurationRepository _buildingConfigurationRepository;
		public BuildingConfigurationService(IBuildingConfigurationRepository buildingConfigurationRepository)
		{
			_buildingConfigurationRepository = buildingConfigurationRepository;
		}

		public async Task<List<BuildingConfigurationDto>> GetBuildingConfigurationsAsync()
		{
			var buildingConfigurations = await _buildingConfigurationRepository.GetBuildingConfigurationsAsync();
			return buildingConfigurations.Select(configuration => new BuildingConfigurationDto(configuration)).ToList();
		}

		public async Task<BuildingConfigurationDto> GetBuildingConfigurationByIdAsync(string id)
		{
			var configuration = await _buildingConfigurationRepository.GetBuildingConfigurationByIdAsync(id);
			return new BuildingConfigurationDto(configuration);
		}

		public async Task CreateBuildingConfigurationAsync(BuildingConfigurationDto buildingConfiguration)
		{
			var newBuildingConfiguration = new BuildingConfiguration(buildingConfiguration.BuildingId, buildingConfiguration.BuildingType, buildingConfiguration.BuildingCost, buildingConfiguration.ConstructionTime);
			await _buildingConfigurationRepository.InsertBuildingConfigurationAsync(newBuildingConfiguration);
		}

		public async Task UpdateBuildingConfigurationAsync(BuildingConfigurationDto buildingConfiguration)
		{
			var configuration = new BuildingConfiguration(buildingConfiguration.BuildingId, buildingConfiguration.BuildingType, buildingConfiguration.BuildingCost, buildingConfiguration.ConstructionTime);
			await _buildingConfigurationRepository.UpdateBuildingConfigurationAsync(configuration);
		}

		public async Task DeleteBuildingConfigurationAsync(string id)
		{
			await _buildingConfigurationRepository.DeleteBuildingConfigurationAsync(id);
		}
	}
}

