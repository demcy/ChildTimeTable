using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.App.DTO;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;

namespace Contracts.BLL.App.Services
{
    public interface IObligationService : IBaseEntityService<Obligation>, IObligationRepositoryCustom<Obligation>
    {
        Task<IEnumerable<Obligation>> AllPerDay(DateTime dt, Guid? userId = null);
        Task<List<DateTime>> DatesList(Guid? userId = null);
        
    }
}