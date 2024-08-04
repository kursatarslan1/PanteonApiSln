using PanteonApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanteonApi.Application.Services
{
    public interface ITokenService
    {
        Task<User> GetUserFromTokenAsync(string token);
    }
}
