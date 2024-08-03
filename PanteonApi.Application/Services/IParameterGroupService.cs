using PanteonApi.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanteonApi.Application.Services
{
    public interface IParameterGroupService
    {
        Task<List<ParameterGroupDto>> GetParameterGroupsAsync();
        Task<ParameterGroupDto> GetParameterGroupByIdAsync(string id);
        Task<List<string>> GetParameterNamesByConfigurationNameAsync(string configurationName);
        Task CreateParameterGroupAsync(ParameterGroupDto parameterGroup);
        Task UpdateParameterGroupAsync(ParameterGroupDto parameterGroup);
        Task DeleteParameterGroupAsync(string id);
    }
}
