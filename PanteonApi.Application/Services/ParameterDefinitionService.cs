using System;
using PanteonApi.Application.Dtos;
using PanteonApi.Domain.Entities;
using PanteonApi.Domain.Infra.Interfaces;

namespace PanteonApi.Application.Services
{
	public class ParameterDefinitionService : IParameterDefinitionService
	{
		private readonly IParameterDefinitionRepository _parameterDefinition;
		public ParameterDefinitionService(IParameterDefinitionRepository parameterDefinition)
		{
			_parameterDefinition = parameterDefinition;
		}

		public async Task<List<ParameterDefinitionDto>> GetParameterDefinitionsAsync()
		{
			var definitions = await _parameterDefinition.GetParameterDefinitionsAsync();
			return definitions.Select(definition => new ParameterDefinitionDto(definition)).ToList();
		}

		public async Task<ParameterDefinitionDto> GetParameterDefinitionByIdAsync(string id)
		{
			var definition = await _parameterDefinition.GetParameterDefinitionByIdAsync(id);
			return new ParameterDefinitionDto(definition);
		}

		public async Task<List<string>> GetParameterValuesByParameterName(string parameterName)
		{
			var parameterNames = await _parameterDefinition.GetParameterValuesByParameterName(parameterName);
			return parameterNames;
		}

		public async Task CreateParameterDefinitionAsync(ParameterDefinitionDto parameterDefinition)
		{
			var newParameterDefinition = new ParameterDefinition(parameterDefinition.DefinitionId, parameterDefinition.ParameterName, parameterDefinition.ParameterOptions, parameterDefinition.ParameterValue);
			await _parameterDefinition.InsertParameterDefinitionAsync(newParameterDefinition);
		}

		public async Task UpdateParameterDefinitionAsync(ParameterDefinitionDto parameterDefinition)
		{
			var updateDefinition = new ParameterDefinition(parameterDefinition.DefinitionId, parameterDefinition.ParameterName, parameterDefinition.ParameterOptions, parameterDefinition.ParameterValue);
			await _parameterDefinition.UpdateParameterDefinitionAsync(updateDefinition);
		}

		public async Task DeleteParameterDefinitionAsync(string id)
		{
			await _parameterDefinition.DeleteParameterDefinitionAsync(id);
		}
	}
}

