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
        private readonly IParameterGroupRepository _parameterGroupRepository;
        public ParameterGroupService(IParameterGroupRepository parameterGroupRepository)
        {
            _parameterGroupRepository = parameterGroupRepository;
        }

        public async Task<List<ParameterGroupDto>> GetParameterGroupsAsync()
        {
            var groups = await _parameterGroupRepository.GetParameterGroupsAsync();
            return groups.Select(group => new ParameterGroupDto(group)).ToList();   
        }

        public async Task<ParameterGroupDto> GetParameterGroupByIdAsync(string id)
        {
            var group = await _parameterGroupRepository.GetParameterGroupByIdAsync(id);
            return new ParameterGroupDto(group);
        }

        public async Task<List<string>> GetParameterNamesByConfigurationNameAsync(string configurationName)
        {
            var parameterNames = await _parameterGroupRepository.GetParameterNamesByConfigurationNameAsync(configurationName);
            return parameterNames;
        }

        public async Task CreateParameterGroupAsync(ParameterGroupDto parameterGroup)
        {
            var newParameterGroup = new ParameterGroup(parameterGroup.ParameterId, parameterGroup.ConfigurationParameter, parameterGroup.ParameterName);
            await _parameterGroupRepository.InsertParameterGroupAsync(newParameterGroup);
        }

        public async Task UpdateParameterGroupAsync(ParameterGroupDto parameterGroup)
        {
            var updateGroup = new ParameterGroup(parameterGroup.ParameterId, parameterGroup.ConfigurationParameter, parameterGroup.ParameterName);
            await _parameterGroupRepository.UpdateParameterGroupAsync(updateGroup);
        }

        public async Task DeleteParameterGroupAsync(string id)
        {
            await _parameterGroupRepository.DeleteParameterGroupAsync(id);
        }
    }
}
