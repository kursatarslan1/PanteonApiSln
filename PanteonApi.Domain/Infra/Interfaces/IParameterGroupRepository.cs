using PanteonApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanteonApi.Domain.Infra.Interfaces
{
    public interface IParameterGroupRepository
    {
        Task<IEnumerable<ParameterGroup>> GetParameterGroupsAsync();
        Task<ParameterGroup> GetParameterGroupByIdAsync(string id);
        Task<List<string>> GetParameterNamesByConfigurationNameAsync(string configurationName);
        Task InsertParameterGroupAsync(ParameterGroup parameterGroup);
        Task UpdateParameterGroupAsync(ParameterGroup parameterGroup);
        Task DeleteParameterGroupAsync(string id);
    }
}
