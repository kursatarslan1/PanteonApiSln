using System;
using System.ComponentModel.DataAnnotations;
using PanteonApi.Domain.Entities;
namespace PanteonApi.Application.Dtos
{
	public class ParameterGroupDto
	{
		public ParameterGroupDto()
		{
		}

        public ParameterGroupDto(ParameterGroup parameter)
        {
			ParameterId = parameter.ParameterId;
			ConfigurationParameter = parameter.ConfigurationParameter;
			ParameterName = parameter.ParameterName;
        }

		public string ParameterId { get; set; }
		
		public string ConfigurationParameter { get; set; }
		
		public string ParameterName { get; set; }
    }
}

