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
    public class TimeService : BaseEntityService<ITimeRepository, IAppUnitOfWork, DAL.App.DTO.Time, Time>, ITimeService
    {
        public TimeService(IAppUnitOfWork unitOfWork) 
            : base(unitOfWork, new BaseBLLMapper<DAL.App.DTO.Time, Time>(), unitOfWork.Times)
        {
        }

        public Task<IEnumerable<Time>> AllAsync(Guid? userId = null)
        {
            throw new NotImplementedException();
        }

        public Task<Time> FirstOrDefaultAsync(Guid id, Guid? userId = null)
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