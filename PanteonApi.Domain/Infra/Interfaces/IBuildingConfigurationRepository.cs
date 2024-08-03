using System;
using PanteonApi.Domain.Entities;

namespace PanteonApi.Domain.Infra.Interfaces
{
	public interface IBuildingConfigurationRepository
	{
        Task<IEnumerable<BuildingConfiguration>> GetBuildingConfigurationsAsync();
        Task<BuildingConfiguration> GetBuildingConfigurationByIdAsync(string id);
        Task InsertBuildingConfigurationAsync(BuildingConfiguration configuration);
        Task UpdateBuildingConfigurationAsync(BuildingConfiguration configuration);
        Task DeleteBuildingConfigurationAsync(string id);
    }
}

