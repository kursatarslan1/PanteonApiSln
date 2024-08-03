using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PanteonApi.Domain.Entities;
using PanteonApi.Domain.Infra.Interfaces;

namespace PanteonApi.Infrastructure.Repositories
{
	public class ConfigurationRepository : IConfigurationRepository
	{
		private readonly IMongoCollection<Configuration> _configuration;
		public ConfigurationRepository(IOptions<PanteonDatabaseSettings> options) 
		{
			var mongoClient = new MongoClient(options.Value.ConnectionString);
			_configuration = mongoClient.GetDatabase(options.Value.DatabaseName).GetCollection<Configuration>("Configuration");
		}

		public async Task<IEnumerable<Configuration>> GetConfigurationsAsync()
		{
			if(_configuration == null)
			{
				return Enumerable.Empty<Configuration>();
			}

			return await _configuration.Find(_ => true).ToListAsync();
		}

		public async Task<Configuration> GetConfigurationByIdAsync(string id)
		{
			return await _configuration.Find(config => config.ConfigurationId == id).FirstOrDefaultAsync();
		}

		public async Task InsertConfigurationAsync(Configuration configuration)
		{
			configuration.ConfigurationId = Guid.NewGuid().ToString();
			await _configuration.InsertOneAsync(configuration);
		}

		public async Task UpdateConfigurationAsync(Configuration configuration)
		{
			var filter = Builders<Configuration>.Filter.Eq(config => config.ConfigurationId, configuration.ConfigurationId);

			var update = Builders<Configuration>.Update
				.Set(config => config.ConfigurationName, configuration.ConfigurationName)
				.Set(config => config.ConfigurationParameter, configuration.ConfigurationParameter);

			await _configuration.UpdateOneAsync(filter, update);
		}

		public async Task DeleteConfigurationAsync(string id)
		{
			var filter = Builders<Configuration>.Filter.Eq(config => config.ConfigurationId, id);
			await _configuration.DeleteOneAsync(filter);
		}
	}
}

