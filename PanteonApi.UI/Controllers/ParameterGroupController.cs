using Microsoft.AspNetCore.Mvc;
using PanteonApi.Application.Dtos;
using PanteonApi.Application.Services;
using PanteonApi.Domain.Entities;

namespace PanteonApi.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParameterGroupController : ControllerBase  
    {
        private readonly IParameterGroupService _parameterGroupService;
        public ParameterGroupController(IParameterGroupService parameterGroupService)
        {
            _parameterGroupService = parameterGroupService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ParameterGroup>>> GetParameterGroups()
        {
            var groups = await _parameterGroupService.GetParameterGroupsAsync();
            return Ok(groups);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParameterGroup>> GetParameterGroupById(string id)
        {
            var group = await _parameterGroupService.GetParameterGroupByIdAsync(id);
            if(group == null)
            {
                return NotFound();
            }

            return Ok(group);
        }

        [HttpGet("ByConfigurationName/{configurationName}")]
        public async Task<ActionResult<List<string>>> GetParameterNamesByConfigurationName(string configurationName)
        {
            var parameterNames = await _parameterGroupService.GetParameterNamesByConfigurationNameAsync(configurationName);
            if(parameterNames == null)
            {
                return NotFound();
            }
            return Ok(parameterNames);
        }

        [HttpPost]
        public async Task<ActionResult> CreateParameterGroup([FromBody] ParameterGroupDto parameterGroup)
        {
            await _parameterGroupService.CreateParameterGroupAsync(parameterGroup);
            return CreatedAtAction(nameof(GetParameterGroupById), new { id = parameterGroup.ParameterId }, parameterGroup);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateParameterGroup(string id, [FromBody] ParameterGroupDto parameterGroup)
        {
            if(id != parameterGroup.ParameterId)
            {
                return BadRequest("ID mismatch");
            }

            var existingParameterGroup = await _parameterGroupService.GetParameterGroupByIdAsync(id);
            if(existingParameterGroup == null)
            {
                return NotFound("Parameter group not found");
            }

            existingParameterGroup.ParameterName = parameterGroup.ParameterName;
            existingParameterGroup.ConfigurationParameter = parameterGroup.ConfigurationParameter;

            await _parameterGroupService.UpdateParameterGroupAsync(existingParameterGroup);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteParameterGroup(string id)
        {
            await _parameterGroupService.DeleteParameterGroupAsync(id);
            return NoContent();
        }
    }
}
