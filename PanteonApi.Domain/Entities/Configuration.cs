using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PanteonApi.Domain.Entities
{
	public class Configuration
	{
		public Configuration(string configurationId, string configurationName, string configurationParameter)
		{
			ConfigurationId = configurationId;
			ConfigurationName = configurationName;
			ConfigurationParameter = configurationParameter;

		}

		[BsonId]
		public ObjectId Id { get; set; }
		public string ConfigurationId { get; set; }
		public string ConfigurationName { get; set; }
		public string ConfigurationParameter { get; set; }
	}
}

