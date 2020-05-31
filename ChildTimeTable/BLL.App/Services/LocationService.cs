using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.App.Mappers;
using BLL.Base.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.App.Services
{
    public class LocationService :
        BaseEntityService<IAppUnitOfWork, ILocationRepository , ILocationServiceMapper,
            DAL.App.DTO.Location, BLL.App.DTO.Location>, ILocationService 
    {
        public LocationService(IAppUnitOfWork uow) : base(uow, uow.Locations,
            new LocationServiceMapper())
        {
        }

        public async Task<IEnumerable<Location>> AllForPerson(Guid? userId = null)
        {
            return (await UOW.Locations.AllForPerson(userId))
                .Select(dbEntity => Mapper.Map(dbEntity));
        }

        public async Task<bool> ExistsValue(string locationValue, Guid? userId = null)
        {
            return await UOW.Locations.ExistsValue(locationValue, userId);
        }

        public async Task<Location> LocationByValue(string locationValue, Guid? userId = null)
        {
            return Mapper.Map(await UOW.Locations.LocationByValue(locationValue, userId));
        }
    }

}