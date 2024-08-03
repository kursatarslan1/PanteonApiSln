using System;
using PanteonApi.Domain.Entities;

namespace PanteonApi.Application.Dtos
{
	public class ConfigurationDto
	{
		public ConfigurationDto()
		{
		}

		public ConfigurationDto(Configuration configuration)
		{
			ConfigurationId = configuration.ConfigurationId;
			ConfigurationName = configuration.ConfigurationName;
			ConfigurationParameter = configuration.ConfigurationParameter;
		}

		public string ConfigurationId { get; set; }
		public string ConfigurationName { get; set; }
		public string ConfigurationParameter { get; set; }
	}
}

