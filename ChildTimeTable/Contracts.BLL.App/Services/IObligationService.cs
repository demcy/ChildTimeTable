using System;
using BLL.App.DTO;
using Contracts.DAL.App.Repositories;

namespace Contracts.BLL.App.Services
{
    public interface IObligationService : IObligationRepository<Guid, Obligation>
    {
        
    }
}