using System;
using PanteonApi.Application.Dtos;

namespace PanteonApi.Application.Services
{
	public interface IConfigurationService
	{
		Task<List<ConfigurationDto>> GetConfigurationsAsync();
		Task<ConfigurationDto> GetConfigurationByIdAsync(string id);
		Task CreateConfigurationAsync(ConfigurationDto configuration);
		Task UpdateConfigurationAsync(ConfigurationDto configuration);
		Task DeleteConfigurationAsync(string id);
	}
}

