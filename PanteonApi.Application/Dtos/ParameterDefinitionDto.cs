using System;
using PanteonApi.Domain.Entities;
namespace PanteonApi.Application.Dtos
{
	public class ParameterDefinitionDto
	{
		public ParameterDefinitionDto()
		{
		}

        public ParameterDefinitionDto(ParameterDefinition parameterDefinition)
        {
			DefinitionId = parameterDefinition.DefinitionId;
			ParameterName = parameterDefinition.ParameterName;
			ParameterOptions = parameterDefinition.ParameterOptions;
			ParameterValue = parameterDefinition.ParameterValue;
        }

		public string DefinitionId { get; set; }
		public string ParameterName { get; set; }
		public string ParameterOptions { get; set; }
		public string ParameterValue { get; set; }
    }
}

