using System;
using PanteonApi.Domain.Entities;

namespace PanteonApi.Domain.Infra.Interfaces
{
	public interface IParameterDefinitionRepository
	{
		Task<IEnumerable<ParameterDefinition>> GetParameterDefinitionsAsync();
		Task<ParameterDefinition> GetParameterDefinitionByIdAsync(string id);
		Task<List<string>> GetParameterValuesByParameterName(string parameterName);
		Task InsertParameterDefinitionAsync(ParameterDefinition parameterDefinition);
		Task UpdateParameterDefinitionAsync(ParameterDefinition parameterDefinition);
		Task DeleteParameterDefinitionAsync(string id);
	}
}

