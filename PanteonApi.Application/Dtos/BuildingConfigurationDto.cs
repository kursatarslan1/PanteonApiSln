using System;
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
		public string BuildingCost { get; set; }
		public string ConstructionTime { get; set; }
	}
}

