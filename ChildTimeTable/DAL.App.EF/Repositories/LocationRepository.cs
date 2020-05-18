using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;
using Location = DAL.App.DTO.Location;

namespace DAL.App.EF.Repositories
{
    public class LocationRepository : EFBaseRepository<ApplicationDbContext, Domain.Location, DAL.App.DTO.Location>, ILocationRepository
    {
        public LocationRepository(ApplicationDbContext dbContext) : base(dbContext, new BaseDALMapper<Domain.Location, DAL.App.DTO.Location>())
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