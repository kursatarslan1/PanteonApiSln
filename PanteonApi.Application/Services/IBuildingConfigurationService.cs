using System;
using PanteonApi.Application.Dtos;

namespace PanteonApi.Application.Services
{
	public interface IBuildingConfigurationService
	{
		Task<List<BuildingConfigurationDto>> GetBuildingConfigurationsAsync();
		Task<BuildingConfigurationDto> GetBuildingConfigurationByIdAsync(string id);
		Task CreateBuildingConfigurationAsync(BuildingConfigurationDto configuration);
		Task UpdateBuildingConfigurationAsync(BuildingConfigurationDto configuration);
		Task DeleteBuildingConfigurationAsync(string id);
	}
}

