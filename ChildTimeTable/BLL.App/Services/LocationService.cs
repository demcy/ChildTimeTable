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
    public class LocationService : BaseEntityService<ILocationRepository, IAppUnitOfWork, DAL.App.DTO.Location, Location>, ILocationService
    {
        public LocationService(IAppUnitOfWork unitOfWork) 
            : base(unitOfWork, new BaseBLLMapper<DAL.App.DTO.Location, Location>(), unitOfWork.Locations)
        {
        }

        public Task<IEnumerable<Location>> AllAsync(Guid? userId = null)
        {
            throw new NotImplementedException();
        }

        public Task<Location> FirstOrDefaultAsync(Guid id, Guid? userId = null)
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