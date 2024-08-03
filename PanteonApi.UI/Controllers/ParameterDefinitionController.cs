using System;
using Microsoft.AspNetCore.Mvc;
using PanteonApi.Application.Dtos;
using PanteonApi.Application.Services;

namespace PanteonApi.UI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ParameterDefinitionController : ControllerBase
	{
		private readonly IParameterDefinitionService _parameterDefinitionService;
		public ParameterDefinitionController(IParameterDefinitionService parameterDefinitionService)
		{
			_parameterDefinitionService = parameterDefinitionService;
		}

		[HttpGet]
		public async Task<ActionResult<List<ParameterDefinitionDto>>> GetParameterdefinitions()
		{
			var definitions = await _parameterDefinitionService.GetParameterDefinitionsAsync();
			return Ok(definitions);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ParameterDefinitionDto>> GetParameterDefinitionById(string id)
		{
			var definition = await _parameterDefinitionService.GetParameterDefinitionByIdAsync(id);
			if(definition == null)
			{
				return NotFound();
			}

			return Ok(definition);
		}

		[HttpGet("ParameterName/{parameterName}")]
		public async Task<ActionResult<List<string>>> GetParameterValuesByParameterName(string parameterName)
		{
			var parameterValues = await _parameterDefinitionService.GetParameterValuesByParameterName(parameterName);
			if(parameterValues == null)
			{
				return NotFound();
			}
			return Ok(parameterValues);
		}

		[HttpPost]
		public async Task<ActionResult> CreateParameterDefinition([FromBody] ParameterDefinitionDto parameterDefinition)
		{
			await _parameterDefinitionService.CreateParameterDefinitionAsync(parameterDefinition);
			return CreatedAtAction(nameof(GetParameterDefinitionById), new { id = parameterDefinition.DefinitionId }, parameterDefinition);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateParameterDefinition(string id, [FromBody] ParameterDefinitionDto parameterDefinition)
		{
			if(id != parameterDefinition.DefinitionId)
			{
				return BadRequest("ID mismatch");
			}

			var existingParameterDefinition = await _parameterDefinitionService.GetParameterDefinitionByIdAsync(id);
			if(existingParameterDefinition == null)
			{
				return NotFound("Parameter definition not found");
			}

			existingParameterDefinition.ParameterName = parameterDefinition.ParameterName;
			existingParameterDefinition.ParameterOptions = parameterDefinition.ParameterValue;
			existingParameterDefinition.ParameterValue = parameterDefinition.ParameterValue;

			await _parameterDefinitionService.UpdateParameterDefinitionAsync(parameterDefinition);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteParameterDefinition(string id)
		{
			await _parameterDefinitionService.DeleteParameterDefinitionAsync(id);
			return NoContent();
		}
	}
}

