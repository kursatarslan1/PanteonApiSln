using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PanteonApi.Domain.Entities;
using PanteonApi.Domain.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanteonApi.Infrastructure.Repositories
{
    public class ParameterGroupRepository : IParameterGroupRepository
    {
        private readonly IMongoCollection<ParameterGroup> _parameters;
        public ParameterGroupRepository(IOptions<PanteonDatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _parameters = mongoClient.GetDatabase(options.Value.DatabaseName).GetCollection<ParameterGroup>("ParameterGroup");
        }

        public async Task<IEnumerable<ParameterGroup>> GetParameterGroupsAsync()
        {
            if(_parameters == null)
            {
                return Enumerable.Empty<ParameterGroup>();
            }

            return await _parameters.Find(_ => true).ToListAsync();
        }

        public async Task<ParameterGroup> GetParameterGroupByIdAsync(string id)
        {
            return await _parameters.Find(parameter => parameter.ParameterId == id).FirstOrDefaultAsync();
        }

        public async Task<List<string>> GetParameterNamesByConfigurationNameAsync(string configurationName)
        {
            return await _parameters.Find(parameter => parameter.ConfigurationParameter == configurationName).Project(name => name.ParameterName).ToListAsync();
        }

        public async Task InsertParameterGroupAsync(ParameterGroup parameterGroup)
        {
            parameterGroup.ParameterId = Guid.NewGuid().ToString();
            await _parameters.InsertOneAsync(parameterGroup);   
        }

        public async Task UpdateParameterGroupAsync(ParameterGroup parameterGroup)
        {
            var filter = Builders<ParameterGroup>.Filter.Eq(group => group.ParameterId, parameterGroup.ParameterId);

            var update = Builders<ParameterGroup>.Update
                .Set(group => group.ParameterName, parameterGroup.ParameterName)
                .Set(group => group.ConfigurationParameter, parameterGroup.ConfigurationParameter);

            await _parameters.UpdateOneAsync(filter, update);
        }

        public async Task DeleteParameterGroupAsync(string id)
        {
            var filter = Builders<ParameterGroup>.Filter.Eq(group => group.ParameterId, id);
            await _parameters.DeleteOneAsync(filter);
        }
    }
}
