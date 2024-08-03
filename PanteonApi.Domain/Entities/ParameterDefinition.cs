using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PanteonApi.Domain.Entities
{
	public class ParameterDefinition
	{
		public ParameterDefinition(string definitionId, string parameterName, string parameterOptions, string parameterValue)
		{
			DefinitionId = definitionId;
			ParameterName = parameterName;
			ParameterOptions = parameterOptions;
			ParameterValue = parameterValue;
		}

		[BsonId]
		public ObjectId Id { get; set; }
		public string DefinitionId { get; set; }
		public string ParameterName { get; set; }
		public string ParameterOptions { get; set; }
		public string ParameterValue { get; set; }
	}
}

