using System;
using PanteonApi.Application.Dtos;

namespace PanteonApi.Application.Services
{
	public interface IParameterDefinitionService
	{
		Task<List<ParameterDefinitionDto>> GetParameterDefinitionsAsync();
		Task<ParameterDefinitionDto> GetParameterDefinitionByIdAsync(string id);
		Task<List<string>> GetParameterValuesByParameterName(string parameterName);
		Task CreateParameterDefinitionAsync(ParameterDefinitionDto parameterDefinition);
		Task UpdateParameterDefinitionAsync(ParameterDefinitionDto parameterDefinition);
		Task DeleteParameterDefinitionAsync(string id);
	}
}

