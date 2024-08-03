using PanteonApi.Application.Dtos;
using PanteonApi.Domain.Entities;
using PanteonApi.Domain.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanteonApi.Application.Services
{
    public class ParameterGroupService : IParameterGroupService
    {
        private readonly IParameterGroupRepository _parameterGroupService;
        public ParameterGroupService(IParameterGroupRepository parameterGroupService)
        {
            _parameterGroupService = parameterGroupService;
        }

        public async Task<List<ParameterGroupDto>> GetParameterGroupsAsync()
        {
            var groups = await _parameterGroupService.GetParameterGroupsAsync();
            return groups.Select(group => new ParameterGroupDto(group)).ToList();   
        }

        public async Task<ParameterGroupDto> GetParameterGroupByIdAsync(string id)
        {
            var group = await _parameterGroupService.GetParameterGroupByIdAsync(id);
            return new ParameterGroupDto(group);
        }

        public async Task<List<string>> GetParameterNamesByConfigurationNameAsync(string configurationName)
        {
            var parameterNames = await _parameterGroupService.GetParameterNamesByConfigurationNameAsync(configurationName);
            return parameterNames;
        }

        public async Task CreateParameterGroupAsync(ParameterGroupDto parameterGroup)
        {
            var newParameterGroup = new ParameterGroup(parameterGroup.ParameterId, parameterGroup.ConfigurationParameter, parameterGroup.ParameterName);
            await _parameterGroupService.InsertParameterGroupAsync(newParameterGroup);
        }

        public async Task UpdateParameterGroupAsync(ParameterGroupDto parameterGroup)
        {
            var updateGroup = new ParameterGroup(parameterGroup.ParameterId, parameterGroup.ConfigurationParameter, parameterGroup.ParameterName);
            await _parameterGroupService.UpdateParameterGroupAsync(updateGroup);
        }

        public async Task DeleteParameterGroupAsync(string id)
        {
            await _parameterGroupService.DeleteParameterGroupAsync(id);
        }
    }
}
