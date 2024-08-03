using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PanteonApi.Domain.Entities
{
	public class ParameterGroup
	{
		public ParameterGroup(string parameterId, string configurationParameter, string parameterName) 
		{ 
			ParameterId = parameterId;
			ConfigurationParameter = configurationParameter;
			ParameterName = parameterName;
		}

		[BsonId]
		public ObjectId Id { get; set; }
		public string ParameterId { get; set; }
		public string ConfigurationParameter { get; set; }
		public string ParameterName { get; set; }
	}
}

