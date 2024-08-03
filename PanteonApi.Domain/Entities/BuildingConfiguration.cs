using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PanteonApi.Domain.Entities
{
	public class BuildingConfiguration
	{
		public BuildingConfiguration(string buildingId, string buildingType, string buildingCost, string constructionTime)
		{
			BuildingId = buildingId;
			BuildingType = buildingType;
			BuildingCost = buildingCost;
			ConstructionTime = constructionTime;
		}

		[BsonId]
		public ObjectId Id { get; set; }
		public string BuildingId { get; set; }
		public string BuildingType { get; set; }
		public string BuildingCost { get; set; }
		public string ConstructionTime { get; set; }
	}
}

