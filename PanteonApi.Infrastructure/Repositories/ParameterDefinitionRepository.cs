using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PanteonApi.Domain.Entities;
using PanteonApi.Domain.Infra.Interfaces;

namespace PanteonApi.Infrastructure.Repositories
{
	public class ParameterDefinitionRepository : IParameterDefinitionRepository
	{
		private readonly IMongoCollection<ParameterDefinition> _definition;
		public ParameterDefinitionRepository(IOptions<PanteonDatabaseSettings> options)
		{
			var mongoClient = new MongoClient(options.Value.ConnectionString);
			_definition = mongoClient.GetDatabase(options.Value.DatabaseName).GetCollection<ParameterDefinition>("ParameterDefinition");
		}

		public async Task<IEnumerable<ParameterDefinition>> GetParameterDefinitionsAsync()
		{
			if(_definition == null)
			{
				return Enumerable.Empty<ParameterDefinition>();
			}

			return await _definition.Find(_ => true).ToListAsync();
		}

		public async Task<ParameterDefinition> GetParameterDefinitionByIdAsync(string id)
		{
			return await _definition.Find(definition => definition.DefinitionId == id).FirstOrDefaultAsync();
		}

		public async Task<List<string>> GetParameterValuesByParameterName(string parameterName)
		{
			return await _definition.Find(definition => definition.ParameterName == parameterName).Project(parameter => parameter.ParameterValue).ToListAsync();
		}

		public async Task InsertParameterDefinitionAsync(ParameterDefinition parameterDefinition)
		{
			parameterDefinition.DefinitionId = Guid.NewGuid().ToString();
			await _definition.InsertOneAsync(parameterDefinition);
		}

		public async Task UpdateParameterDefinitionAsync(ParameterDefinition parameterDefinition)
		{
			var filter = Builders<ParameterDefinition>.Filter.Eq(definition => definition.DefinitionId, parameterDefinition.DefinitionId);

			var update = Builders<ParameterDefinition>.Update
				.Set(definition => definition.ParameterName, parameterDefinition.ParameterName)
				.Set(definition => definition.ParameterOptions, parameterDefinition.ParameterOptions)
				.Set(definition => definition.ParameterValue, parameterDefinition.ParameterValue);

			await _definition.UpdateOneAsync(filter, update);
		}

		public async Task DeleteParameterDefinitionAsync(string id)
		{
			var filter = Builders<ParameterDefinition>.Filter.Eq(definition => definition.DefinitionId, id);
			await _definition.DeleteOneAsync(filter);
		}
	}
}

