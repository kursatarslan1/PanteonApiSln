using System;
using System.ComponentModel.DataAnnotations;
using PanteonApi.Domain.Entities;

namespace PanteonApi.Application.Dtos
{
	public class BuildingConfigurationDto
	{
		public BuildingConfigurationDto()
		{
		}

		public BuildingConfigurationDto(BuildingConfiguration buildingConfiguration)
		{
			BuildingId = buildingConfiguration.BuildingId;
			BuildingType = buildingConfiguration.BuildingType;
			BuildingCost = buildingConfiguration.BuildingCost;
			ConstructionTime = buildingConfiguration.ConstructionTime;
		}

		public string BuildingId { get; set; }
		public string BuildingType { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "BuildingCost must be greater than 0.")]
        public string BuildingCost { get; set; }
        [Range(30, 1800, ErrorMessage = "ConstructionTime must be between 30 and 1800")]
        public string ConstructionTime { get; set; }
	}
}

