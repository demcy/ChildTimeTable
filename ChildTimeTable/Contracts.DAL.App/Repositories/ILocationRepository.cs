using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface ILocationRepository : IBaseRepository<Location>, ILocationRepositoryCustom
    {
        Task<IEnumerable<Location>> AllForPerson(Guid? userId = null);
        Task<bool> ExistsValue(string locationValue, Guid? userId = null);
        Task<Location> LocationByValue(string locationValue, Guid? userId = null);
    }
    

    
}