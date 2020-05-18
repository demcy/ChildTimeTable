using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.Base.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.App.Services
{
    public class ObligationService : BaseEntityService<IObligationRepository, IAppUnitOfWork, DAL.App.DTO.Obligation, Obligation>, IObligationService
    {
        public ObligationService(IAppUnitOfWork unitOfWork) 
            : base(unitOfWork, new BaseBLLMapper<DAL.App.DTO.Obligation, Obligation>(), unitOfWork.Obligations)
        {
        }

        public Task<IEnumerable<Obligation>> AllAsync(Guid? userId = null)
        {
            throw new NotImplementedException();
        }

        public Task<Obligation> FirstOrDefaultAsync(Guid id, Guid? userId = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Guid id, Guid? userId = null)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id, Guid? userId = null)
        {
            throw new NotImplementedException();
        }
    }
}