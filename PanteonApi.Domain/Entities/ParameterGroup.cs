using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PanteonApi.Domain.Entities
{
	public class ParameterGroup
	{
		[BsonId]
		public ObjectId Id { get; set; }
		public required string ParameterId { get; set; }
		public required string ConfigurationParameter { get; set; }
		public required string ParameterName { get; set; }
	}
}

