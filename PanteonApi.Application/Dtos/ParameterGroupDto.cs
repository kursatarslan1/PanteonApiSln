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
		[Range(0.01, double.MaxValue, ErrorMessage = "BuildingCost must be greater than 0.")]
		public string ConfigurationParameter { get; set; }
		[Range(30, 1800, ErrorMessage = "ConstructionTime must be between 30 and 1800")]
		public string ParameterName { get; set; }
    }
}

