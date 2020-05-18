using System;
using BLL.App.DTO;
using Contracts.DAL.App.Repositories;

namespace Contracts.BLL.App.Services
{
    public interface ITimeService : ITimeRepository<Guid, Time>
    {
        
    }
}