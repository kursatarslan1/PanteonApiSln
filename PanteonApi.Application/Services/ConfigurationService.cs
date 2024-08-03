using System;
using PanteonApi.Application.Dtos;
using PanteonApi.Domain.Entities;
using PanteonApi.Domain.Infra.Interfaces;

namespace PanteonApi.Application.Services
{
	public class ConfigurationService : IConfigurationService
	{
		private readonly IConfigurationRepository _configurationRepository;
		public ConfigurationService(IConfigurationRepository configurationRepository)
		{
            _configurationRepository = configurationRepository;
		}

		public async Task<List<ConfigurationDto>> GetConfigurationsAsync()
		{
			var configurations = await _configurationRepository.GetConfigurationsAsync();
			return configurations.Select(config => new ConfigurationDto(config)).ToList();
		}

		public async Task<ConfigurationDto> GetConfigurationByIdAsync(string id)
		{
			var configuration = await _configurationRepository.GetConfigurationByIdAsync(id);
			return new ConfigurationDto(configuration);
		}

		public async Task CreateConfigurationAsync(ConfigurationDto configuration)
		{
			var newConfiguration = new Configuration(configuration.ConfigurationId, configuration.ConfigurationName, configuration.ConfigurationParameter);
			await _configurationRepository.InsertConfigurationAsync(newConfiguration);
		}

		public async Task UpdateConfigurationAsync(ConfigurationDto configuration)
		{
			var updateConfiguration = new Configuration(configuration.ConfigurationId, configuration.ConfigurationName, configuration.ConfigurationParameter);
			await _configurationRepository.UpdateConfigurationAsync(updateConfiguration);
		}

		public async Task DeleteConfigurationAsync(string id)
		{
			await _configurationRepository.DeleteConfigurationAsync(id);
		}

	}
}

