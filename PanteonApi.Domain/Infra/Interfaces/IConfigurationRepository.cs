using System;
using PanteonApi.Domain.Entities;

namespace PanteonApi.Domain.Infra.Interfaces
{
	public interface IConfigurationRepository
	{
		Task<IEnumerable<Configuration>> GetConfigurationsAsync();
		Task<Configuration> GetConfigurationByIdAsync(string id);
		Task InsertConfigurationAsync(Configuration configuration);
		Task UpdateConfigurationAsync(Configuration configuration);
		Task DeleteConfigurationAsync(string id);
	}
}

