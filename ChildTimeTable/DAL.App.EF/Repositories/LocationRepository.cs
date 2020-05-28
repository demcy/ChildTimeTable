using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Location = DAL.App.DTO.Location;

namespace DAL.App.EF.Repositories
{
    public class LocationRepository : EFBaseRepository<ApplicationDbContext, Domain.Location, DAL.App.DTO.Location>, ILocationRepository
    {
        public LocationRepository(ApplicationDbContext dbContext) : base(dbContext, new BaseDALMapper<Domain.Location, DAL.App.DTO.Location>())
        {
        }

        public async Task<IEnumerable<Location>> AllForPerson(Guid? userId = null)
        {
            var personId = RepoDbContext.Persons.First(p => p.AppUserId == userId).Id;
            return (await RepoDbSet.Where(l=>l.PersonId == personId).ToListAsync())
                .Select(dbEntity => Mapper.Map(dbEntity));
        }
        
        public async Task<bool> ExistsValue(string locationValue, Guid? userId = null)
        {
            return await RepoDbSet.Where(l => l.PersonId == userId)
                .AnyAsync(l => l.LocationValue == locationValue);
        }
        public async Task<Location> LocationByValue(string locationValue, Guid? userId = null)
        {
            return Mapper.Map(await RepoDbSet.Where(l => l.PersonId == userId)
                .Where(l => l.LocationValue == locationValue).FirstOrDefaultAsync());
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