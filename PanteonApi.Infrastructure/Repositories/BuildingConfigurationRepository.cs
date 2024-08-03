using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PanteonApi.Domain.Entities;
using PanteonApi.Domain.Infra.Interfaces;

namespace PanteonApi.Infrastructure.Repositories
{
	public class BuildingConfigurationRepository : IBuildingConfigurationRepository
	{
		private readonly IMongoCollection<BuildingConfiguration> _buildingConfiguration;
		public BuildingConfigurationRepository(IOptions<PanteonDatabaseSettings> options)
		{
			var mongoClient = new MongoClient(options.Value.ConnectionString);

			_buildingConfiguration = mongoClient.GetDatabase(options.Value.DatabaseName).GetCollection<BuildingConfiguration>("BuildingConfiguration");
		}

		public async Task<IEnumerable<BuildingConfiguration>> GetBuildingConfigurationsAsync()
		{
			if(_buildingConfiguration == null)
			{
				return Enumerable.Empty<BuildingConfiguration>();
			}

			return await _buildingConfiguration.Find(_ => true).ToListAsync();
		}

		public async Task<BuildingConfiguration> GetBuildingConfigurationByIdAsync(string id)
		{
			return await _buildingConfiguration.Find(config => config.BuildingId == id).FirstOrDefaultAsync();
		}

		public async Task InsertBuildingConfigurationAsync(BuildingConfiguration buildingConfiguration)
		{
			buildingConfiguration.BuildingId = Guid.NewGuid().ToString();
			await _buildingConfiguration.InsertOneAsync(buildingConfiguration);
		}

        public async Task UpdateBuildingConfigurationAsync(BuildingConfiguration buildingConfiguration)
        {
            var filter = Builders<BuildingConfiguration>.Filter.Eq(config => config.BuildingId, buildingConfiguration.BuildingId);

            var update = Builders<BuildingConfiguration>.Update
                .Set(config => config.BuildingCost, buildingConfiguration.BuildingCost)
                .Set(config => config.BuildingType, buildingConfiguration.BuildingType)
                .Set(config => config.ConstructionTime, buildingConfiguration.ConstructionTime);

            // Belirli alanları güncelle
            await _buildingConfiguration.UpdateOneAsync(filter, update);
        }

        public async Task DeleteBuildingConfigurationAsync(string id)
		{
			var filter = Builders<BuildingConfiguration>.Filter.Eq(config => config.BuildingId, id);
			await _buildingConfiguration.DeleteOneAsync(filter);
		}
	}
}

