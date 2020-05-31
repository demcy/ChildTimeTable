using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IObligationRepository : IBaseRepository<Obligation>, IObligationRepositoryCustom
    {
        Task<IEnumerable<Obligation>> AllPerDay(DateTime dt, Guid? userId = null);
        Task<List<DateTime>> DatesList(Guid? userId = null);
    }
}