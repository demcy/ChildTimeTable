using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.App.DTO;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;

namespace Contracts.BLL.App.Services
{
    public interface ILocationService : IBaseEntityService<Location>, ILocationRepositoryCustom<Location>
    {
        Task<IEnumerable<Location>> AllForPerson(Guid? userId = null);
        Task<bool> ExistsValue(string locationValue, Guid? userId = null);
        Task<Location> LocationByValue(string locationValue, Guid? userId = null);
    }
}